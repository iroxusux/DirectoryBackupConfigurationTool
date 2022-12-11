using Engine;
using DirectoryBackupConfigurationTool.Classes;
using DirectoryBackupConfigurationTool.Forms;
using Engine.Forms.Classes;

namespace DirectoryBackupConfigurationTool
{
    internal static class Program
    {
        private const double VERSION = 2.01;
        private static bool DebugMode = false;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// Before we do anything at all, check if the same process already exists as a running process. If true, exit the environment (we don't want 2 programs running at the same time, especially for file control)
            var exists = System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1;
            if (exists)
            {
                Environment.Exit(0);
            }
            ApplicationConfiguration.Initialize();

            /// Configure and run application
            DirectoryBackupConfigForm form = new();  // The view
            DirectoryBackupConfigManager manager = new();
            manager.BindToForm(ref form);
            manager.Init();
            if (DebugMode)
            {
                Debugger.Load();
            }
            Application.Run(form);
        }
    }
}
   