using Engine.Tool;
using DirectoryBackupConfigurationTool.Forms;
using DirectoryBackupConfigurationTool.Notify;
using DirectoryBackupConfigurationTool.Events;
using System.Timers;
using System.Runtime.Serialization;

namespace DirectoryBackupConfigurationTool.Classes
{
    internal class DirectoryBackupConfigManager : Tool
    {
        private const string TOOL_NAME = "Directory Backup Configuration Manager";
        private object _configLock = new object();
        public List<DirectoryBackupConfiguration> Configs;
        private List<DirectoryBackupConfiguration> _configs = new List<DirectoryBackupConfiguration>();
        private DirectoryBackupConfigForm? Form;
        private string _saveFilePath { get { return Path.Combine(DirectoryPath, "DirBackupMetaData.bin"); } }
        protected override void Load()
        {
            _configs = new();
            try
            {
                DirectoryBackupConfiguration[]? configs = Engine.IO.BinarySerialization.ReadFromBinaryFile<DirectoryBackupConfiguration[]>(_saveFilePath);
                if (configs == null) return;
                for (int i = 0; i < configs.Length; i++)
                {
                    _configs.Add(configs[i]);
                    configs[i].Init();
                }
                _configs.Sort();
            }
            catch (FileNotFoundException)
            {
                Engine.Notify.NotifyHandler.General(CodeNotify.FileNotFound);
            }
            catch(SerializationException e)
            {
                Engine.Notify.NotifyHandler.General(CodeNotify.FileNotFound);
            }
        }
        protected override void Save()
        {
            DirectoryBackupConfiguration[] configs = new DirectoryBackupConfiguration[_configs.Count];
            _configs.CopyTo(configs, 0);
            Engine.IO.BinarySerialization.WriteToBinaryFile(_saveFilePath, configs);
        }
        public override void Init()
        {
            ToolName = TOOL_NAME;
            if (!Initialized)
            {
                base.Init();
                CheckStartupFolder();
                SetWindowsStartUp(true);
                // Create event timer to query the configurations and decide if action must be taken or not
            }
            if (Form == null)
            {
                return;
            }
            RebuildFormConfigList();
        }
        public void BindToForm(ref DirectoryBackupConfigForm form)
        {
            if (form == null)
            {
                Engine.Notify.NotifyHandler.Fatal(CodeFatal.NullFormError);
                return;
            }
            Form = form;
            form.AddConfig += new EventHandler<ConfigurationEventArgs>(OnConfigAdd);
            form.DeleteConfig += new EventHandler<ConfigurationEventArgs>(OnConfigRemove);
            form.EditConfig += new EventHandler<ConfigurationUpdateEventArgs>(OnConfigEdit);
        }
        private void CheckStartupFolder()
        {
            // This method is not implimented yet. This will be to validate the program should start up with Windows
        }
        private void OnConfigAdd(object sender, ConfigurationEventArgs args)
        {
            AddConfig(args.Configuration);
        }
        private void OnConfigRemove(object sender, ConfigurationEventArgs args)
        {
            DeleteConfig(args.Configuration);
        }
        private void OnConfigEdit(object sender, ConfigurationUpdateEventArgs args)
        {

        }
        public void AddConfig(DirectoryBackupConfiguration config)
        {
            lock (_configLock)
            {
                if (config == null) return;
                _configs.Add(config);
                config.Init();
                Save();
                RebuildFormConfigList();
            }
        }
        public void DeleteConfig(DirectoryBackupConfiguration config)
        {
            lock(_configLock)
            {
                if (config == null) return;
                _configs.Remove(config);
                Save();
                RebuildFormConfigList();
            }
        }
        public void EditConfig(ConfigurationUpdateEventArgs args)
        {
            lock (_configLock)
            {
                if (args == null || args.OldConfiguration == null || args.NewConfiguration == null) return;
                _configs.Remove(args.OldConfiguration);
                _configs.Add(args.NewConfiguration);
                args.NewConfiguration.Init();
                Save();
                RebuildFormConfigList();
            }
        }
        public List<DirectoryBackupConfiguration> GetConfigs()
        {
            lock (_configLock)
            {
                return _configs;
            }
        }
        private void RebuildFormConfigList()
        {
            Form?.ClearList();
            Form?.PopulateList(_configs.ToArray());
        }
    }
}
