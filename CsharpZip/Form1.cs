using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CsharpZip
{
    public partial class Form1 : Form
    {
        //List<string> listFiles = new List<string>();
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

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            fileExplorer.Items.Clear();
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Izberi mapo" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath;

                    ListDirectory(fbd.SelectedPath);
                }
            }
        }

        private void BtnCompress_Click(object sender, EventArgs e)
        {
            int i = 0;
            filesList = new StringCollection();
            foreach (ListViewItem item in fileExplorer.SelectedItems)
            {
                string file = item.SubItems[0].Text;
                filesList.Add(item.SubItems[3].Text + @"\" + file);
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

        private void FileExplorer_ItemDrag(object sender, ItemDragEventArgs e)
        {
            int i = 0;

            StringCollection filePath = new StringCollection();
            foreach (ListViewItem item in fileExplorer.SelectedItems)
            {
                string file = item.SubItems[0].Text;
                filePath.Add(item.SubItems[3].Text + @"\" + file);
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
                    string file = item.SubItems[0].Text;
                    string path = txtPath.Text + @"\" + file;
                    fileExplorer.Items.Clear();
                    txtPath.Text = path;

                    if(Directory.Exists(path))
                        ListDirectory(path);
                }
            }
        }

        private void OneUp_Click(object sender, EventArgs e)
        {
            fileExplorer.Items.Clear();

            string input = txtPath.Text;
            int index = input.LastIndexOf(@"\");
            if (index > 0)
            {
                txtPath.Text = input.Substring(0, index);
                ListDirectory(txtPath.Text);
            }   
        }

        private void ListDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] subdirectories = directory.GetDirectories();

            if (subdirectories.Length != 0)
            {
                foreach (DirectoryInfo subDirectory in subdirectories)
                {
                    Icon iconForFile = DefaultIcons.FolderLarge;
                    ListViewItem row = new ListViewItem(subDirectory.Name);
                    imageList1.Images.Add(subDirectory.FullName, iconForFile);
                    row.ImageKey = subDirectory.FullName;
                    fileExplorer.Items.Add(row);
                }

                foreach (string item in Directory.GetFiles(path))
                {
                    FileInfo file = new FileInfo(item);
                    Icon iconForFile = SystemIcons.WinLogo;

                    ListViewItem row = new ListViewItem(file.Name);

                    iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(file.Extension, iconForFile);
                    row.ImageKey = file.Extension;
                    row.SubItems.Add(file.Length.ToString());
                    row.SubItems.Add(file.Extension);
                    row.SubItems.Add(file.Directory.ToString());
                    fileExplorer.Items.Add(row);
                }
            }
            else
            {
                foreach (string item in Directory.GetFiles(path))
                {
                    FileInfo file = new FileInfo(item);
                    Icon iconForFile = SystemIcons.WinLogo;
                    ListViewItem row = new ListViewItem(file.Name);

                    iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(file.Extension, iconForFile);
                    row.ImageKey = file.Extension;
                    row.SubItems.Add(file.Length.ToString());
                    row.SubItems.Add(file.Extension);
                    row.SubItems.Add(file.Directory.ToString());
                    fileExplorer.Items.Add(row);
                }
            }
        }

    }
}