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
using System.IO;
using SharpCompress.Common;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CsharpZip
{
    public partial class Compress : Form
    {
        public string opt { get; set; }
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
            string fileName = savePath + @"\" + txtFileName.Text + ".zip";
            if (optZip.Checked == true)
            {
                if (chkEncrypt.Checked == true)
                {
                    if (txtPass.Text == txtPass2.Text)
                    {
                        using (var zip = File.OpenWrite(fileName))
                        using (var zipWriter = WriterFactory.Open(zip, ArchiveType.Zip, CompressionType.Deflate))
                        {
                            foreach (var filePath in filesList)
                            {
                                zipWriter.Write(Path.GetFileName(filePath), filePath);
                            }
                        }
                    }
                }
                EncryptFile(fileName, fileName, txtPass.Text);
                DecryptFile(fileName, fileName + "_lala.zip", txtPass.Text);
                /*else
                {
                    //Compress Zip
                    using (var zip = File.OpenWrite(fileName))
                    using (var zipWriter = WriterFactory.Open(zip, ArchiveType.Zip, CompressionType.Deflate))
                    {
                        foreach (var filePath in filesList)
                        {
                            zipWriter.Write(Path.GetFileName(filePath), filePath);
                        }
                    }
                }*/

            }
            else if (optRar.Checked)
            {
                //Compress RAR
                using (var rar = File.OpenWrite(savePath + @"\" + txtFileName.Text + ".rar"))
                using (var rarWriter = WriterFactory.Open(rar, ArchiveType.Rar, CompressionType.Rar))
                {
                    foreach(var filePath in filesList)
                    {
                        rarWriter.Write(Path.GetFileName(filePath), filePath);
                    }
                }
            }
            else if (optTar.Checked)
            {
                //Compress TAR
                using (var tar = File.OpenWrite(savePath + @"\" + txtFileName.Text + ".tar.bz2"))
                using (var tarWriter = WriterFactory.Open(tar, ArchiveType.Tar, CompressionType.BZip2))
                {
                    foreach (var filePath in filesList)
                    {
                        tarWriter.Write(Path.GetFileName(filePath), filePath);
                    }
                }
            }
            if (chkEncrypt.Checked)
            {

            }
        }

        private static void EncryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encription Fail" + ex);
            }
        }

        private static void DecryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                    using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                            {
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decription Fail"+ex);
            }
        }

    }
}
