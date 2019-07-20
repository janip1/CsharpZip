using Ionic.Zip;
using System;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;

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
            string fileName = savePath + @"\" + txtFileName.Text;
            if (optZip.Checked == true)
            {
                if (chkEncrypt.Checked == true)
                {
                    if (txtPass.Text == txtPass2.Text)
                    {
                        //do encrypt
                        using (ZipFile zip = new ZipFile())
                        {
                            zip.Password = txtPass2.Text;
                            foreach (string file in filesList)
                            {
                                zip.AddFile(file, "");
                            }
                            zip.Save(fileName);
                        }
                    }
                }
               
                else
                {
                    //Compress Zip
                    using (ZipFile zip = new ZipFile())
                    {
                        foreach(string file in filesList)
                        {
                            zip.AddFile(file, "");
                        }
                        zip.Save(fileName + ".zip");
                    }
                }
            }
            else if (optBz.Checked)
            {
                using (Stream bzFile = File.Create(fileName + ".tar.bz2"))
                using (Stream bzipStream = new BZip2OutputStream(bzFile))
                using (TarArchive tar = TarArchive.CreateOutputTarArchive(bzipStream))
                {
                    foreach (string file in filesList)
                    {
                        TarEntry tarEntry = TarEntry.CreateEntryFromFile(file);
                        tarEntry.Name = Path.GetFileName(file);
                        tar.WriteEntry(tarEntry, false);
                    }
                }
            }
            else if (optTar.Checked)
            {
                using (Stream tarFile = File.Create(fileName + ".tgz"))
                using (Stream gzipStream = new GZipOutputStream(tarFile))
                using (TarArchive tar = TarArchive.CreateOutputTarArchive(gzipStream))
                {
                    foreach (string file in filesList)
                    {
                        TarEntry tarEntry = TarEntry.CreateEntryFromFile(file);
                        tarEntry.Name = Path.GetFileName(file);
                        tar.WriteEntry(tarEntry, false);
                    }
                }

             //   TarOutputStream
            }
        }
    }
}
