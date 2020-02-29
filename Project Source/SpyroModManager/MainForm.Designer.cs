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
            this.list_mods = new System.Windows.Forms.ListBox();
            this.btn_chooseSpyroExe = new System.Windows.Forms.Button();
            this.group_instructions = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_launchOptions = new System.Windows.Forms.Button();
            this.btn_launchSpyro = new System.Windows.Forms.Button();
            this.lbl_StepThree = new System.Windows.Forms.Label();
            this.btn_addMod = new System.Windows.Forms.Button();
            this.lbl_StepTwo = new System.Windows.Forms.Label();
            this.lbl_pathLoaded = new System.Windows.Forms.Label();
            this.lbl_StepOne = new System.Windows.Forms.Label();
            this.btn_showCheatList = new System.Windows.Forms.Button();
            this.btn_Toggle = new System.Windows.Forms.Button();
            this.btn_moveModUp = new System.Windows.Forms.Button();
            this.btn_moveModDown = new System.Windows.Forms.Button();
            this.group_modDetails = new System.Windows.Forms.GroupBox();
            this.pic_modImage = new System.Windows.Forms.PictureBox();
            this.lbl_pakConnected = new System.Windows.Forms.Label();
            this.btn_updateMod = new System.Windows.Forms.Button();
            this.txt_modDescription = new System.Windows.Forms.TextBox();
            this.lbl_modDescription = new System.Windows.Forms.Label();
            this.lbl_modAuthor = new System.Windows.Forms.Label();
            this.lbl_modName = new System.Windows.Forms.Label();
            this.btn_RemoveMod = new System.Windows.Forms.Button();
            this.btn_editMod = new System.Windows.Forms.Button();
            this.chk_toggleDarkTheme = new System.Windows.Forms.CheckBox();
            this.group_footer = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_version = new System.Windows.Forms.Label();
            this.group_settings = new System.Windows.Forms.GroupBox();
            this.btn_levelCodes = new System.Windows.Forms.Button();
            this.lbl_discordRPEnabled = new System.Windows.Forms.Label();
            this.btn_discordSettings = new System.Windows.Forms.Button();
            this.btn_disableAll = new System.Windows.Forms.Button();
            this.group_instructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.group_modDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_modImage)).BeginInit();
            this.group_footer.SuspendLayout();
            this.group_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_mods
            // 
            this.list_mods.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.list_mods.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.85F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_mods.FormattingEnabled = true;
            this.list_mods.ItemHeight = 15;
            this.list_mods.Location = new System.Drawing.Point(12, 12);
            this.list_mods.Name = "list_mods";
            this.list_mods.Size = new System.Drawing.Size(394, 409);
            this.list_mods.TabIndex = 0;
            // 
            // btn_chooseSpyroExe
            // 
            this.btn_chooseSpyroExe.Location = new System.Drawing.Point(83, 28);
            this.btn_chooseSpyroExe.Name = "btn_chooseSpyroExe";
            this.btn_chooseSpyroExe.Size = new System.Drawing.Size(125, 23);
            this.btn_chooseSpyroExe.TabIndex = 1;
            this.btn_chooseSpyroExe.Text = "Choose Spyro.exe";
            this.btn_chooseSpyroExe.UseVisualStyleBackColor = true;
            this.btn_chooseSpyroExe.Click += new System.EventHandler(this.btn_chooseSpyroExe_Click);
            // 
            // group_instructions
            // 
            this.group_instructions.Controls.Add(this.pictureBox1);
            this.group_instructions.Controls.Add(this.btn_launchOptions);
            this.group_instructions.Controls.Add(this.btn_launchSpyro);
            this.group_instructions.Controls.Add(this.lbl_StepThree);
            this.group_instructions.Controls.Add(this.btn_addMod);
            this.group_instructions.Controls.Add(this.lbl_StepTwo);
            this.group_instructions.Controls.Add(this.lbl_pathLoaded);
            this.group_instructions.Controls.Add(this.lbl_StepOne);
            this.group_instructions.Controls.Add(this.btn_chooseSpyroExe);
            this.group_instructions.Location = new System.Drawing.Point(412, 12);
            this.group_instructions.Name = "group_instructions";
            this.group_instructions.Size = new System.Drawing.Size(494, 159);
            this.group_instructions.TabIndex = 2;
            this.group_instructions.TabStop = false;
            this.group_instructions.Text = "Instructions";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SpyroModManager.Properties.Resources.image_spyroTitle;
            this.pictureBox1.InitialImage = global::SpyroModManager.Properties.Resources.image_spyroTitle;
            this.pictureBox1.Location = new System.Drawing.Point(214, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btn_launchOptions
            // 
            this.btn_launchOptions.Location = new System.Drawing.Point(214, 120);
            this.btn_launchOptions.Name = "btn_launchOptions";
            this.btn_launchOptions.Size = new System.Drawing.Size(125, 23);
            this.btn_launchOptions.TabIndex = 7;
            this.btn_launchOptions.Text = "Launch Options";
            this.btn_launchOptions.UseVisualStyleBackColor = true;
            this.btn_launchOptions.Click += new System.EventHandler(this.btn_launchOptions_Click);
            // 
            // btn_launchSpyro
            // 
            this.btn_launchSpyro.Location = new System.Drawing.Point(83, 120);
            this.btn_launchSpyro.Name = "btn_launchSpyro";
            this.btn_launchSpyro.Size = new System.Drawing.Size(125, 23);
            this.btn_launchSpyro.TabIndex = 6;
            this.btn_launchSpyro.Text = "Play Spyro";
            this.btn_launchSpyro.UseVisualStyleBackColor = true;
            this.btn_launchSpyro.Click += new System.EventHandler(this.btn_launchSpyro_Click);
            // 
            // lbl_StepThree
            // 
            this.lbl_StepThree.AutoSize = true;
            this.lbl_StepThree.Location = new System.Drawing.Point(20, 125);
            this.lbl_StepThree.Name = "lbl_StepThree";
            this.lbl_StepThree.Size = new System.Drawing.Size(41, 13);
            this.lbl_StepThree.TabIndex = 5;
            this.lbl_StepThree.Text = "Step 3.";
            // 
            // btn_addMod
            // 
            this.btn_addMod.Location = new System.Drawing.Point(83, 81);
            this.btn_addMod.Name = "btn_addMod";
            this.btn_addMod.Size = new System.Drawing.Size(125, 23);
            this.btn_addMod.TabIndex = 4;
            this.btn_addMod.Text = "Add Mod";
            this.btn_addMod.UseVisualStyleBackColor = true;
            this.btn_addMod.Click += new System.EventHandler(this.btn_addMod_Click);
            // 
            // lbl_StepTwo
            // 
            this.lbl_StepTwo.AutoSize = true;
            this.lbl_StepTwo.Location = new System.Drawing.Point(20, 86);
            this.lbl_StepTwo.Name = "lbl_StepTwo";
            this.lbl_StepTwo.Size = new System.Drawing.Size(41, 13);
            this.lbl_StepTwo.TabIndex = 3;
            this.lbl_StepTwo.Text = "Step 2.";
            // 
            // lbl_pathLoaded
            // 
            this.lbl_pathLoaded.AutoSize = true;
            this.lbl_pathLoaded.ForeColor = System.Drawing.Color.Red;
            this.lbl_pathLoaded.Location = new System.Drawing.Point(80, 54);
            this.lbl_pathLoaded.Name = "lbl_pathLoaded";
            this.lbl_pathLoaded.Size = new System.Drawing.Size(82, 13);
            this.lbl_pathLoaded.TabIndex = 2;
            this.lbl_pathLoaded.Tag = "IgnoreTheme";
            this.lbl_pathLoaded.Text = "Path not loaded";
            // 
            // lbl_StepOne
            // 
            this.lbl_StepOne.AutoSize = true;
            this.lbl_StepOne.Location = new System.Drawing.Point(20, 33);
            this.lbl_StepOne.Name = "lbl_StepOne";
            this.lbl_StepOne.Size = new System.Drawing.Size(41, 13);
            this.lbl_StepOne.TabIndex = 0;
            this.lbl_StepOne.Text = "Step 1.";
            // 
            // btn_showCheatList
            // 
            this.btn_showCheatList.Location = new System.Drawing.Point(263, 14);
            this.btn_showCheatList.Name = "btn_showCheatList";
            this.btn_showCheatList.Size = new System.Drawing.Size(125, 23);
            this.btn_showCheatList.TabIndex = 9;
            this.btn_showCheatList.Text = "Cheat Codes";
            this.btn_showCheatList.UseVisualStyleBackColor = true;
            this.btn_showCheatList.Click += new System.EventHandler(this.btn_showCheatList_Click);
            // 
            // btn_Toggle
            // 
            this.btn_Toggle.Location = new System.Drawing.Point(12, 427);
            this.btn_Toggle.Name = "btn_Toggle";
            this.btn_Toggle.Size = new System.Drawing.Size(121, 23);
            this.btn_Toggle.TabIndex = 5;
            this.btn_Toggle.Text = "Enable";
            this.btn_Toggle.UseVisualStyleBackColor = true;
            this.btn_Toggle.Click += new System.EventHandler(this.btn_Toggle_Click);
            // 
            // btn_moveModUp
            // 
            this.btn_moveModUp.Location = new System.Drawing.Point(149, 427);
            this.btn_moveModUp.Name = "btn_moveModUp";
            this.btn_moveModUp.Size = new System.Drawing.Size(121, 23);
            this.btn_moveModUp.TabIndex = 6;
            this.btn_moveModUp.Text = "Move Up";
            this.btn_moveModUp.UseVisualStyleBackColor = true;
            this.btn_moveModUp.Click += new System.EventHandler(this.btn_moveModUp_Click);
            // 
            // btn_moveModDown
            // 
            this.btn_moveModDown.Location = new System.Drawing.Point(285, 427);
            this.btn_moveModDown.Name = "btn_moveModDown";
            this.btn_moveModDown.Size = new System.Drawing.Size(121, 23);
            this.btn_moveModDown.TabIndex = 7;
            this.btn_moveModDown.Text = "Move Down";
            this.btn_moveModDown.UseVisualStyleBackColor = true;
            this.btn_moveModDown.Click += new System.EventHandler(this.btn_moveModDown_Click);
            // 
            // group_modDetails
            // 
            this.group_modDetails.Controls.Add(this.pic_modImage);
            this.group_modDetails.Controls.Add(this.lbl_pakConnected);
            this.group_modDetails.Controls.Add(this.btn_updateMod);
            this.group_modDetails.Controls.Add(this.txt_modDescription);
            this.group_modDetails.Controls.Add(this.lbl_modDescription);
            this.group_modDetails.Controls.Add(this.lbl_modAuthor);
            this.group_modDetails.Controls.Add(this.lbl_modName);
            this.group_modDetails.Location = new System.Drawing.Point(412, 186);
            this.group_modDetails.Name = "group_modDetails";
            this.group_modDetails.Size = new System.Drawing.Size(494, 307);
            this.group_modDetails.TabIndex = 8;
            this.group_modDetails.TabStop = false;
            this.group_modDetails.Text = "Mod Info";
            // 
            // pic_modImage
            // 
            this.pic_modImage.Image = global::SpyroModManager.Properties.Resources.image_spyroVersion_boxart;
            this.pic_modImage.InitialImage = global::SpyroModManager.Properties.Resources.image_spyroVersion_boxart;
            this.pic_modImage.Location = new System.Drawing.Point(263, 73);
            this.pic_modImage.Name = "pic_modImage";
            this.pic_modImage.Size = new System.Drawing.Size(225, 225);
            this.pic_modImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_modImage.TabIndex = 5;
            this.pic_modImage.TabStop = false;
            // 
            // lbl_pakConnected
            // 
            this.lbl_pakConnected.AutoSize = true;
            this.lbl_pakConnected.ForeColor = System.Drawing.Color.Green;
            this.lbl_pakConnected.Location = new System.Drawing.Point(7, 238);
            this.lbl_pakConnected.Name = "lbl_pakConnected";
            this.lbl_pakConnected.Size = new System.Drawing.Size(111, 13);
            this.lbl_pakConnected.TabIndex = 4;
            this.lbl_pakConnected.Tag = "IgnoreTheme";
            this.lbl_pakConnected.Text = "Connected to .pak file";
            // 
            // btn_updateMod
            // 
            this.btn_updateMod.Location = new System.Drawing.Point(56, 275);
            this.btn_updateMod.Name = "btn_updateMod";
            this.btn_updateMod.Size = new System.Drawing.Size(139, 23);
            this.btn_updateMod.TabIndex = 11;
            this.btn_updateMod.Text = "Update .pak File";
            this.btn_updateMod.UseVisualStyleBackColor = true;
            this.btn_updateMod.Click += new System.EventHandler(this.btn_updateMod_Click);
            // 
            // txt_modDescription
            // 
            this.txt_modDescription.Location = new System.Drawing.Point(10, 73);
            this.txt_modDescription.Multiline = true;
            this.txt_modDescription.Name = "txt_modDescription";
            this.txt_modDescription.ReadOnly = true;
            this.txt_modDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_modDescription.Size = new System.Drawing.Size(247, 162);
            this.txt_modDescription.TabIndex = 3;
            // 
            // lbl_modDescription
            // 
            this.lbl_modDescription.AutoSize = true;
            this.lbl_modDescription.Location = new System.Drawing.Point(7, 57);
            this.lbl_modDescription.Name = "lbl_modDescription";
            this.lbl_modDescription.Size = new System.Drawing.Size(63, 13);
            this.lbl_modDescription.TabIndex = 2;
            this.lbl_modDescription.Text = "Description:";
            // 
            // lbl_modAuthor
            // 
            this.lbl_modAuthor.AutoSize = true;
            this.lbl_modAuthor.Location = new System.Drawing.Point(7, 38);
            this.lbl_modAuthor.Name = "lbl_modAuthor";
            this.lbl_modAuthor.Size = new System.Drawing.Size(41, 13);
            this.lbl_modAuthor.TabIndex = 1;
            this.lbl_modAuthor.Text = "Author:";
            // 
            // lbl_modName
            // 
            this.lbl_modName.AutoSize = true;
            this.lbl_modName.Location = new System.Drawing.Point(7, 20);
            this.lbl_modName.Name = "lbl_modName";
            this.lbl_modName.Size = new System.Drawing.Size(38, 13);
            this.lbl_modName.TabIndex = 0;
            this.lbl_modName.Text = "Name:";
            // 
            // btn_RemoveMod
            // 
            this.btn_RemoveMod.Location = new System.Drawing.Point(285, 456);
            this.btn_RemoveMod.Name = "btn_RemoveMod";
            this.btn_RemoveMod.Size = new System.Drawing.Size(121, 23);
            this.btn_RemoveMod.TabIndex = 9;
            this.btn_RemoveMod.Text = "Remove";
            this.btn_RemoveMod.UseVisualStyleBackColor = true;
            this.btn_RemoveMod.Click += new System.EventHandler(this.btn_RemoveMod_Click);
            // 
            // btn_editMod
            // 
            this.btn_editMod.Location = new System.Drawing.Point(149, 456);
            this.btn_editMod.Name = "btn_editMod";
            this.btn_editMod.Size = new System.Drawing.Size(121, 23);
            this.btn_editMod.TabIndex = 10;
            this.btn_editMod.Text = "Edit";
            this.btn_editMod.UseVisualStyleBackColor = true;
            this.btn_editMod.Click += new System.EventHandler(this.btn_editMod_Click);
            // 
            // chk_toggleDarkTheme
            // 
            this.chk_toggleDarkTheme.AutoSize = true;
            this.chk_toggleDarkTheme.Location = new System.Drawing.Point(6, 20);
            this.chk_toggleDarkTheme.Name = "chk_toggleDarkTheme";
            this.chk_toggleDarkTheme.Size = new System.Drawing.Size(81, 17);
            this.chk_toggleDarkTheme.TabIndex = 12;
            this.chk_toggleDarkTheme.Text = "Dark theme";
            this.chk_toggleDarkTheme.UseVisualStyleBackColor = true;
            this.chk_toggleDarkTheme.CheckedChanged += new System.EventHandler(this.chk_toggleDarkTheme_CheckedChanged);
            // 
            // group_footer
            // 
            this.group_footer.Controls.Add(this.label1);
            this.group_footer.Controls.Add(this.lbl_version);
            this.group_footer.Location = new System.Drawing.Point(412, 508);
            this.group_footer.Name = "group_footer";
            this.group_footer.Size = new System.Drawing.Size(494, 120);
            this.group_footer.TabIndex = 13;
            this.group_footer.TabStop = false;
            this.group_footer.Text = "Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(414, 101);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(48, 13);
            this.lbl_version.TabIndex = 13;
            this.lbl_version.Text = "Version: ";
            // 
            // group_settings
            // 
            this.group_settings.Controls.Add(this.btn_levelCodes);
            this.group_settings.Controls.Add(this.btn_showCheatList);
            this.group_settings.Controls.Add(this.lbl_discordRPEnabled);
            this.group_settings.Controls.Add(this.btn_discordSettings);
            this.group_settings.Controls.Add(this.chk_toggleDarkTheme);
            this.group_settings.Location = new System.Drawing.Point(12, 508);
            this.group_settings.Name = "group_settings";
            this.group_settings.Size = new System.Drawing.Size(394, 120);
            this.group_settings.TabIndex = 14;
            this.group_settings.TabStop = false;
            this.group_settings.Text = "Settings";
            // 
            // btn_levelCodes
            // 
            this.btn_levelCodes.Location = new System.Drawing.Point(132, 14);
            this.btn_levelCodes.Name = "btn_levelCodes";
            this.btn_levelCodes.Size = new System.Drawing.Size(125, 23);
            this.btn_levelCodes.TabIndex = 17;
            this.btn_levelCodes.Text = "Level Names";
            this.btn_levelCodes.UseVisualStyleBackColor = true;
            this.btn_levelCodes.Click += new System.EventHandler(this.btn_levelCodes_Click);
            // 
            // lbl_discordRPEnabled
            // 
            this.lbl_discordRPEnabled.AutoSize = true;
            this.lbl_discordRPEnabled.ForeColor = System.Drawing.Color.Red;
            this.lbl_discordRPEnabled.Location = new System.Drawing.Point(189, 96);
            this.lbl_discordRPEnabled.Name = "lbl_discordRPEnabled";
            this.lbl_discordRPEnabled.Size = new System.Drawing.Size(168, 13);
            this.lbl_discordRPEnabled.TabIndex = 16;
            this.lbl_discordRPEnabled.Tag = "IgnoreTheme";
            this.lbl_discordRPEnabled.Text = "Discord Rich Presence is disabled";
            // 
            // btn_discordSettings
            // 
            this.btn_discordSettings.Location = new System.Drawing.Point(6, 91);
            this.btn_discordSettings.Name = "btn_discordSettings";
            this.btn_discordSettings.Size = new System.Drawing.Size(177, 23);
            this.btn_discordSettings.TabIndex = 15;
            this.btn_discordSettings.Text = "Discord Rich Presence Settings";
            this.btn_discordSettings.UseVisualStyleBackColor = true;
            this.btn_discordSettings.Click += new System.EventHandler(this.btn_discordSettings_Click);
            // 
            // btn_disableAll
            // 
            this.btn_disableAll.Location = new System.Drawing.Point(12, 456);
            this.btn_disableAll.Name = "btn_disableAll";
            this.btn_disableAll.Size = new System.Drawing.Size(121, 23);
            this.btn_disableAll.TabIndex = 15;
            this.btn_disableAll.Text = "Disable All";
            this.btn_disableAll.UseVisualStyleBackColor = true;
            this.btn_disableAll.Click += new System.EventHandler(this.btn_disableAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 640);
            this.Controls.Add(this.btn_disableAll);
            this.Controls.Add(this.group_settings);
            this.Controls.Add(this.group_footer);
            this.Controls.Add(this.btn_editMod);
            this.Controls.Add(this.btn_RemoveMod);
            this.Controls.Add(this.group_modDetails);
            this.Controls.Add(this.btn_moveModDown);
            this.Controls.Add(this.btn_moveModUp);
            this.Controls.Add(this.btn_Toggle);
            this.Controls.Add(this.group_instructions);
            this.Controls.Add(this.list_mods);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Spyro Reignited Mod Manager";
            this.group_instructions.ResumeLayout(false);
            this.group_instructions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.group_modDetails.ResumeLayout(false);
            this.group_modDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_modImage)).EndInit();
            this.group_footer.ResumeLayout(false);
            this.group_footer.PerformLayout();
            this.group_settings.ResumeLayout(false);
            this.group_settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list_mods;
        private System.Windows.Forms.Button btn_chooseSpyroExe;
        private System.Windows.Forms.GroupBox group_instructions;
        private System.Windows.Forms.Label lbl_pathLoaded;
        private System.Windows.Forms.Label lbl_StepOne;
        private System.Windows.Forms.Label lbl_StepTwo;
        private System.Windows.Forms.Button btn_Toggle;
        private System.Windows.Forms.Button btn_moveModUp;
        private System.Windows.Forms.Button btn_moveModDown;
        private System.Windows.Forms.GroupBox group_modDetails;
        private System.Windows.Forms.TextBox txt_modDescription;
        private System.Windows.Forms.Label lbl_modDescription;
        private System.Windows.Forms.Label lbl_modAuthor;
        private System.Windows.Forms.Label lbl_modName;
        private System.Windows.Forms.Label lbl_pakConnected;
        private System.Windows.Forms.Button btn_RemoveMod;
        private System.Windows.Forms.Button btn_editMod;
        private System.Windows.Forms.Button btn_updateMod;
        private System.Windows.Forms.Button btn_addMod;
        private System.Windows.Forms.CheckBox chk_toggleDarkTheme;
        private System.Windows.Forms.Button btn_launchOptions;
        private System.Windows.Forms.Button btn_launchSpyro;
        private System.Windows.Forms.Label lbl_StepThree;
        private System.Windows.Forms.GroupBox group_footer;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.PictureBox pic_modImage;
        private System.Windows.Forms.GroupBox group_settings;
        private System.Windows.Forms.Label lbl_discordRPEnabled;
        private System.Windows.Forms.Button btn_discordSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_disableAll;
        private System.Windows.Forms.Button btn_showCheatList;
        private System.Windows.Forms.Button btn_levelCodes;
    }
}

