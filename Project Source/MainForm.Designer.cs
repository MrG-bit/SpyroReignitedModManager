namespace SpyroModManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnEditMod = new System.Windows.Forms.Button();
            this.btnRemoveMod = new System.Windows.Forms.Button();
            this.btnAddMod = new System.Windows.Forms.Button();
            this.lblSpyroPath = new System.Windows.Forms.Label();
            this.btnSpyroPath = new System.Windows.Forms.Button();
            this.btnDeactivateAll = new System.Windows.Forms.Button();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.lblPathLoaded = new System.Windows.Forms.Label();
            this.listMods = new System.Windows.Forms.ListBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkSkipIntro = new System.Windows.Forms.CheckBox();
            this.checkVanilla = new System.Windows.Forms.CheckBox();
            this.checkConsoleInjector = new System.Windows.Forms.CheckBox();
            this.btnLaunchSpyro = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtModDescription = new System.Windows.Forms.TextBox();
            this.lblModFileName = new System.Windows.Forms.Label();
            this.lblModCreator = new System.Windows.Forms.Label();
            this.lblModOrigName = new System.Windows.Forms.Label();
            this.checkBackupSave = new System.Windows.Forms.CheckBox();
            this.grpInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(120, 386);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(96, 23);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(227, 386);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(96, 23);
            this.btnMoveDown.TabIndex = 2;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(12, 386);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(96, 23);
            this.btnToggle.TabIndex = 3;
            this.btnToggle.Text = "Enable";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnEditMod
            // 
            this.btnEditMod.Location = new System.Drawing.Point(120, 413);
            this.btnEditMod.Name = "btnEditMod";
            this.btnEditMod.Size = new System.Drawing.Size(96, 23);
            this.btnEditMod.TabIndex = 4;
            this.btnEditMod.Text = "Edit Mod";
            this.btnEditMod.UseVisualStyleBackColor = true;
            this.btnEditMod.Click += new System.EventHandler(this.btnEditMod_Click);
            // 
            // btnRemoveMod
            // 
            this.btnRemoveMod.Location = new System.Drawing.Point(227, 413);
            this.btnRemoveMod.Name = "btnRemoveMod";
            this.btnRemoveMod.Size = new System.Drawing.Size(96, 23);
            this.btnRemoveMod.TabIndex = 5;
            this.btnRemoveMod.Text = "Remove";
            this.btnRemoveMod.UseVisualStyleBackColor = true;
            this.btnRemoveMod.Click += new System.EventHandler(this.btnRemoveMod_Click);
            // 
            // btnAddMod
            // 
            this.btnAddMod.Location = new System.Drawing.Point(62, 80);
            this.btnAddMod.Name = "btnAddMod";
            this.btnAddMod.Size = new System.Drawing.Size(92, 23);
            this.btnAddMod.TabIndex = 6;
            this.btnAddMod.Text = "Add Mod(s)";
            this.btnAddMod.UseVisualStyleBackColor = true;
            this.btnAddMod.Click += new System.EventHandler(this.btnAddMod_Click);
            // 
            // lblSpyroPath
            // 
            this.lblSpyroPath.AutoSize = true;
            this.lblSpyroPath.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblSpyroPath.Location = new System.Drawing.Point(6, 76);
            this.lblSpyroPath.Name = "lblSpyroPath";
            this.lblSpyroPath.Size = new System.Drawing.Size(141, 13);
            this.lblSpyroPath.TabIndex = 7;
            this.lblSpyroPath.Text = "Spyro.exe: No path selected";
            // 
            // btnSpyroPath
            // 
            this.btnSpyroPath.Location = new System.Drawing.Point(62, 29);
            this.btnSpyroPath.Name = "btnSpyroPath";
            this.btnSpyroPath.Size = new System.Drawing.Size(125, 23);
            this.btnSpyroPath.TabIndex = 8;
            this.btnSpyroPath.Text = "Choose Spyro.exe";
            this.btnSpyroPath.UseVisualStyleBackColor = true;
            this.btnSpyroPath.Click += new System.EventHandler(this.btnSpyroPath_Click);
            // 
            // btnDeactivateAll
            // 
            this.btnDeactivateAll.Location = new System.Drawing.Point(12, 413);
            this.btnDeactivateAll.Name = "btnDeactivateAll";
            this.btnDeactivateAll.Size = new System.Drawing.Size(96, 23);
            this.btnDeactivateAll.TabIndex = 9;
            this.btnDeactivateAll.Text = "Deactivate All";
            this.btnDeactivateAll.UseVisualStyleBackColor = true;
            this.btnDeactivateAll.Click += new System.EventHandler(this.btnDeactivateAll_Click);
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Location = new System.Drawing.Point(15, 34);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(41, 13);
            this.lblStep1.TabIndex = 10;
            this.lblStep1.Text = "Step 1.";
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Location = new System.Drawing.Point(15, 85);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(41, 13);
            this.lblStep2.TabIndex = 11;
            this.lblStep2.Text = "Step 2.";
            // 
            // lblStep3
            // 
            this.lblStep3.AutoSize = true;
            this.lblStep3.Location = new System.Drawing.Point(15, 126);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(41, 13);
            this.lblStep3.TabIndex = 12;
            this.lblStep3.Text = "Step 3.";
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblSavePath.Location = new System.Drawing.Point(6, 89);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(148, 13);
            this.lblSavePath.TabIndex = 13;
            this.lblSavePath.Text = "Save folder: No path selected";
            // 
            // lblPathLoaded
            // 
            this.lblPathLoaded.AutoSize = true;
            this.lblPathLoaded.ForeColor = System.Drawing.Color.Red;
            this.lblPathLoaded.Location = new System.Drawing.Point(59, 55);
            this.lblPathLoaded.Name = "lblPathLoaded";
            this.lblPathLoaded.Size = new System.Drawing.Size(90, 13);
            this.lblPathLoaded.TabIndex = 14;
            this.lblPathLoaded.Text = "Path not selected";
            // 
            // listMods
            // 
            this.listMods.FormattingEnabled = true;
            this.listMods.Location = new System.Drawing.Point(12, 12);
            this.listMods.Name = "listMods";
            this.listMods.Size = new System.Drawing.Size(311, 368);
            this.listMods.TabIndex = 15;
            this.listMods.SelectedIndexChanged += new System.EventHandler(this.listMods_SelectedIndexChanged);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblVersion);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.lblSpyroPath);
            this.grpInfo.Controls.Add(this.lblSavePath);
            this.grpInfo.Location = new System.Drawing.Point(12, 455);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(741, 108);
            this.grpInfo.TabIndex = 16;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Information";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(659, 89);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersion.Size = new System.Drawing.Size(48, 13);
            this.lblVersion.TabIndex = 19;
            this.lblVersion.Text = "Version: ";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 39);
            this.label1.TabIndex = 18;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBackupSave);
            this.groupBox1.Controls.Add(this.checkSkipIntro);
            this.groupBox1.Controls.Add(this.checkVanilla);
            this.groupBox1.Controls.Add(this.checkConsoleInjector);
            this.groupBox1.Controls.Add(this.btnLaunchSpyro);
            this.groupBox1.Controls.Add(this.btnAddMod);
            this.groupBox1.Controls.Add(this.btnSpyroPath);
            this.groupBox1.Controls.Add(this.lblStep1);
            this.groupBox1.Controls.Add(this.lblStep2);
            this.groupBox1.Controls.Add(this.lblStep3);
            this.groupBox1.Controls.Add(this.lblPathLoaded);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(330, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 175);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instructions";
            // 
            // checkSkipIntro
            // 
            this.checkSkipIntro.AutoSize = true;
            this.checkSkipIntro.Location = new System.Drawing.Point(171, 149);
            this.checkSkipIntro.Name = "checkSkipIntro";
            this.checkSkipIntro.Size = new System.Drawing.Size(115, 17);
            this.checkSkipIntro.TabIndex = 21;
            this.checkSkipIntro.Text = "Skip Intro Bumpers";
            this.checkSkipIntro.UseVisualStyleBackColor = true;
            this.checkSkipIntro.CheckedChanged += new System.EventHandler(this.checkSkipIntro_CheckedChanged);
            // 
            // checkVanilla
            // 
            this.checkVanilla.AutoSize = true;
            this.checkVanilla.Location = new System.Drawing.Point(314, 125);
            this.checkVanilla.Name = "checkVanilla";
            this.checkVanilla.Size = new System.Drawing.Size(92, 17);
            this.checkVanilla.TabIndex = 20;
            this.checkVanilla.Text = "Without Mods";
            this.checkVanilla.UseVisualStyleBackColor = true;
            this.checkVanilla.CheckedChanged += new System.EventHandler(this.checkVanilla_CheckedChanged);
            // 
            // checkConsoleInjector
            // 
            this.checkConsoleInjector.AutoSize = true;
            this.checkConsoleInjector.Location = new System.Drawing.Point(171, 125);
            this.checkConsoleInjector.Name = "checkConsoleInjector";
            this.checkConsoleInjector.Size = new System.Drawing.Size(127, 17);
            this.checkConsoleInjector.TabIndex = 19;
            this.checkConsoleInjector.Text = "With Console Injector";
            this.checkConsoleInjector.UseVisualStyleBackColor = true;
            this.checkConsoleInjector.CheckedChanged += new System.EventHandler(this.checkConsoleInjector_CheckedChanged);
            // 
            // btnLaunchSpyro
            // 
            this.btnLaunchSpyro.Location = new System.Drawing.Point(62, 121);
            this.btnLaunchSpyro.Name = "btnLaunchSpyro";
            this.btnLaunchSpyro.Size = new System.Drawing.Size(91, 23);
            this.btnLaunchSpyro.TabIndex = 18;
            this.btnLaunchSpyro.Text = "Launch Spyro";
            this.btnLaunchSpyro.UseVisualStyleBackColor = true;
            this.btnLaunchSpyro.Click += new System.EventHandler(this.btnLaunchSpyro_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SpyroModManager.Properties.Resources.ReignitedTitle;
            this.pictureBox1.Location = new System.Drawing.Point(239, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picThumbnail);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lblModFileName);
            this.groupBox2.Controls.Add(this.lblModCreator);
            this.groupBox2.Controls.Add(this.lblModOrigName);
            this.groupBox2.Location = new System.Drawing.Point(329, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 221);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mod Information";
            // 
            // picThumbnail
            // 
            this.picThumbnail.ErrorImage = null;
            this.picThumbnail.Image = global::SpyroModManager.Properties.Resources.SpyroStand;
            this.picThumbnail.Location = new System.Drawing.Point(240, 50);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(179, 144);
            this.picThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picThumbnail.TabIndex = 3;
            this.picThumbnail.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtModDescription);
            this.groupBox3.Location = new System.Drawing.Point(6, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 130);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Description";
            // 
            // txtModDescription
            // 
            this.txtModDescription.AcceptsReturn = true;
            this.txtModDescription.AcceptsTab = true;
            this.txtModDescription.Location = new System.Drawing.Point(6, 19);
            this.txtModDescription.Multiline = true;
            this.txtModDescription.Name = "txtModDescription";
            this.txtModDescription.ReadOnly = true;
            this.txtModDescription.Size = new System.Drawing.Size(211, 105);
            this.txtModDescription.TabIndex = 2;
            // 
            // lblModFileName
            // 
            this.lblModFileName.AutoSize = true;
            this.lblModFileName.Location = new System.Drawing.Point(3, 200);
            this.lblModFileName.Name = "lblModFileName";
            this.lblModFileName.Size = new System.Drawing.Size(52, 13);
            this.lblModFileName.TabIndex = 4;
            this.lblModFileName.Text = "Filename:";
            // 
            // lblModCreator
            // 
            this.lblModCreator.AutoSize = true;
            this.lblModCreator.Location = new System.Drawing.Point(4, 40);
            this.lblModCreator.Name = "lblModCreator";
            this.lblModCreator.Size = new System.Drawing.Size(61, 13);
            this.lblModCreator.TabIndex = 1;
            this.lblModCreator.Text = "Created by:";
            // 
            // lblModOrigName
            // 
            this.lblModOrigName.AutoSize = true;
            this.lblModOrigName.Location = new System.Drawing.Point(3, 18);
            this.lblModOrigName.Name = "lblModOrigName";
            this.lblModOrigName.Size = new System.Drawing.Size(38, 13);
            this.lblModOrigName.TabIndex = 0;
            this.lblModOrigName.Text = "Name:";
            // 
            // checkBackupSave
            // 
            this.checkBackupSave.AutoSize = true;
            this.checkBackupSave.Location = new System.Drawing.Point(314, 149);
            this.checkBackupSave.Name = "checkBackupSave";
            this.checkBackupSave.Size = new System.Drawing.Size(91, 17);
            this.checkBackupSave.TabIndex = 22;
            this.checkBackupSave.Text = "Backup Save";
            this.checkBackupSave.UseVisualStyleBackColor = true;
            this.checkBackupSave.CheckedChanged += new System.EventHandler(this.checkBackupSave_CheckedChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 575);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.listMods);
            this.Controls.Add(this.btnEditMod);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnDeactivateAll);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.btnRemoveMod);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnEditMod;
        private System.Windows.Forms.Button btnRemoveMod;
        private System.Windows.Forms.Button btnAddMod;
        private System.Windows.Forms.Label lblSpyroPath;
        private System.Windows.Forms.Button btnSpyroPath;
        private System.Windows.Forms.Button btnDeactivateAll;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.Label lblPathLoaded;
        private System.Windows.Forms.ListBox listMods;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtModDescription;
        private System.Windows.Forms.Label lblModCreator;
        private System.Windows.Forms.Label lblModOrigName;
        private System.Windows.Forms.Label lblModFileName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLaunchSpyro;
        private System.Windows.Forms.CheckBox checkVanilla;
        private System.Windows.Forms.CheckBox checkConsoleInjector;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picThumbnail;
        private System.Windows.Forms.CheckBox checkSkipIntro;
        private System.Windows.Forms.CheckBox checkBackupSave;
    }
}

