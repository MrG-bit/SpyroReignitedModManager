namespace SpyroModManager
{
    partial class FormDiscordRP
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
            this.group_discordRP = new System.Windows.Forms.GroupBox();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.lbl_chooseVersion = new System.Windows.Forms.Label();
            this.combo_spyroVersion = new System.Windows.Forms.ComboBox();
            this.chk_useDiscordRP = new System.Windows.Forms.CheckBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.group_discordRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_discordRP
            // 
            this.group_discordRP.Controls.Add(this.lbl_desc);
            this.group_discordRP.Controls.Add(this.lbl_chooseVersion);
            this.group_discordRP.Controls.Add(this.combo_spyroVersion);
            this.group_discordRP.Controls.Add(this.chk_useDiscordRP);
            this.group_discordRP.Location = new System.Drawing.Point(12, 12);
            this.group_discordRP.Name = "group_discordRP";
            this.group_discordRP.Size = new System.Drawing.Size(442, 120);
            this.group_discordRP.TabIndex = 0;
            this.group_discordRP.TabStop = false;
            this.group_discordRP.Text = "Discord Rich Presence";
            // 
            // lbl_desc
            // 
            this.lbl_desc.AutoSize = true;
            this.lbl_desc.Location = new System.Drawing.Point(6, 19);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(347, 13);
            this.lbl_desc.TabIndex = 3;
            this.lbl_desc.Text = "Let the mod manager display information through Discord Rich Presence";
            // 
            // lbl_chooseVersion
            // 
            this.lbl_chooseVersion.AutoSize = true;
            this.lbl_chooseVersion.Location = new System.Drawing.Point(6, 71);
            this.lbl_chooseVersion.Name = "lbl_chooseVersion";
            this.lbl_chooseVersion.Size = new System.Drawing.Size(330, 13);
            this.lbl_chooseVersion.TabIndex = 2;
            this.lbl_chooseVersion.Text = "You can select which game you want Discord to show you\'re playing";
            // 
            // combo_spyroVersion
            // 
            this.combo_spyroVersion.FormattingEnabled = true;
            this.combo_spyroVersion.Items.AddRange(new object[] {
            "Default",
            "Spyro the Dragon",
            "Spyro 2: Ripto\'s Rage",
            "Spyro Year of the Dragon",
            "Custom Level",
            "Multiplayer"});
            this.combo_spyroVersion.Location = new System.Drawing.Point(9, 89);
            this.combo_spyroVersion.Name = "combo_spyroVersion";
            this.combo_spyroVersion.Size = new System.Drawing.Size(180, 21);
            this.combo_spyroVersion.TabIndex = 1;
            // 
            // chk_useDiscordRP
            // 
            this.chk_useDiscordRP.AutoSize = true;
            this.chk_useDiscordRP.Location = new System.Drawing.Point(9, 38);
            this.chk_useDiscordRP.Name = "chk_useDiscordRP";
            this.chk_useDiscordRP.Size = new System.Drawing.Size(157, 17);
            this.chk_useDiscordRP.TabIndex = 0;
            this.chk_useDiscordRP.Text = "Use Discord Rich Presence";
            this.chk_useDiscordRP.UseVisualStyleBackColor = true;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(270, 138);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(89, 23);
            this.btn_confirm.TabIndex = 1;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(365, 138);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(89, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // FormDiscordRP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(461, 169);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.group_discordRP);
            this.Name = "FormDiscordRP";
            this.ShowIcon = false;
            this.Text = "Discord Rich Presence Settings";
            this.group_discordRP.ResumeLayout(false);
            this.group_discordRP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_discordRP;
        private System.Windows.Forms.CheckBox chk_useDiscordRP;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Label lbl_chooseVersion;
        private System.Windows.Forms.ComboBox combo_spyroVersion;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_cancel;
    }
}