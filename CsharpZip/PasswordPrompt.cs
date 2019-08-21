using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpZip
{
    public partial class PasswordPrompt : Form
    {
        public PasswordPrompt()
        {
            InitializeComponent();
        }

        public string pass { get; set; }

        private void BtnPrompt_Click(object sender, EventArgs e)
        {
            pass = txtPassword.Text;
            this.Hide();
        }
    }
}
