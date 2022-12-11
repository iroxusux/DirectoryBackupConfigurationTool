using DirectoryBackupConfigurationTool.Classes;

namespace DirectoryBackupConfigurationTool.Events
{
    internal class ConfigurationEventArgs : EventArgs
    {
        public DirectoryBackupConfiguration? Configuration = null;
    }
}
