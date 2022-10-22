
namespace Radio
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.VolumeScrollBar = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.materialSwitch1 = new MaterialSkin.Controls.MaterialSwitch();
            this.label2 = new System.Windows.Forms.Label();
            this.muteBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyStationAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.getInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importStationsFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportStationsToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(10, 101);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(285, 160);
            this.listBox1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(10, 267);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(244, 20);
            this.SearchBox.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 400);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(244, 28);
            this.button4.TabIndex = 5;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(244, 28);
            this.button3.TabIndex = 4;
            this.button3.Text = "Prev";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // VolumeScrollBar
            // 
            this.VolumeScrollBar.LargeChange = 1;
            this.VolumeScrollBar.Location = new System.Drawing.Point(271, 301);
            this.VolumeScrollBar.Name = "VolumeScrollBar";
            this.VolumeScrollBar.Size = new System.Drawing.Size(17, 127);
            this.VolumeScrollBar.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // materialSwitch1
            // 
            this.materialSwitch1.AutoSize = true;
            this.materialSwitch1.Depth = 0;
            this.materialSwitch1.Location = new System.Drawing.Point(54, 64);
            this.materialSwitch1.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch1.Name = "materialSwitch1";
            this.materialSwitch1.Ripple = true;
            this.materialSwitch1.Size = new System.Drawing.Size(107, 37);
            this.materialSwitch1.TabIndex = 10;
            this.materialSwitch1.Text = "Theme";
            this.materialSwitch1.UseVisualStyleBackColor = true;
            this.materialSwitch1.CheckedChanged += new System.EventHandler(this.materialSwitch1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(12, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search...";
            // 
            // muteBox
            // 
            this.muteBox.AutoSize = true;
            this.muteBox.Location = new System.Drawing.Point(273, 285);
            this.muteBox.Name = "muteBox";
            this.muteBox.Size = new System.Drawing.Size(15, 14);
            this.muteBox.TabIndex = 7;
            this.muteBox.UseVisualStyleBackColor = true;
            this.muteBox.CheckedChanged += new System.EventHandler(this.muteBox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyStationAddressToolStripMenuItem,
            this.sortToolStripMenuItem,
            this.getInfoToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.addNewStationToolStripMenuItem,
            this.removeSelectedStationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 136);
            // 
            // copyStationAddressToolStripMenuItem
            // 
            this.copyStationAddressToolStripMenuItem.Name = "copyStationAddressToolStripMenuItem";
            this.copyStationAddressToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.copyStationAddressToolStripMenuItem.Text = "Copy Selected Station URL";
            this.copyStationAddressToolStripMenuItem.Click += new System.EventHandler(this.copyStationAddressToolStripMenuItem_Click);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.sortToolStripMenuItem.Text = "Sort By";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Default",
            "Name",
            "PlayCount"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Text = "Default";
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // getInfoToolStripMenuItem
            // 
            this.getInfoToolStripMenuItem.Name = "getInfoToolStripMenuItem";
            this.getInfoToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.getInfoToolStripMenuItem.Text = "Get Info";
            this.getInfoToolStripMenuItem.Click += new System.EventHandler(this.getInfoToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // addNewStationToolStripMenuItem
            // 
            this.addNewStationToolStripMenuItem.Name = "addNewStationToolStripMenuItem";
            this.addNewStationToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.addNewStationToolStripMenuItem.Text = "Add New Station";
            this.addNewStationToolStripMenuItem.Click += new System.EventHandler(this.addNewStationToolStripMenuItem_Click);
            // 
            // removeSelectedStationToolStripMenuItem
            // 
            this.removeSelectedStationToolStripMenuItem.Name = "removeSelectedStationToolStripMenuItem";
            this.removeSelectedStationToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.removeSelectedStationToolStripMenuItem.Text = "Remove selected station";
            this.removeSelectedStationToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedStationToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text File|*.txt";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 64);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(170, 33);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importStationsFromFileToolStripMenuItem,
            this.exportStationsToXMLToolStripMenuItem,
            this.getScreenToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(42, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // importStationsFromFileToolStripMenuItem
            // 
            this.importStationsFromFileToolStripMenuItem.Name = "importStationsFromFileToolStripMenuItem";
            this.importStationsFromFileToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.importStationsFromFileToolStripMenuItem.Text = "Import Stations From File";
            this.importStationsFromFileToolStripMenuItem.Click += new System.EventHandler(this.importStationsFromFileToolStripMenuItem_Click);
            // 
            // exportStationsToXMLToolStripMenuItem
            // 
            this.exportStationsToXMLToolStripMenuItem.Name = "exportStationsToXMLToolStripMenuItem";
            this.exportStationsToXMLToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exportStationsToXMLToolStripMenuItem.Text = "Export Stations To XML";
            this.exportStationsToXMLToolStripMenuItem.Click += new System.EventHandler(this.exportStationsToXMLToolStripMenuItem_Click);
            // 
            // getScreenToolStripMenuItem
            // 
            this.getScreenToolStripMenuItem.Name = "getScreenToolStripMenuItem";
            this.getScreenToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.getScreenToolStripMenuItem.Text = "Get Screen";
            this.getScreenToolStripMenuItem.Click += new System.EventHandler(this.getScreenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "label3";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "kotohuy-2_256475960_orig_.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(87, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 438);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.muteBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.materialSwitch1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VolumeScrollBar);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Internet Radio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.VScrollBar VolumeScrollBar;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox muteBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyStationAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importStationsFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportStationsToXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedStationToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem getInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getScreenToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem addNewStationToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}

