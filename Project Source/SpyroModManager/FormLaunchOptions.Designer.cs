namespace SpyroModManager
{
    partial class FormLaunchOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLaunchOptions));
            this.group_consoleInjector = new System.Windows.Forms.GroupBox();
            this.lbl_linkedInjector = new System.Windows.Forms.Label();
            this.btn_downloadInjector = new System.Windows.Forms.Button();
            this.lbl_consoleInjector = new System.Windows.Forms.Label();
            this.chk_consoleInjector = new System.Windows.Forms.CheckBox();
            this.btn_injectorPath = new System.Windows.Forms.Button();
            this.group_backupSave = new System.Windows.Forms.GroupBox();
            this.btn_manageBackups = new System.Windows.Forms.Button();
            this.btn_clearBackups = new System.Windows.Forms.Button();
            this.chk_backupSave = new System.Windows.Forms.CheckBox();
            this.lbl_linkedSaveDir = new System.Windows.Forms.Label();
            this.lbl_backup = new System.Windows.Forms.Label();
            this.btn_chooseSaveDir = new System.Windows.Forms.Button();
            this.group_miscOptions = new System.Windows.Forms.GroupBox();
            this.chk_closeLauncher = new System.Windows.Forms.CheckBox();
            this.chk_skipCutscenes = new System.Windows.Forms.CheckBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.group_consoleInjector.SuspendLayout();
            this.group_backupSave.SuspendLayout();
            this.group_miscOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_consoleInjector
            // 
            this.group_consoleInjector.Controls.Add(this.lbl_linkedInjector);
            this.group_consoleInjector.Controls.Add(this.btn_downloadInjector);
            this.group_consoleInjector.Controls.Add(this.lbl_consoleInjector);
            this.group_consoleInjector.Controls.Add(this.chk_consoleInjector);
            this.group_consoleInjector.Controls.Add(this.btn_injectorPath);
            this.group_consoleInjector.Location = new System.Drawing.Point(12, 12);
            this.group_consoleInjector.Name = "group_consoleInjector";
            this.group_consoleInjector.Size = new System.Drawing.Size(776, 95);
            this.group_consoleInjector.TabIndex = 0;
            this.group_consoleInjector.TabStop = false;
            this.group_consoleInjector.Text = "Console Injector";
            // 
            // lbl_linkedInjector
            // 
            this.lbl_linkedInjector.AutoSize = true;
            this.lbl_linkedInjector.ForeColor = System.Drawing.Color.Red;
            this.lbl_linkedInjector.Location = new System.Drawing.Point(435, 43);
            this.lbl_linkedInjector.Name = "lbl_linkedInjector";
            this.lbl_linkedInjector.Size = new System.Drawing.Size(132, 13);
            this.lbl_linkedInjector.TabIndex = 4;
            this.lbl_linkedInjector.Tag = "IgnoreTheme";
            this.lbl_linkedInjector.Text = "Console Injector not linked";
            // 
            // btn_downloadInjector
            // 
            this.btn_downloadInjector.Location = new System.Drawing.Point(9, 38);
            this.btn_downloadInjector.Name = "btn_downloadInjector";
            this.btn_downloadInjector.Size = new System.Drawing.Size(202, 24);
            this.btn_downloadInjector.TabIndex = 3;
            this.btn_downloadInjector.Text = "Download Console Injector";
            this.btn_downloadInjector.UseVisualStyleBackColor = true;
            this.btn_downloadInjector.Click += new System.EventHandler(this.btn_downloadInjector_Click);
            // 
            // lbl_consoleInjector
            // 
            this.lbl_consoleInjector.AutoSize = true;
            this.lbl_consoleInjector.Location = new System.Drawing.Point(6, 16);
            this.lbl_consoleInjector.Name = "lbl_consoleInjector";
            this.lbl_consoleInjector.Size = new System.Drawing.Size(626, 13);
            this.lbl_consoleInjector.TabIndex = 2;
            this.lbl_consoleInjector.Text = "The Console Injector is an application that enables the developer console in game" +
    ". It will launch 45 seconds after starting the game.";
            // 
            // chk_consoleInjector
            // 
            this.chk_consoleInjector.AutoSize = true;
            this.chk_consoleInjector.Location = new System.Drawing.Point(9, 68);
            this.chk_consoleInjector.Name = "chk_consoleInjector";
            this.chk_consoleInjector.Size = new System.Drawing.Size(124, 17);
            this.chk_consoleInjector.TabIndex = 1;
            this.chk_consoleInjector.Text = "Use Console Injector";
            this.chk_consoleInjector.UseVisualStyleBackColor = true;
            // 
            // btn_injectorPath
            // 
            this.btn_injectorPath.Location = new System.Drawing.Point(217, 38);
            this.btn_injectorPath.Name = "btn_injectorPath";
            this.btn_injectorPath.Size = new System.Drawing.Size(202, 24);
            this.btn_injectorPath.TabIndex = 0;
            this.btn_injectorPath.Text = "Choose Console Injector Executable";
            this.btn_injectorPath.UseVisualStyleBackColor = true;
            this.btn_injectorPath.Click += new System.EventHandler(this.btn_injectorPath_Click);
            // 
            // group_backupSave
            // 
            this.group_backupSave.Controls.Add(this.btn_manageBackups);
            this.group_backupSave.Controls.Add(this.btn_clearBackups);
            this.group_backupSave.Controls.Add(this.chk_backupSave);
            this.group_backupSave.Controls.Add(this.lbl_linkedSaveDir);
            this.group_backupSave.Controls.Add(this.lbl_backup);
            this.group_backupSave.Controls.Add(this.btn_chooseSaveDir);
            this.group_backupSave.Location = new System.Drawing.Point(12, 126);
            this.group_backupSave.Name = "group_backupSave";
            this.group_backupSave.Size = new System.Drawing.Size(776, 120);
            this.group_backupSave.TabIndex = 1;
            this.group_backupSave.TabStop = false;
            this.group_backupSave.Text = "Backup Save File";
            // 
            // btn_manageBackups
            // 
            this.btn_manageBackups.Location = new System.Drawing.Point(539, 88);
            this.btn_manageBackups.Name = "btn_manageBackups";
            this.btn_manageBackups.Size = new System.Drawing.Size(111, 24);
            this.btn_manageBackups.TabIndex = 7;
            this.btn_manageBackups.Text = "Manage Backups";
            this.btn_manageBackups.UseVisualStyleBackColor = true;
            this.btn_manageBackups.Click += new System.EventHandler(this.btn_manageBackups_Click);
            // 
            // btn_clearBackups
            // 
            this.btn_clearBackups.Location = new System.Drawing.Point(656, 88);
            this.btn_clearBackups.Name = "btn_clearBackups";
            this.btn_clearBackups.Size = new System.Drawing.Size(111, 24);
            this.btn_clearBackups.TabIndex = 5;
            this.btn_clearBackups.Text = "Clear Backups";
            this.btn_clearBackups.UseVisualStyleBackColor = true;
            this.btn_clearBackups.Click += new System.EventHandler(this.btn_clearBackups_Click);
            // 
            // chk_backupSave
            // 
            this.chk_backupSave.AutoSize = true;
            this.chk_backupSave.Location = new System.Drawing.Point(9, 93);
            this.chk_backupSave.Name = "chk_backupSave";
            this.chk_backupSave.Size = new System.Drawing.Size(105, 17);
            this.chk_backupSave.TabIndex = 5;
            this.chk_backupSave.Text = "Backup save file";
            this.chk_backupSave.UseVisualStyleBackColor = true;
            // 
            // lbl_linkedSaveDir
            // 
            this.lbl_linkedSaveDir.AutoSize = true;
            this.lbl_linkedSaveDir.ForeColor = System.Drawing.Color.Red;
            this.lbl_linkedSaveDir.Location = new System.Drawing.Point(232, 69);
            this.lbl_linkedSaveDir.Name = "lbl_linkedSaveDir";
            this.lbl_linkedSaveDir.Size = new System.Drawing.Size(97, 13);
            this.lbl_linkedSaveDir.TabIndex = 5;
            this.lbl_linkedSaveDir.Tag = "IgnoreTheme";
            this.lbl_linkedSaveDir.Text = "Save file not linked";
            // 
            // lbl_backup
            // 
            this.lbl_backup.AutoSize = true;
            this.lbl_backup.Location = new System.Drawing.Point(6, 16);
            this.lbl_backup.Name = "lbl_backup";
            this.lbl_backup.Size = new System.Drawing.Size(686, 39);
            this.lbl_backup.TabIndex = 6;
            this.lbl_backup.Text = resources.GetString("lbl_backup.Text");
            // 
            // btn_chooseSaveDir
            // 
            this.btn_chooseSaveDir.Location = new System.Drawing.Point(9, 64);
            this.btn_chooseSaveDir.Name = "btn_chooseSaveDir";
            this.btn_chooseSaveDir.Size = new System.Drawing.Size(202, 23);
            this.btn_chooseSaveDir.TabIndex = 5;
            this.btn_chooseSaveDir.Text = "Choose Save File";
            this.btn_chooseSaveDir.UseVisualStyleBackColor = true;
            this.btn_chooseSaveDir.Click += new System.EventHandler(this.btn_chooseSaveDir_Click);
            // 
            // group_miscOptions
            // 
            this.group_miscOptions.Controls.Add(this.chk_closeLauncher);
            this.group_miscOptions.Controls.Add(this.chk_skipCutscenes);
            this.group_miscOptions.Location = new System.Drawing.Point(12, 269);
            this.group_miscOptions.Name = "group_miscOptions";
            this.group_miscOptions.Size = new System.Drawing.Size(776, 70);
            this.group_miscOptions.TabIndex = 2;
            this.group_miscOptions.TabStop = false;
            this.group_miscOptions.Text = "Other Launch Options";
            // 
            // chk_closeLauncher
            // 
            this.chk_closeLauncher.AutoSize = true;
            this.chk_closeLauncher.Location = new System.Drawing.Point(9, 42);
            this.chk_closeLauncher.Name = "chk_closeLauncher";
            this.chk_closeLauncher.Size = new System.Drawing.Size(309, 17);
            this.chk_closeLauncher.TabIndex = 9;
            this.chk_closeLauncher.Text = "Automatically close the mod manager when launching Spyro";
            this.chk_closeLauncher.UseVisualStyleBackColor = true;
            // 
            // chk_skipCutscenes
            // 
            this.chk_skipCutscenes.AutoSize = true;
            this.chk_skipCutscenes.Location = new System.Drawing.Point(9, 19);
            this.chk_skipCutscenes.Name = "chk_skipCutscenes";
            this.chk_skipCutscenes.Size = new System.Drawing.Size(122, 17);
            this.chk_skipCutscenes.TabIndex = 7;
            this.chk_skipCutscenes.Text = "Skip intro cutscenes";
            this.chk_skipCutscenes.UseVisualStyleBackColor = true;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(544, 361);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(118, 23);
            this.btn_confirm.TabIndex = 3;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(668, 361);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(118, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // FormLaunchOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 394);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.group_miscOptions);
            this.Controls.Add(this.group_backupSave);
            this.Controls.Add(this.group_consoleInjector);
            this.Name = "FormLaunchOptions";
            this.ShowIcon = false;
            this.Text = "Launch Options";
            this.group_consoleInjector.ResumeLayout(false);
            this.group_consoleInjector.PerformLayout();
            this.group_backupSave.ResumeLayout(false);
            this.group_backupSave.PerformLayout();
            this.group_miscOptions.ResumeLayout(false);
            this.group_miscOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_consoleInjector;
        private System.Windows.Forms.GroupBox group_backupSave;
        private System.Windows.Forms.GroupBox group_miscOptions;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_linkedInjector;
        private System.Windows.Forms.Button btn_downloadInjector;
        private System.Windows.Forms.Label lbl_consoleInjector;
        private System.Windows.Forms.CheckBox chk_consoleInjector;
        private System.Windows.Forms.Button btn_injectorPath;
        private System.Windows.Forms.CheckBox chk_backupSave;
        private System.Windows.Forms.Label lbl_linkedSaveDir;
        private System.Windows.Forms.Label lbl_backup;
        private System.Windows.Forms.Button btn_chooseSaveDir;
        private System.Windows.Forms.Button btn_clearBackups;
        private System.Windows.Forms.CheckBox chk_skipCutscenes;
        private System.Windows.Forms.CheckBox chk_closeLauncher;
        private System.Windows.Forms.Button btn_manageBackups;
    }
}