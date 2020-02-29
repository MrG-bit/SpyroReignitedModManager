namespace SpyroModManager
{
    partial class FormCheatCodeList
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
            this.combo_platform = new System.Windows.Forms.ComboBox();
            this.lbl_platform = new System.Windows.Forms.Label();
            this.list_codes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txt_cheatCode = new System.Windows.Forms.TextBox();
            this.pic_cheatImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cheatImage)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_platform
            // 
            this.combo_platform.FormattingEnabled = true;
            this.combo_platform.Items.AddRange(new object[] {
            "PS4",
            "Xbox",
            "Keyboard"});
            this.combo_platform.Location = new System.Drawing.Point(693, 15);
            this.combo_platform.Name = "combo_platform";
            this.combo_platform.Size = new System.Drawing.Size(121, 21);
            this.combo_platform.TabIndex = 1;
            this.combo_platform.SelectedIndexChanged += new System.EventHandler(this.Combo_Platform_SelectedIndexChanged);
            // 
            // lbl_platform
            // 
            this.lbl_platform.AutoSize = true;
            this.lbl_platform.Location = new System.Drawing.Point(610, 18);
            this.lbl_platform.Name = "lbl_platform";
            this.lbl_platform.Size = new System.Drawing.Size(77, 13);
            this.lbl_platform.TabIndex = 2;
            this.lbl_platform.Text = "Controller type:";
            // 
            // list_codes
            // 
            this.list_codes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.list_codes.FullRowSelect = true;
            this.list_codes.GridLines = true;
            this.list_codes.HideSelection = false;
            this.list_codes.Location = new System.Drawing.Point(12, 12);
            this.list_codes.MultiSelect = false;
            this.list_codes.Name = "list_codes";
            this.list_codes.Size = new System.Drawing.Size(586, 312);
            this.list_codes.TabIndex = 5;
            this.list_codes.UseCompatibleStateImageBehavior = false;
            this.list_codes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Cheat";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Code";
            this.columnHeader2.Width = 462;
            // 
            // txt_cheatCode
            // 
            this.txt_cheatCode.Location = new System.Drawing.Point(613, 54);
            this.txt_cheatCode.Multiline = true;
            this.txt_cheatCode.Name = "txt_cheatCode";
            this.txt_cheatCode.ReadOnly = true;
            this.txt_cheatCode.Size = new System.Drawing.Size(199, 50);
            this.txt_cheatCode.TabIndex = 6;
            this.txt_cheatCode.Text = "Select a cheat for more info.";
            // 
            // pic_cheatImage
            // 
            this.pic_cheatImage.ErrorImage = global::SpyroModManager.Properties.Resources.image_spyroTitle;
            this.pic_cheatImage.Image = global::SpyroModManager.Properties.Resources.image_spyroTitle;
            this.pic_cheatImage.InitialImage = global::SpyroModManager.Properties.Resources.image_spyroTitle;
            this.pic_cheatImage.Location = new System.Drawing.Point(613, 123);
            this.pic_cheatImage.Name = "pic_cheatImage";
            this.pic_cheatImage.Size = new System.Drawing.Size(201, 201);
            this.pic_cheatImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_cheatImage.TabIndex = 3;
            this.pic_cheatImage.TabStop = false;
            // 
            // FormCheatCodeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 336);
            this.Controls.Add(this.txt_cheatCode);
            this.Controls.Add(this.list_codes);
            this.Controls.Add(this.pic_cheatImage);
            this.Controls.Add(this.lbl_platform);
            this.Controls.Add(this.combo_platform);
            this.Name = "FormCheatCodeList";
            this.ShowIcon = false;
            this.Text = "Cheat Code List";
            ((System.ComponentModel.ISupportInitialize)(this.pic_cheatImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox combo_platform;
        private System.Windows.Forms.Label lbl_platform;
        private System.Windows.Forms.PictureBox pic_cheatImage;
        private System.Windows.Forms.ListView list_codes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txt_cheatCode;
    }
}