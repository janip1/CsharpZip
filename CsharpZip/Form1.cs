using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CsharpZip
{
    public partial class Form1 : Form
    {
        List<string> listFiles = new List<string>();
        public static StringCollection filesList = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void EkstrahirajToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void IzhodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            listFiles.Clear();
            fileExplorer.Items.Clear();
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Izberi mapo" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath;
                    DirectoryInfo directoryInfo = new DirectoryInfo(fbd.SelectedPath);
                    FileStream fileStream = null;

                    FileInfo[] fileInfo = directoryInfo.GetFiles();
                    DirectoryInfo[] subdirectoryInfo = directoryInfo.GetDirectories();

                    foreach (DirectoryInfo subDirectory in subdirectoryInfo)
                    {
                        listFiles.Add(subDirectory.FullName);
                        ListViewItem row = new ListViewItem();
                        Icon iconForFile = DefaultIcons.FolderLarge;
                        
                        imageList1.Images.Add(subDirectory.FullName, iconForFile);
                        row.ImageKey = subDirectory.FullName;
                        row.SubItems.Add(subDirectory.Name);
                        fileExplorer.Items.Add(row);
                    }

                    foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                    {
                        FileInfo file = new FileInfo(item);
                        Icon iconForFile = SystemIcons.WinLogo;

                        listFiles.Add(file.FullName);
                        ListViewItem row = new ListViewItem();

                        iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                        imageList1.Images.Add(file.Extension, iconForFile);
                        row.ImageKey = file.Extension;

                        row.SubItems.Add(file.Name);
                        row.SubItems.Add(file.Length.ToString());
                        row.SubItems.Add(file.Extension);
                        row.SubItems.Add(file.Directory.ToString());
                        fileExplorer.Items.Add(row);
                    }
                }
            }
        }

        private void Path_TextChanged(object sender, EventArgs e)
        {
            if (Directory.GetCurrentDirectory() == txtPath.Text)
            {
                toolStripStatusLabel2.Text = "Direktorij naložen!";
            }
            else
            {
                if (Directory.Exists(txtPath.Text))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(txtPath.Text);

                    FileInfo[] fileInfo = directoryInfo.GetFiles();
                    DirectoryInfo[] subdirectoryInfo = directoryInfo.GetDirectories();

                    foreach (DirectoryInfo subDirectory in subdirectoryInfo)
                    {
                        listFiles.Add(subDirectory.FullName);
                        ListViewItem row = new ListViewItem();
                        Icon iconForFile = DefaultIcons.FolderLarge;

                        imageList1.Images.Add(subDirectory.FullName, iconForFile);
                        row.ImageKey = subDirectory.FullName;
                        row.SubItems.Add(subDirectory.Name);
                        fileExplorer.Items.Add(row);
                    }

                    listFiles.Clear();
                    fileExplorer.Items.Clear();
                    foreach (string item in Directory.GetFiles(txtPath.Text))
                    {
                        FileInfo file = new FileInfo(item);
                        Icon iconForFile = SystemIcons.WinLogo;

                        listFiles.Add(file.FullName);
                        ListViewItem row = new ListViewItem();

                        iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                        imageList1.Images.Add(file.Extension, iconForFile);
                        row.ImageKey = file.Extension;
                        
                        row.SubItems.Add(file.Name);
                        row.SubItems.Add(file.Length.ToString());
                        row.SubItems.Add(file.Extension);
                        row.SubItems.Add(file.Directory.ToString());
                        fileExplorer.Items.Add(row);
                    }
                }
                else
                {
                    listFiles.Clear();
                    fileExplorer.Items.Clear();
                    toolStripStatusLabel2.Text = "Direktorij ne obstaja!";
                }
            }
        }

        private void BtnCompress_Click(object sender, EventArgs e)
        {
            int i = 0;
            filesList = new StringCollection();
            foreach (ListViewItem item in fileExplorer.SelectedItems)
            {
                string file = item.SubItems[1].Text;
                filesList.Add(item.SubItems[4].Text + @"\" + file);
                i++;
            }
            DataObject dataObject = new DataObject();
            dataObject.SetFileDropList(filesList);

            Compress compWin = new Compress();
            compWin.ShowDialog();
        }

        private void BtnExtract_Click(object sender, EventArgs e)
        {
            Extract extWin = new Extract();
            extWin.ShowDialog();
        }

        private void fileExplorer_ItemDrag(object sender, ItemDragEventArgs e)
        {

            int i = 0;

            StringCollection filePath = new StringCollection();
            foreach (ListViewItem item in fileExplorer.SelectedItems)
            {
                string file = item.SubItems[1].Text;
                filePath.Add(item.SubItems[4].Text + @"\" + file);
                i++;
            }
            DataObject dataObject = new DataObject();
            dataObject.SetFileDropList(filePath);
            fileExplorer.DoDragDrop(dataObject, DragDropEffects.Copy);
        }

        private void ListItem_DoubleClick(object sender, MouseEventArgs e)
        {
            if(fileExplorer.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in fileExplorer.SelectedItems)
                {
                    string file = item.SubItems[1].Text;
                    string path = txtPath.Text + @"\" + file;
                    listFiles.Clear();
                    fileExplorer.Items.Clear();
                    txtPath.Text = path;
                }
            }
        }

        private void ToolStripProgressBar2_Click(object sender, EventArgs e)
        {

        }



        /*
        private static void DecryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security
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
                // failed to decrypt file
            }
        }*/



    }
}