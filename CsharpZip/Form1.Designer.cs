﻿namespace CsharpZip
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odpriMapoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odpriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stisniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.razširiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.izhodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomočToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.fileExplorer = new System.Windows.Forms.ListView();
            this.file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filetype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.oneUp = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datotekaToolStripMenuItem,
            this.pomočToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // datotekaToolStripMenuItem
            // 
            this.datotekaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaToolStripMenuItem,
            this.odpriMapoToolStripMenuItem,
            this.odpriToolStripMenuItem,
            this.stisniToolStripMenuItem,
            this.razširiToolStripMenuItem,
            this.toolStripMenuItem1,
            this.izhodToolStripMenuItem});
            this.datotekaToolStripMenuItem.Name = "datotekaToolStripMenuItem";
            this.datotekaToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.datotekaToolStripMenuItem.Text = "Datoteka";
            // 
            // novaToolStripMenuItem
            // 
            this.novaToolStripMenuItem.Name = "novaToolStripMenuItem";
            this.novaToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.novaToolStripMenuItem.Text = "Nova";
            this.novaToolStripMenuItem.Click += new System.EventHandler(this.NovaToolStripMenuItem_Click);
            // 
            // odpriMapoToolStripMenuItem
            // 
            this.odpriMapoToolStripMenuItem.Name = "odpriMapoToolStripMenuItem";
            this.odpriMapoToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.odpriMapoToolStripMenuItem.Text = "Odpri mapo";
            this.odpriMapoToolStripMenuItem.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // odpriToolStripMenuItem
            // 
            this.odpriToolStripMenuItem.Name = "odpriToolStripMenuItem";
            this.odpriToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.odpriToolStripMenuItem.Text = "Odpri datoteko";
            this.odpriToolStripMenuItem.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // stisniToolStripMenuItem
            // 
            this.stisniToolStripMenuItem.Name = "stisniToolStripMenuItem";
            this.stisniToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.stisniToolStripMenuItem.Text = "Stisni";
            this.stisniToolStripMenuItem.Click += new System.EventHandler(this.BtnCompress_Click);
            // 
            // razširiToolStripMenuItem
            // 
            this.razširiToolStripMenuItem.Name = "razširiToolStripMenuItem";
            this.razširiToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.razširiToolStripMenuItem.Text = "Razširi";
            this.razširiToolStripMenuItem.Click += new System.EventHandler(this.BtnExtract_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // izhodToolStripMenuItem
            // 
            this.izhodToolStripMenuItem.Name = "izhodToolStripMenuItem";
            this.izhodToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.izhodToolStripMenuItem.Text = "Izhod";
            this.izhodToolStripMenuItem.Click += new System.EventHandler(this.IzhodToolStripMenuItem_Click);
            // 
            // pomočToolStripMenuItem
            // 
            this.pomočToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramuToolStripMenuItem});
            this.pomočToolStripMenuItem.Name = "pomočToolStripMenuItem";
            this.pomočToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.pomočToolStripMenuItem.Text = "Pomoč";
            // 
            // oProgramuToolStripMenuItem
            // 
            this.oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            this.oProgramuToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.oProgramuToolStripMenuItem.Text = "O programu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Datoteka";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(559, 98);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(99, 23);
            this.btnOpenFolder.TabIndex = 5;
            this.btnOpenFolder.Text = "Odpri &mapo";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(559, 128);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(99, 23);
            this.btnCompress.TabIndex = 6;
            this.btnCompress.Text = "Stisni";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.BtnCompress_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(559, 158);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(99, 23);
            this.btnExtract.TabIndex = 7;
            this.btnExtract.Text = "Razširi";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.BtnExtract_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(70, 35);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(463, 22);
            this.txtPath.TabIndex = 10;
            // 
            // fileExplorer
            // 
            this.fileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.file,
            this.size,
            this.filetype,
            this.path});
            this.fileExplorer.HideSelection = false;
            this.fileExplorer.LargeImageList = this.imageList1;
            this.fileExplorer.Location = new System.Drawing.Point(16, 69);
            this.fileExplorer.Name = "fileExplorer";
            this.fileExplorer.Size = new System.Drawing.Size(537, 239);
            this.fileExplorer.SmallImageList = this.imageList1;
            this.fileExplorer.TabIndex = 13;
            this.fileExplorer.UseCompatibleStateImageBehavior = false;
            this.fileExplorer.View = System.Windows.Forms.View.Details;
            this.fileExplorer.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.FileExplorer_ItemDrag);
            this.fileExplorer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListItem_DoubleClick);
            // 
            // file
            // 
            this.file.Text = "Datoteka";
            this.file.Width = 180;
            // 
            // size
            // 
            this.size.Text = "Velikost";
            // 
            // filetype
            // 
            this.filetype.Text = "Vrsta";
            // 
            // path
            // 
            this.path.Text = "Mesto";
            this.path.Width = 180;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // oneUp
            // 
            this.oneUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("oneUp.BackgroundImage")));
            this.oneUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.oneUp.Location = new System.Drawing.Point(533, 35);
            this.oneUp.Name = "oneUp";
            this.oneUp.Size = new System.Drawing.Size(20, 20);
            this.oneUp.TabIndex = 14;
            this.oneUp.UseVisualStyleBackColor = true;
            this.oneUp.Click += new System.EventHandler(this.OneUp_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(559, 69);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(99, 23);
            this.btnOpenFile.TabIndex = 15;
            this.btnOpenFile.Text = "Odpri &datoteko";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(669, 329);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.oneUp);
            this.Controls.Add(this.fileExplorer);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "CsharpZip";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datotekaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odpriToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem izhodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomočToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramuToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ToolStripMenuItem stisniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem razširiToolStripMenuItem;
        private System.Windows.Forms.ListView fileExplorer;
        private System.Windows.Forms.ColumnHeader file;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader filetype;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button oneUp;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ToolStripMenuItem odpriMapoToolStripMenuItem;
    }
}

