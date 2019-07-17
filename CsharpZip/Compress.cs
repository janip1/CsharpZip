﻿using System;
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
using System.IO;
using SharpCompress.Common;

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
            var filesList = Form1.filesList;
            string savePath = txtSavePath.Text;
            if (optZip.Checked)
            {
                //Compress Zip
                using (var zip = File.OpenWrite(savePath + ".zip"))
                using (var zipWriter = WriterFactory.Open(zip, ArchiveType.Zip, CompressionType.Deflate))
                {
                    foreach (var filePath in filesList)
                    {
                        zipWriter.Write(Path.GetFileName(filePath), filePath);
                    }
                }

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
