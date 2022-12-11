namespace DirectoryBackupConfigurationTool.Forms
{
    partial class DirectoryConfigEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfigNameTextBox = new System.Windows.Forms.TextBox();
            this.BackupDirTextBox = new System.Windows.Forms.TextBox();
            this.BackupDestTextBox = new System.Windows.Forms.TextBox();
            this.BackupDirSelectButton = new System.Windows.Forms.Button();
            this.BackupDestSelectButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Backup Directory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Backup Destination:";
            // 
            // ConfigNameTextBox
            // 
            this.ConfigNameTextBox.Location = new System.Drawing.Point(137, 6);
            this.ConfigNameTextBox.Name = "ConfigNameTextBox";
            this.ConfigNameTextBox.Size = new System.Drawing.Size(256, 23);
            this.ConfigNameTextBox.TabIndex = 4;
            // 
            // BackupDirTextBox
            // 
            this.BackupDirTextBox.Location = new System.Drawing.Point(137, 35);
            this.BackupDirTextBox.Name = "BackupDirTextBox";
            this.BackupDirTextBox.Size = new System.Drawing.Size(256, 23);
            this.BackupDirTextBox.TabIndex = 5;
            // 
            // BackupDestTextBox
            // 
            this.BackupDestTextBox.Location = new System.Drawing.Point(137, 64);
            this.BackupDestTextBox.Name = "BackupDestTextBox";
            this.BackupDestTextBox.Size = new System.Drawing.Size(256, 23);
            this.BackupDestTextBox.TabIndex = 6;
            // 
            // BackupDirSelectButton
            // 
            this.BackupDirSelectButton.Location = new System.Drawing.Point(399, 38);
            this.BackupDirSelectButton.Name = "BackupDirSelectButton";
            this.BackupDirSelectButton.Size = new System.Drawing.Size(32, 23);
            this.BackupDirSelectButton.TabIndex = 8;
            this.BackupDirSelectButton.Text = "...";
            this.BackupDirSelectButton.UseVisualStyleBackColor = true;
            this.BackupDirSelectButton.Click += new System.EventHandler(this.OnGetDir_Click);
            // 
            // BackupDestSelectButton
            // 
            this.BackupDestSelectButton.Location = new System.Drawing.Point(399, 64);
            this.BackupDestSelectButton.Name = "BackupDestSelectButton";
            this.BackupDestSelectButton.Size = new System.Drawing.Size(32, 23);
            this.BackupDestSelectButton.TabIndex = 9;
            this.BackupDestSelectButton.Text = "...";
            this.BackupDestSelectButton.UseVisualStyleBackColor = true;
            this.BackupDestSelectButton.Click += new System.EventHandler(this.OnGetDir_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(302, 110);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSave_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(383, 110);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.OnCancel_Click);
            // 
            // DirectoryConfigEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 145);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BackupDestSelectButton);
            this.Controls.Add(this.BackupDirSelectButton);
            this.Controls.Add(this.BackupDestTextBox);
            this.Controls.Add(this.BackupDirTextBox);
            this.Controls.Add(this.ConfigNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DirectoryConfigEditForm";
            this.Text = "DirectoryConfigEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox ConfigNameTextBox;
        private TextBox BackupDirTextBox;
        private TextBox BackupDestTextBox;
        private Button BackupDirSelectButton;
        private Button BackupDestSelectButton;
        private Button SaveButton;
        private Button CancelButton;
    }
}