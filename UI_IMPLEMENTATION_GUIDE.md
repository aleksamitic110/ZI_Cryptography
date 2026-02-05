# UI Implementation Guide

This guide explains how to finish **Manual Encryption View** and **Network View** integration in WinForms.

## 1) Manual Encryption View (Drag and Drop)

Implemented control: `ZI_Cryptography_App/UI/Controls/ManualEncryptionView.cs`

### What it already includes
- Drag-and-drop file selection (`AllowDrop`, `DragEnter`, `DragDrop`).
- Click-to-browse fallback (`OpenFileDialog`).
- Password input.
- Algorithm selection:
  - `RC6 + PCBC`
  - `Playfair (txt only)`
- Buttons:
  - `Encrypt`
  - `Decrypt`
- Background execution via `Task.Run` to avoid UI freeze.
- Local operation log textbox.

### How it is wired
- `MainForm` now loads `ManualEncryptionView` when Encryption menu is clicked.
- Uses `EncryptionService` through `ICryptoService`.

### UX recommendations
- Disable controls while a background crypto operation is running.
- Show clear error when user selects Playfair for non-`.txt` file.
- Keep selected file updated after each operation (already done).

## 2) Network View (TCP Client/Server)

Services created:

- `ZI_Cryptography_App/Services/Networking/FileSender.cs`
- `ZI_Cryptography_App/Services/Networking/FileReceiver.cs`

### Sender flow (`FileSender`)
1. User selects a file to send.
2. If the file is not `.locked`, the app encrypts it first using the selected algorithm:
   - `RC6 + PCBC`
   - `Playfair (txt only)`
2. Connect to receiver IP/Port.
3. Send:
   - file name length (`Int32`)
   - file name (UTF-8)
   - file size (`Int64`)
   - file bytes (streamed chunks)

### Receiver flow (`FileReceiver`)
1. Start `TcpListener` on selected port.
2. Accept incoming connections.
3. Save bytes to `Downloads/Encrypted`.
4. Call `EncryptionService.DecryptFile(...)`.
5. If SHA-1 check passes, raise `FileReceivedAndVerified` event.
6. On error, raise `ReceiveFailed`.

## 3) How to connect NetworkView UI to services

In `NetworkView` code-behind:

1. Add fields:
   - `FileSender _sender`
   - `FileReceiver? _receiver`
   - `CancellationTokenSource? _listenerCts`
2. Build sender controls:
   - target IP textbox
   - target port textbox
   - file picker button
   - send button
3. Build receiver controls:
   - listening port textbox
   - shared password textbox
   - start/stop listening button
   - event log listbox/textbox
4. On start listening:
   - create `FileReceiver(new EncryptionService(), password)`
   - subscribe to `FileReceivedAndVerified` and `ReceiveFailed`
   - call `StartAsync(port, cts.Token)` in background
5. On send:
   - ensure file is encrypted first (`.locked`)
   - call `SendEncryptedFileAsync(...)` in background

## 4) Minimal event wiring example

```csharp
_receiver.FileReceivedAndVerified += (_, e) =>
{
    BeginInvoke(() => logsListBox.Items.Insert(0, e.Message + " -> " + e.DecryptedPath));
};

_receiver.ReceiveFailed += (_, message) =>
{
    BeginInvoke(() => logsListBox.Items.Insert(0, "ERROR: " + message));
};
```

## 5) Validation Checklist

- Manual encrypt/decrypt does not block the UI thread.
- RC6 path handles large files without memory spikes.
- Received files are stored in `Downloads/Encrypted`.
- Decrypted outputs are generated in `Downloads/Decrypted`.
- Hash mismatch is detected and surfaced as an error.
