namespace CsharpZip
{
    partial class Compress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compress));
            this.grpFileType = new System.Windows.Forms.GroupBox();
            this.optTgz = new System.Windows.Forms.RadioButton();
            this.optTar = new System.Windows.Forms.RadioButton();
            this.optBz = new System.Windows.Forms.RadioButton();
            this.optZip = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblElapsed = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpFileType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFileType
            // 
            this.grpFileType.Controls.Add(this.optTgz);
            this.grpFileType.Controls.Add(this.optTar);
            this.grpFileType.Controls.Add(this.optBz);
            this.grpFileType.Controls.Add(this.optZip);
            this.grpFileType.Location = new System.Drawing.Point(17, 16);
            this.grpFileType.Margin = new System.Windows.Forms.Padding(4);
            this.grpFileType.Name = "grpFileType";
            this.grpFileType.Padding = new System.Windows.Forms.Padding(4);
            this.grpFileType.Size = new System.Drawing.Size(165, 151);
            this.grpFileType.TabIndex = 0;
            this.grpFileType.TabStop = false;
            this.grpFileType.Text = "Vrsta datoteke";
            // 
            // optTgz
            // 
            this.optTgz.AutoSize = true;
            this.optTgz.Location = new System.Drawing.Point(9, 113);
            this.optTgz.Name = "optTgz";
            this.optTgz.Size = new System.Drawing.Size(92, 21);
            this.optTgz.TabIndex = 3;
            this.optTgz.Text = "TAR GZip";
            this.optTgz.UseVisualStyleBackColor = true;
            this.optTgz.CheckedChanged += new System.EventHandler(this.OptTgz_CheckedChanged);
            // 
            // optTar
            // 
            this.optTar.AutoSize = true;
            this.optTar.Location = new System.Drawing.Point(9, 84);
            this.optTar.Margin = new System.Windows.Forms.Padding(4);
            this.optTar.Name = "optTar";
            this.optTar.Size = new System.Drawing.Size(57, 21);
            this.optTar.TabIndex = 2;
            this.optTar.Text = "TAR";
            this.optTar.UseVisualStyleBackColor = true;
            this.optTar.CheckedChanged += new System.EventHandler(this.OptTar_CheckedChanged);
            // 
            // optBz
            // 
            this.optBz.AutoSize = true;
            this.optBz.Location = new System.Drawing.Point(9, 54);
            this.optBz.Margin = new System.Windows.Forms.Padding(4);
            this.optBz.Name = "optBz";
            this.optBz.Size = new System.Drawing.Size(66, 21);
            this.optBz.TabIndex = 1;
            this.optBz.Text = "BZip2";
            this.optBz.UseVisualStyleBackColor = true;
            this.optBz.CheckedChanged += new System.EventHandler(this.OptBz_CheckedChanged);
            // 
            // optZip
            // 
            this.optZip.AutoSize = true;
            this.optZip.Checked = true;
            this.optZip.Location = new System.Drawing.Point(9, 25);
            this.optZip.Margin = new System.Windows.Forms.Padding(4);
            this.optZip.Name = "optZip";
            this.optZip.Size = new System.Drawing.Size(50, 21);
            this.optZip.TabIndex = 0;
            this.optZip.TabStop = true;
            this.optZip.Text = "ZIP";
            this.optZip.UseVisualStyleBackColor = true;
            this.optZip.CheckedChanged += new System.EventHandler(this.OptZip_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEncrypt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPass2);
            this.groupBox2.Controls.Add(this.txtPass);
            this.groupBox2.Location = new System.Drawing.Point(192, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(301, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enkripcija";
            // 
            // chkEncrypt
            // 
            this.chkEncrypt.AutoSize = true;
            this.chkEncrypt.Location = new System.Drawing.Point(17, 25);
            this.chkEncrypt.Margin = new System.Windows.Forms.Padding(4);
            this.chkEncrypt.Name = "chkEncrypt";
            this.chkEncrypt.Size = new System.Drawing.Size(190, 21);
            this.chkEncrypt.TabIndex = 5;
            this.chkEncrypt.Text = "Zaščiti datoteke z geslom";
            this.chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ponovi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Geslo:";
            // 
            // txtPass2
            // 
            this.txtPass2.Location = new System.Drawing.Point(88, 84);
            this.txtPass2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(204, 22);
            this.txtPass2.TabIndex = 2;
            this.txtPass2.UseSystemPasswordChar = true;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(88, 52);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(204, 22);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Shrani v:";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(115, 232);
            this.txtSavePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(377, 22);
            this.txtSavePath.TabIndex = 3;
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(115, 262);
            this.btnCompress.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(100, 28);
            this.btnCompress.TabIndex = 4;
            this.btnCompress.Text = "Stisni";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.BtnCompress_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowse.BackgroundImage")));
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrowse.Location = new System.Drawing.Point(457, 231);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(36, 26);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 200);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ime datoteke:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(115, 200);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(377, 22);
            this.txtFileName.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTime,
            this.lblElapsed});
            this.statusStrip1.Location = new System.Drawing.Point(0, 308);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(509, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(101, 20);
            this.lblTime.Text = "Čas izvajanja: ";
            // 
            // lblElapsed
            // 
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(0, 20);
            // 
            // Compress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 334);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpFileType);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Compress";
            this.Text = "Compress";
            this.grpFileType.ResumeLayout(false);
            this.grpFileType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFileType;
        private System.Windows.Forms.RadioButton optTar;
        private System.Windows.Forms.RadioButton optBz;
        private System.Windows.Forms.RadioButton optZip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.RadioButton optTgz;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsed;
    }
}