namespace SpyroModManager
{
    partial class ModForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModForm));
            this.lblTop = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtModDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModCreator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblShareInfo = new System.Windows.Forms.Label();
            this.btnShareableCopy = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxDeletePakFile = new System.Windows.Forms.CheckBox();
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            this.btnChooseThumbnail = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupDeletePak = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.groupDeletePak.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(6, 25);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(240, 13);
            this.lblTop.TabIndex = 0;
            this.lblTop.Text = "You can change the details about your mod here.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnChooseThumbnail);
            this.groupBox1.Controls.Add(this.picThumbnail);
            this.groupBox1.Controls.Add(this.txtModDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtModCreator);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtModName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTop);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 223);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mod Details";
            // 
            // txtModDescription
            // 
            this.txtModDescription.AcceptsReturn = true;
            this.txtModDescription.Location = new System.Drawing.Point(6, 125);
            this.txtModDescription.Multiline = true;
            this.txtModDescription.Name = "txtModDescription";
            this.txtModDescription.Size = new System.Drawing.Size(263, 82);
            this.txtModDescription.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mod Description:";
            // 
            // txtModCreator
            // 
            this.txtModCreator.Location = new System.Drawing.Point(74, 77);
            this.txtModCreator.Name = "txtModCreator";
            this.txtModCreator.Size = new System.Drawing.Size(195, 20);
            this.txtModCreator.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Creator:";
            // 
            // txtModName
            // 
            this.txtModName.Location = new System.Drawing.Point(74, 49);
            this.txtModName.Name = "txtModName";
            this.txtModName.Size = new System.Drawing.Size(195, 20);
            this.txtModName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mod Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblShareInfo);
            this.groupBox2.Controls.Add(this.btnShareableCopy);
            this.groupBox2.Location = new System.Drawing.Point(12, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 147);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Shareable Copy";
            // 
            // lblShareInfo
            // 
            this.lblShareInfo.AutoSize = true;
            this.lblShareInfo.Location = new System.Drawing.Point(6, 27);
            this.lblShareInfo.Name = "lblShareInfo";
            this.lblShareInfo.Size = new System.Drawing.Size(417, 52);
            this.lblShareInfo.TabIndex = 1;
            this.lblShareInfo.Text = resources.GetString("lblShareInfo.Text");
            // 
            // btnShareableCopy
            // 
            this.btnShareableCopy.Location = new System.Drawing.Point(326, 110);
            this.btnShareableCopy.Name = "btnShareableCopy";
            this.btnShareableCopy.Size = new System.Drawing.Size(149, 23);
            this.btnShareableCopy.TabIndex = 0;
            this.btnShareableCopy.Text = "Create Shareable Copy";
            this.btnShareableCopy.UseVisualStyleBackColor = true;
            this.btnShareableCopy.Click += new System.EventHandler(this.btnShareableCopy_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(244, 553);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(115, 23);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(372, 553);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxDeletePakFile
            // 
            this.checkBoxDeletePakFile.AutoSize = true;
            this.checkBoxDeletePakFile.Location = new System.Drawing.Point(9, 72);
            this.checkBoxDeletePakFile.Name = "checkBoxDeletePakFile";
            this.checkBoxDeletePakFile.Size = new System.Drawing.Size(133, 17);
            this.checkBoxDeletePakFile.TabIndex = 5;
            this.checkBoxDeletePakFile.Text = "Delete original .pak file";
            this.checkBoxDeletePakFile.UseVisualStyleBackColor = true;
            // 
            // picThumbnail
            // 
            this.picThumbnail.Image = global::SpyroModManager.Properties.Resources.ReignitedTitle;
            this.picThumbnail.Location = new System.Drawing.Point(275, 49);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(200, 124);
            this.picThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picThumbnail.TabIndex = 7;
            this.picThumbnail.TabStop = false;
            // 
            // btnChooseThumbnail
            // 
            this.btnChooseThumbnail.Location = new System.Drawing.Point(275, 184);
            this.btnChooseThumbnail.Name = "btnChooseThumbnail";
            this.btnChooseThumbnail.Size = new System.Drawing.Size(200, 23);
            this.btnChooseThumbnail.TabIndex = 8;
            this.btnChooseThumbnail.Text = "Choose Thumbnail";
            this.btnChooseThumbnail.UseVisualStyleBackColor = true;
            this.btnChooseThumbnail.Click += new System.EventHandler(this.btnChooseThumbnail_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(254, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "*";
            // 
            // groupDeletePak
            // 
            this.groupDeletePak.Controls.Add(this.label5);
            this.groupDeletePak.Controls.Add(this.checkBoxDeletePakFile);
            this.groupDeletePak.Location = new System.Drawing.Point(12, 419);
            this.groupDeletePak.Name = "groupDeletePak";
            this.groupDeletePak.Size = new System.Drawing.Size(481, 97);
            this.groupDeletePak.TabIndex = 6;
            this.groupDeletePak.TabStop = false;
            this.groupDeletePak.Text = "Delete Original Pak";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(371, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = "The selected .pak file will no longer be needed once you\'ve created the mod.\r\nThe" +
    "refore, it can be deleted to reduce confusion.";
            // 
            // ModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 592);
            this.Controls.Add(this.groupDeletePak);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModForm";
            this.Text = "ModForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.groupDeletePak.ResumeLayout(false);
            this.groupDeletePak.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblShareInfo;
        private System.Windows.Forms.Button btnShareableCopy;
        private System.Windows.Forms.TextBox txtModName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModCreator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxDeletePakFile;
        private System.Windows.Forms.Button btnChooseThumbnail;
        private System.Windows.Forms.PictureBox picThumbnail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupDeletePak;
        private System.Windows.Forms.Label label5;
    }
}