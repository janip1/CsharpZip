using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;
using ZipEntry = Ionic.Zip.ZipEntry;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;

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
            if (fileExplorer.SelectedItems.Count > 0)
            {
                // Preberi izbrane datoteke in jih shrani v StringCollection filesList
                foreach (ListViewItem item in fileExplorer.SelectedItems)
                {
                    string file = item.SubItems[0].Text;
                    filesList.Add(item.SubItems[3].Text + @"\" + file);
                    i++;
                }
                // Odpri dialog Compress
                Compress compWin = new Compress();
                compWin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nobena datoteka ni bila izbrana. Prosimo izberite datoteke.", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            filesList = new StringCollection();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fileExplorer.SelectedItems.Count > 0 && fbd.ShowDialog() == DialogResult.OK)
            {
                // Pridobi shranjevalno pot
                string savePath = fbd.SelectedPath;

                foreach (ListViewItem item in fileExplorer.SelectedItems)
                {
                    string file = item.SubItems[0].Text;

                    // Preveri katera oblika datoteke je: ZIP, TAR, GZIP ali TAR.BZ2
                    if (Path.GetExtension(txtPath.Text) == ".zip")
                    {
                        ZipFile zip = Ionic.Zip.ZipFile.Read(txtPath.Text);
                        ZipEntry entry = zip[file];
                        if (zip[file].UsesEncryption == true)
                        {
                            PasswordPrompt passWin = new PasswordPrompt();
                            passWin.ShowDialog();

                            zip.Password = passWin.pass;
                            try
                            {
                                entry.ExtractWithPassword(savePath, passWin.pass);
                            }
                            catch (BadPasswordException)
                            {
                                if (MessageBox.Show("Napačno geslo", "Napaka", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                                    passWin.ShowDialog();
                            }
                        }
                        
                        string enExists = savePath + @"\" + entry.FileName;

                        if (File.Exists(enExists))
                        {
                            if (MessageBox.Show("Datoteka " + file + " že obstaja. Ali jo želite zamenjati?", "Datoteka obstaja", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                entry.Extract(savePath, ExtractExistingFileAction.OverwriteSilently);
                            else
                                break;
                        }
                        else
                        {
                            entry.Extract(savePath);
                        }
                    }

                    else if (Path.GetExtension(txtPath.Text) == ".tar")
                    {
                        byte[] outBuffer = new byte[4096];
                        TarInputStream tar = new TarInputStream(new FileStream(txtPath.Text, FileMode.Open, FileAccess.Read));
                        TarEntry curEntry = tar.GetNextEntry();
                        while (curEntry != null)
                        {
                            if (curEntry.Name == file)
                            {
                                FileStream fs = new FileStream(savePath + @"\" + curEntry.Name, FileMode.Create, FileAccess.Write);
                                BinaryWriter bw = new BinaryWriter(fs);
                                tar.Read(outBuffer, 0, (int)curEntry.Size);
                                bw.Write(outBuffer, 0, outBuffer.Length);
                                bw.Close();
                            }
                            curEntry = tar.GetNextEntry();
                        }
                        tar.Close();
                    }

                    else if (Path.GetExtension(txtPath.Text) == ".bz2")
                    {
                        Stream str = new FileStream(txtPath.Text, FileMode.Open, FileAccess.Read);
                        BZip2InputStream bzStr = new BZip2InputStream(str);
                        TarInputStream tar = new TarInputStream(bzStr);
                        TarEntry curEntry = tar.GetNextEntry();
                        while (curEntry != null)
                        {
                            if (curEntry.Name == file)
                            {
                                byte[] outBuffer = new byte[curEntry.Size];
                                FileStream fs = new FileStream(savePath + @"\" + curEntry.Name, FileMode.Create, FileAccess.Write);
                                BinaryWriter bw = new BinaryWriter(fs);
                                tar.Read(outBuffer, 0, (int)curEntry.Size);
                                bw.Write(outBuffer, 0, outBuffer.Length);
                                bw.Close();
                            }
                            curEntry = tar.GetNextEntry();
                        }
                        tar.Close();
                    }
                    
                    else if (Path.GetExtension(txtPath.Text) == ".tgz")
                    {
                        Stream str = new FileStream(txtPath.Text, FileMode.Open, FileAccess.Read);
                        GZipInputStream gzStr = new GZipInputStream(str);
                        TarInputStream tar = new TarInputStream(gzStr);
                        
                        TarEntry curEntry = tar.GetNextEntry();
                        while (curEntry != null)
                        {
                            if (curEntry.Name == file)
                            {
                                byte[] outBuffer = new byte[curEntry.Size];
                                FileStream fs = new FileStream(savePath + @"\" + curEntry.Name, FileMode.Create, FileAccess.Write);
                                BinaryWriter bw = new BinaryWriter(fs);
                                tar.Read(outBuffer, 0, (int)curEntry.Size);
                                bw.Write(outBuffer, 0, outBuffer.Length);
                                bw.Close();
                            }
                            curEntry = tar.GetNextEntry();
                        }
                        tar.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Nobena datoteka ni bila izbrana. Prosimo izberite datoteke.", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                try
                {
                    filePath.Add(item.SubItems[3].Text + @"\" + file);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Datoteke ni mogoče prenesti z drag/drop funkcijo.", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
            if (fileExplorer.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in fileExplorer.SelectedItems)
                {
                    string file = item.SubItems[0].Text;
                    string path = txtPath.Text + @"\" + file;
                    fileExplorer.Items.Clear();
                    txtPath.Text = path;

                    FileAttributes attr = File.GetAttributes(path);
                    if (Directory.Exists(path) && attr.HasFlag(FileAttributes.Directory))
                        ListDirectory(path);
                    else if (attr.HasFlag(FileAttributes.Archive))
                    {
                        ListFileContents(txtPath.Text);
                    }
                    else
                    {
                        MessageBox.Show("Prišlo je do napake. Mesto ni direktorij.", "Napaka", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        string input = txtPath.Text;
                        int index = input.LastIndexOf(@"\");
                        if (index > 0)
                        {
                            txtPath.Text = input.Substring(0, index);
                            ListDirectory(txtPath.Text);
                        }
                    }
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
                        row.ImageKey = Path.GetExtension(item.Name);
                        row.SubItems.Add(item.Size.ToString());
                        row.SubItems.Add(Path.GetExtension(item.Name));
                        
                        fileExplorer.Items.Add(row);
                    }
                }        
            }
            else if (Path.GetExtension(path) == ".tar")
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
            else if (Path.GetExtension(path) == ".bz2")
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (BZip2InputStream bzFile = new BZip2InputStream(fs))
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
            else if (Path.GetExtension(path) == ".tgz")
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (GZipInputStream gzFile = new GZipInputStream(fs))
                using (var tarFile = new TarInputStream(gzFile))
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