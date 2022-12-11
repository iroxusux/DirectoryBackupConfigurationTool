using DirectoryBackupConfigurationTool.Classes;
using DirectoryBackupConfigurationTool.Events;

namespace DirectoryBackupConfigurationTool.Forms
{
    public partial class DirectoryBackupConfigForm : Form
    {
        internal EventHandler<ConfigurationEventArgs> AddConfig = delegate { };
        internal EventHandler<ConfigurationUpdateEventArgs> EditConfig = delegate { };
        internal EventHandler<ConfigurationEventArgs> DeleteConfig = delegate { };
        public DirectoryBackupConfigForm()
        {
            InitializeComponent();
            AddEditDeleteControl.AddClicked += new EventHandler(OnAdd_Click);
            AddEditDeleteControl.EditClicked += new EventHandler(OnEdit_Click);
            AddEditDeleteControl.DeleteClicked += new EventHandler(OnDelete_Click);
        }
        private void OnAdd(ConfigurationEventArgs e)
        {
            EventHandler<ConfigurationEventArgs> handler = AddConfig;
            handler?.Invoke(this, e);
        }
        private void OnEdit(ConfigurationUpdateEventArgs e)
        {
            EventHandler<ConfigurationUpdateEventArgs> handler = EditConfig;
            handler?.Invoke(this, e);
        }
        private void OnDelete(ConfigurationEventArgs e)
        {
            EventHandler<ConfigurationEventArgs> handler = DeleteConfig;
            handler?.Invoke(this, e);
        }
        public void ClearList()
        {
            ConfigListView.Items.Clear();
        }
        public void PopulateList(DirectoryBackupConfiguration[] configs)
        {
            ClearList();
            for (int i = 0; i < configs.Length; i++)
            {
                ListViewItem item = new ListViewItem() { Name = configs[i].Name, Text = configs[i].Name, Tag = configs[i] };
                ConfigListView.Items.Add(item);
            }
            ConfigListView.Sorting = SortOrder.Ascending;
            ConfigListView.Sort();
        }
        private void OnAdd_Click(object sender, EventArgs e)
        {
            using(var form = new DirectoryConfigEditForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DirectoryBackupConfiguration config = new()
                    {
                        Name = form.ReturnName,
                        BackupDestination = form.ReturnDestination,
                        BackupDirectory = form.ReturnDirectory,
                    };
                    ConfigurationEventArgs args = new() { Configuration = config };
                    OnAdd(args);
                }
            }
        }
        private void OnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryBackupConfiguration oldConfig = ConfigListView.SelectedItems[0].Tag as DirectoryBackupConfiguration;
                if (oldConfig == null) return;

                DirectoryBackupConfiguration newConfig = new();

                using(var form = new DirectoryConfigEditForm(oldConfig))
                {
                    var result = form.ShowDialog();
                    if(result == DialogResult.OK)
                    {
                        newConfig.Name = form.ReturnName;
                        newConfig.BackupDestination = form.ReturnDestination;
                        newConfig.BackupDirectory = form.ReturnDirectory;
                    }
                }
                ConfigurationUpdateEventArgs args = new() { NewConfiguration = newConfig, OldConfiguration = oldConfig };
                OnEdit(args);
            }
            catch (NullReferenceException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }
        private void OnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryBackupConfiguration config = ConfigListView.SelectedItems[0].Tag as DirectoryBackupConfiguration;
                ConfigurationEventArgs args = new() { Configuration = config };
                OnDelete(args);
            }
            catch(NullReferenceException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }
    }
}
