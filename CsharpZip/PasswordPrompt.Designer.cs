namespace CsharpZip
{
    partial class PasswordPrompt
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnPrompt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Geslo:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(69, 13);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(243, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // btnPrompt
            // 
            this.btnPrompt.Location = new System.Drawing.Point(69, 42);
            this.btnPrompt.Name = "btnPrompt";
            this.btnPrompt.Size = new System.Drawing.Size(75, 23);
            this.btnPrompt.TabIndex = 2;
            this.btnPrompt.Text = "Potrdi";
            this.btnPrompt.UseVisualStyleBackColor = true;
            this.btnPrompt.Click += new System.EventHandler(this.BtnPrompt_Click);
            // 
            // PasswordPrompt
            // 
            this.AcceptButton = this.btnPrompt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 77);
            this.Controls.Add(this.btnPrompt);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Name = "PasswordPrompt";
            this.Text = "PasswordPrompt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnPrompt;
    }
}