using DirectoryBackupConfigurationTool.Classes;
using System.Windows.Forms;

namespace DirectoryBackupConfigurationTool.Forms
{
    public partial class DirectoryConfigEditForm : Form
    {
        public string ReturnName { get; private set; } = String.Empty;
        public string ReturnDirectory { get; private set; } = String.Empty;
        public string ReturnDestination { get; private set; } = String.Empty;

        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public DirectoryConfigEditForm()
        {
            InitializeComponent();
        }
        public DirectoryConfigEditForm(DirectoryBackupConfiguration config)
        {
            InitializeComponent();
            ConfigNameTextBox.Text = config.Name;
            BackupDirTextBox.Text = config.BackupDirectory;
            BackupDestTextBox.Text = config.BackupDestination;
        }
        private void OnGetDir_Click(object sender, EventArgs e)
        {
            TextBox textBox = null;
            Button button = sender as Button;
            if (button == null) return;
            if(button.Name == "BackupDirSelectButton")
            {
                textBox = BackupDirTextBox;
            }
            if(button.Name == "BackupDestSelectButton")
            {
                textBox = BackupDestTextBox;
            }
            if (textBox == null) return;

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void OnSave_Click(object sender, EventArgs e)
        {
            ReturnName = ConfigNameTextBox.Text;
            ReturnDestination = BackupDestTextBox.Text;
            ReturnDirectory = BackupDirTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void OnCancel_Click(object sender, EventArgs e)
        {
            ReturnName = String.Empty;
            ReturnDestination = String.Empty;
            ReturnDirectory= String.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
