# Protection of Information 2026 - Project Architecture

## 1) Architectural Style

The solution follows a Clean Architecture direction with service-oriented modules:

- **Core**: custom crypto primitives and math (`RC6Cipher`, `PcbcMode`, `Sha1Hasher`, `PlayfairCipher`).
- **Interfaces**: contracts for interchangeable services (`ICryptoService`, `IHasher`, `IMetadataManager`, `IFileWatcherService`).
- **Services**: orchestration and IO-heavy workflows (`EncryptionService`, `MetadataManager`, `FileWatcherService`, networking services).
- **UI**: WinForms views (`DashboardView`, `ManualEncryptionView`, `NetworkView`) that delegate logic to services.

Key rule: core cryptographic logic is custom implementation, not `System.Security.Cryptography` algorithms.

## 2) Service-Oriented Flow

### Automatic pipeline (Dashboard + FileWatcherService)
1. User starts watcher on a selected folder with a session password.
2. User selects encryption algorithm (`RC6 + PCBC` or `Playfair (txt only)`).
2. `FileWatcherService` emits `FileDetected`.
3. `DashboardView` calls `EncryptionService.EncryptFile(...)` with selected algorithm.
4. Encrypted file is stored in `CryptoStorage` as `<name>.locked`.

### Manual pipeline (ManualEncryptionView)
1. User drops/selects file.
2. User chooses algorithm (`RC6 + PCBC` or `Playfair`) and password.
3. View dispatches encryption/decryption in background via `Task.Run`.

### Network pipeline
1. Sender encrypts file first (if the selected file is not already `.locked`).
2. Sender chooses algorithm (`RC6 + PCBC` or `Playfair (txt only)`).
2. `FileSender` streams encrypted file over TCP.
3. `FileReceiver` saves into `Downloads/Encrypted`, then immediately decrypts to `Downloads/Decrypted`.
4. Integrity verification is performed automatically after decryption.

## 3) File Format and Metadata Header

Every encrypted file starts with metadata header bytes:

```
[4 bytes header-length][header-json][20 bytes SHA-1 of original plaintext][payload...]
```

`FileMetadata` JSON contains:

- `OriginalFileName`
- `FileSize`
- `CreationTime`
- `EncryptionAlgorithm`
- `HashAlgorithm`

For RC6 mode, payload is:

```
[IV(16 bytes)][PCBC ciphertext blocks...]
```

## 4) RC6 + PCBC Math (Implemented)

Let:
- `P_i` = plaintext block i
- `C_i` = ciphertext block i
- `IV` = initialization vector
- `E_k()` / `D_k()` = RC6 encrypt/decrypt with key `k`

Initialization:
- `P_0 = IV`
- `C_0 = IV`

Encryption per block:
- `X_i = P_i XOR P_{i-1} XOR C_{i-1}`
- `C_i = E_k(X_i)`

Decryption per block:
- `X_i = D_k(C_i)`
- `P_i = X_i XOR P_{i-1} XOR C_{i-1}`

Final block uses PKCS#7 padding.

## 5) Streaming Strategy for Big Files

`EncryptionService` now uses `FileStream` with buffer-based processing (8KB):

- no `ReadAllBytes`;
- chunked reads/writes for input/output;
- RC6/PCBC chain state (`prevPlain`, `prevCipher`) preserved across chunks;
- SHA-1 computed from stream (`IHasher.ComputeHash(Stream)`).

This makes the pipeline scalable for large media files.

## 6) SHA-1 Integrity Check

- Before encryption: SHA-1 is computed for original plaintext and written into encrypted file format.
- After decryption: SHA-1 of decrypted output is recomputed.
- If mismatch: decryption output is rejected and deleted (`INTEGRITY CHECK FAILED`).
- Integrity is enforced for both RC6+PCBC and Playfair outputs.

## 7) File Watcher Logic

`FileWatcherService` responsibilities:

- subscribes to Created/Changed/Renamed events;
- ignores directories and empty/incomplete files;
- provides simple event callback to UI;
- dashboard applies debounce and `.locked` guard to avoid re-encrypt loops.

## 8) Dependency Injection Note

Current code already uses interface-based boundaries and constructor-ready services.  
For full DI composition in WinForms, a next step is registering services in a host container and injecting views/forms from the container.
