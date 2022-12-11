namespace DirectoryBackupConfigurationTool.Forms
{
    partial class DirectoryBackupConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConfigListView = new System.Windows.Forms.ListView();
            this.AddEditDeleteControl = new Engine.Forms.UserControls.AddEditDeleteControl();
            this.SuspendLayout();
            // 
            // ConfigListView
            // 
            this.ConfigListView.Location = new System.Drawing.Point(12, 47);
            this.ConfigListView.Name = "ConfigListView";
            this.ConfigListView.Size = new System.Drawing.Size(389, 268);
            this.ConfigListView.TabIndex = 0;
            this.ConfigListView.UseCompatibleStateImageBehavior = false;
            // 
            // AddEditDeleteControl
            // 
            this.AddEditDeleteControl.Location = new System.Drawing.Point(12, 11);
            this.AddEditDeleteControl.Name = "AddEditDeleteControl";
            this.AddEditDeleteControl.Size = new System.Drawing.Size(235, 30);
            this.AddEditDeleteControl.TabIndex = 1;
            // 
            // DirectoryBackupConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 337);
            this.Controls.Add(this.AddEditDeleteControl);
            this.Controls.Add(this.ConfigListView);
            this.Name = "DirectoryBackupConfigForm";
            this.Text = "DirectoryBackupConfigForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView ConfigListView;
        public Engine.Forms.UserControls.AddEditDeleteControl AddEditDeleteControl;
    }
}