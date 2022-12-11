using DirectoryBackupConfigurationTool.Classes;

namespace DirectoryBackupConfigurationTool.Events
{
    internal class ConfigurationUpdateEventArgs : EventArgs
    {
        public DirectoryBackupConfiguration? NewConfiguration = null;
        public DirectoryBackupConfiguration? OldConfiguration = null;
    }
}
