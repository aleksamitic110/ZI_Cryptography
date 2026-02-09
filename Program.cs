namespace ZI_Cryptography
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ZI_Cryptography.ZI_Cryptography_App.UI.Helpers.GlobalExceptionHandler.Register();
            Application.Run(new MainForm());
        }
    }
}
