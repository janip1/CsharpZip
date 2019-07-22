using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.BZip2;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;
using ZipEntry = Ionic.Zip.ZipEntry;

namespace CsharpZip
{
    public partial class Form1 : Form
    {
        public static StringCollection filesList = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void IzhodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
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

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            fileExplorer.Items.Clear();
            using (openFileDialog1)
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;

                    ListFileContents(filePath);
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
            saveFileDialog1.ShowDialog();

            filesList = new StringCollection();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savePath = Path.GetFullPath(saveFileDialog1.FileName);
                foreach (ListViewItem item in fileExplorer.SelectedItems)
                {
                    string file = item.SubItems[0].Text;
                    filesList.Add(item.SubItems[3].Text + @"\" + file);

                    if (Path.GetExtension(file) == ".zip")
                    {
                        Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(item.SubItems[3].Text + @"\" + file);
                        Directory.CreateDirectory(savePath);
                        foreach (ZipEntry entry in zip)
                        {
                            entry.Extract(savePath, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                    else if (Path.GetExtension(file) == ".tar")
                    {
                        Stream inStream = File.OpenRead(item.SubItems[3].Text + @"\" + file);

                        TarArchive tarArchive = TarArchive.CreateInputTarArchive(inStream);
                        tarArchive.ExtractContents(savePath);
                        tarArchive.Close();

                        inStream.Close();
                    }

                    else if (Path.GetExtension(file) == ".tar.bz2")
                    {
                        using (FileStream fileToDecompressAsStream = file.OpenRead())
                        using (FileStream decompressedStream = File.Create(savePath))
                        {
                            try
                            {
                                BZip2.Decompress(fileToDecompressAsStream, decompressedStream, true);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }
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

        private void ListFileContents(string path)
        {
            fileExplorer.Items.Clear();
            if (Path.GetExtension(path) == ".zip")
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var zf = new ICSharpCode.SharpZipLib.Zip.ZipFile(fs))
                {
                    foreach (ICSharpCode.SharpZipLib.Zip.ZipEntry item in zf)
                    {
                        if (item.IsDirectory)
                            continue;

                        Icon iconForFile = SystemIcons.WinLogo;
                        ListViewItem row = new ListViewItem(item.Name);

                        iconForFile = Icon.ExtractAssociatedIcon(path);
                        imageList1.Images.Add(item.GetType().ToString(), iconForFile);
                        row.ImageKey = item.GetType().ToString();
                        row.SubItems.Add(item.Size.ToString());
                        row.SubItems.Add(item.GetType().ToString());
                        
                        fileExplorer.Items.Add(row);
                    }
                }        
            }
            else if (Path.GetExtension(path) == ".tgz")
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var tarFile = new TarInputStream(fs))
                {
                    TarEntry entry;

                    while ((entry = tarFile.GetNextEntry()) != null)
                    {
                        Icon iconForFile = SystemIcons.WinLogo;
                        ListViewItem row = new ListViewItem(entry.Name);

                        iconForFile = Icon.ExtractAssociatedIcon(path);
                        imageList1.Images.Add(Path.GetExtension(entry.Name), iconForFile);
                        row.ImageKey = Path.GetExtension(entry.Name);
                        row.SubItems.Add(entry.Size.ToString());
                        row.SubItems.Add(Path.GetExtension(entry.Name));

                        fileExplorer.Items.Add(row);
                    }
                }
            }
            else if (Path.GetExtension(path) == ".tar.bz2")
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var bzFile = new BZip2InputStream(fs))
                using (var tarFile = new TarInputStream(bzFile))
                {
                    TarEntry entry;

                    while ((entry = tarFile.GetNextEntry()) != null)
                    {
                        Icon iconForFile = SystemIcons.WinLogo;
                        ListViewItem row = new ListViewItem(entry.Name);

                        iconForFile = Icon.ExtractAssociatedIcon(path);
                        imageList1.Images.Add(Path.GetExtension(entry.Name), iconForFile);
                        row.ImageKey = Path.GetExtension(entry.Name);
                        row.SubItems.Add(entry.Size.ToString());
                        row.SubItems.Add(Path.GetExtension(entry.Name));

                        fileExplorer.Items.Add(row);
                    }
                }
            }


        }

    }
}