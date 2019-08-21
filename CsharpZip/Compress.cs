using Ionic.Zip;
using System;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using System.Diagnostics;
using System.Threading;

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

                            Stopwatch stopwatch = Stopwatch.StartNew();
                            foreach (string file in filesList)
                            {
                                zip.AddFile(file, "");
                            }
                            zip.Save(fileName + ".zip");
                            stopwatch.Stop();
                            lblElapsed.Text += stopwatch.Elapsed.TotalMilliseconds.ToString();
                        }
                    }
                }
               
                else
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        foreach (string file in filesList)
                        {
                            zip.AddFile(file, "");
                        }
                        zip.Save(fileName + ".zip");
                        stopwatch.Stop();
                        lblElapsed.Text += stopwatch.Elapsed.TotalMilliseconds.ToString();
                    }
                }

                if (File.Exists(fileName + ".zip"))
                {
                    MessageBox.Show("Datoteka uspešno kreirana", "Uspeh!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Prišlo je do napake, poskusite ponovno.", "Napaka", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                
            }
            else if (optBz.Checked)
            {
                using (Stream bzFile = File.Create(fileName + ".bz2"))
                using (Stream bzipStream = new BZip2OutputStream(bzFile))
                using (TarArchive tar = TarArchive.CreateOutputTarArchive(bzipStream))
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    foreach (string file in filesList)
                    {
                        TarEntry tarEntry = TarEntry.CreateEntryFromFile(file);
                        tarEntry.Name = Path.GetFileName(file);
                        tar.WriteEntry(tarEntry, false);
                    }
                    stopwatch.Stop();
                    lblElapsed.Text += stopwatch.Elapsed.TotalMilliseconds.ToString();
                }
                if (File.Exists(fileName + ".bz2"))
                {
                    MessageBox.Show("Datoteka uspešno kreirana", "Uspeh!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Prišlo je do napake, poskusite ponovno.", "Napaka", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            else if (optTar.Checked)
            {
                using (Stream tarFile = File.Create(fileName + ".tar"))
                using (Stream tarStream = new TarOutputStream(tarFile))
                using (TarArchive tar = TarArchive.CreateOutputTarArchive(tarStream))
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    foreach (string file in filesList)
                    {
                        TarEntry tarEntry = TarEntry.CreateEntryFromFile(file);
                        tarEntry.Name = Path.GetFileName(file);
                        tar.WriteEntry(tarEntry, false);
                    }
                    
                    stopwatch.Stop();
                    lblElapsed.Text += stopwatch.Elapsed.TotalMilliseconds.ToString();
                }
                if (File.Exists(fileName + ".tar"))
                {
                    MessageBox.Show("Datoteka uspešno kreirana", "Uspeh!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Prišlo je do napake, poskusite ponovno.", "Napaka", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }

            else if (optTgz.Checked)
            {
                using (Stream tgzFile = File.Create(fileName + ".tgz"))
                using (Stream tgzStream = new GZipOutputStream(tgzFile))
                using (TarArchive tgz = TarArchive.CreateOutputTarArchive(tgzStream))
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    foreach (string file in filesList)
                    {
                        TarEntry tgzEntry = TarEntry.CreateEntryFromFile(file);
                        tgzEntry.Name = Path.GetFileName(file);
                        tgz.WriteEntry(tgzEntry, false);
                    }
                    stopwatch.Stop();
                    lblElapsed.Text += stopwatch.Elapsed.TotalMilliseconds.ToString();
                }

                if (File.Exists(fileName + ".tgz"))
                {
                    MessageBox.Show("Datoteka uspešno kreirana", "Uspeh!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Prišlo je do napake, poskusite ponovno.", "Napaka", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void OptBz_CheckedChanged(object sender, EventArgs e)
        {
            chkEncrypt.Enabled = false;
            txtPass.Enabled = false;
            txtPass2.Enabled = false;
        }

        private void OptTar_CheckedChanged(object sender, EventArgs e)
        {
            chkEncrypt.Enabled = false;
            txtPass.Enabled = false;
            txtPass2.Enabled = false;
        }

        private void OptZip_CheckedChanged(object sender, EventArgs e)
        {
            chkEncrypt.Enabled = true;
            txtPass.Enabled = true;
            txtPass2.Enabled = true;
        }

        private void OptTgz_CheckedChanged(object sender, EventArgs e)
        {
            chkEncrypt.Enabled = false;
            txtPass.Enabled = false;
            txtPass2.Enabled = false;
        }
    }
}
