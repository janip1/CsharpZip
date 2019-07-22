using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.BZip2;
using System;
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

        /// <summary>
        /// Metoda se sproži ob kliku na gumb Odpri mapo in  odpre FolderBrowserDialog, 
        /// s katerim odpremo obstoječ direktorij za prikaz v fileExplorerju.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            // Pobriši morebitne elemente v file explorerju
            fileExplorer.Items.Clear();

            // uporabi FolderBrowserDialog
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Izberi mapo" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // Zapiši pot do direktorija v txtPath vnosno polje
                    txtPath.Text = fbd.SelectedPath;
                    // Klic zunanje metode za prikaz podatkov odprtega direktorija
                    ListDirectory(fbd.SelectedPath);
                }
            }
        }

        /// <summary>
        /// Metoda BtnOpenFile_Click se sproži ob kliku na gumb Odpri datoteko in prikaže openFileDialog
        /// uporabi se za prikaz podatkov stisnjene datoteke.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            // Pobriši morebitne elemente v file explorerju
            fileExplorer.Items.Clear();
            using (openFileDialog1)
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Zapiši pot do datoteke v txtPath vnosno polje
                    string filePath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                    txtPath.Text = filePath;
                    // Klic zunanje metode za prikaz podatkov odprte datoteke
                    ListFileContents(filePath);
                }
            }
        }

        /// <summary>
        /// Metoda, ki se pokliče, ko kliknemo na gumb Stisni. Sprejme listo izbranih datotek iz file explorerja
        /// in jih pošlje v Dialog Compress. Dialog se odpre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCompress_Click(object sender, EventArgs e)
        {
            // StringCollection izbranih datotek
            int i = 0;
            filesList = new StringCollection();
            // Preberi izbrane datoteke in jih shrani v StringCollection filesList
            foreach (ListViewItem item in fileExplorer.SelectedItems)
            {
                string file = item.SubItems[0].Text;
                filesList.Add(item.SubItems[3].Text + @"\" + file);
                i++;
            }
            DataObject dataObject = new DataObject();
            dataObject.SetFileDropList(filesList);
            // Odpri dialog Compress
            Compress compWin = new Compress();
            compWin.ShowDialog();
        }

        /// <summary>
        /// Metoda, ki se pokliče, ko kliknemo na gumb Razširi. Odpre saveFileDialog in prebere kam bomo datoteko 
        /// shranili.
        /// OPOMBA: metoda še ne deluje 100% pravilno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExtract_Click(object sender, EventArgs e)
        {
            // Odpri saveFileDialog
            saveFileDialog1.ShowDialog();

            filesList = new StringCollection();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Pridobi shranjevalno pot
                string savePath = Path.GetFullPath(saveFileDialog1.FileName);
                foreach (ListViewItem item in fileExplorer.SelectedItems)
                {
                    string file = item.SubItems[0].Text;
                    filesList.Add(item.SubItems[3].Text + @"\" + file);
                    string fileToDecompress = item.SubItems[3].Text + @"\" + file;

                    // Preveri katera oblika datoteke je: ZIP, TAR ali TAR.BZ2
                    if (Path.GetExtension(file) == ".zip")
                    {
                        Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(fileToDecompress);
                        Directory.CreateDirectory(savePath);
                        foreach (ZipEntry entry in zip)
                        {
                            entry.Extract(savePath, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                    else if (Path.GetExtension(file) == ".tar")
                    {
                        Stream inStream = File.OpenRead(fileToDecompress);

                        TarArchive tarArchive = TarArchive.CreateInputTarArchive(inStream);
                        tarArchive.ExtractContents(savePath);
                        tarArchive.Close();

                        inStream.Close();
                    }

                    else if (Path.GetExtension(file) == ".bz2")
                    {
                        byte[] dataBuffer = new byte[4096];

                        using (Stream fs = new FileStream(fileToDecompress, FileMode.Open, FileAccess.Read))
                        {
                            using (BZip2InputStream bzip = new BZip2InputStream(fs))
                            {
                                using (FileStream fsOut = File.Create(savePath + Path.GetFileNameWithoutExtension(fileToDecompress)))
                                {
                                    StreamUtils.Copy(bzip, fsOut, dataBuffer);
                                }
                            }
                        }

                        Stream inStream = File.OpenRead(savePath + Path.GetFileNameWithoutExtension(fileToDecompress));

                        TarArchive tarArchive = TarArchive.CreateInputTarArchive(inStream);
                        tarArchive.ExtractContents(savePath);
                        tarArchive.Close();
                        File.Delete(inStream.ToString());
                        inStream.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Metoda, ki se sproži ob prijemanju in vlečenju datotek izven glavnega okna. 
        /// Trenutno deluje samo za navadne datoteke.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metoda, ki se sproži ob dvokliku na direktorij, znotraj file explorerja in odpre direktorij 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metoda, ki se sproži ob kliku na gumb "eno višje"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metoda, ki se kliče pri prikazu datotek in map
        /// </summary>
        /// <param name="path"></param>
        private void ListDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] subdirectories = directory.GetDirectories();

            // Če ima direktorij poddirektorije prikaži direktorije in datoteke, če ne samo datoteke
            if (subdirectories.Length != 0)
            {
                //Pridobi direktorije
                foreach (DirectoryInfo subDirectory in subdirectories)
                {
                    Icon iconForFile = DefaultIcons.FolderLarge;
                    ListViewItem row = new ListViewItem(subDirectory.Name);
                    imageList1.Images.Add(subDirectory.FullName, iconForFile);
                    row.ImageKey = subDirectory.FullName;
                    fileExplorer.Items.Add(row);
                }

                //Pridobi datoteke
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

        /// <summary>
        /// Metoda, ki prikaže podatke in datoteke znotraj kompresirane datoteke. Preveri katera datoteka se odpira
        /// in glede na to sproži potrebno kodo.
        /// </summary>
        /// <param name="path"></param>
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