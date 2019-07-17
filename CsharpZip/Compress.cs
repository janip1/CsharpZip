using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpCompress.Compressors;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Writers;
using System.IO.Compression;

namespace CsharpZip
{
    public partial class Compress : Form
    {
        public Compress()
        {
            InitializeComponent();
          
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog getPath = new FolderBrowserDialog())
            {
                if (getPath.ShowDialog() == DialogResult.OK)
                {
                    txtSavePath.Text = getPath.SelectedPath;
                }
            }
        }

        private void BtnCompress_Click(object sender, EventArgs e)
        {
            string savePath = txtSavePath.Text;
            if (optZip.Checked)
            {
                //Compress Zip
                
            }
            else if (optRar.Checked)
            {
                //Compress RAR
            }
            else if (optTar.Checked)
            {
                //Compress TAR
            }
        }
    }
}
