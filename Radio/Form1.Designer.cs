
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
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 301);
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
            this.listBox1.Location = new System.Drawing.Point(6, 109);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(289, 160);
            this.listBox1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 335);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(6, 270);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(244, 20);
            this.SearchBox.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 403);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(244, 28);
            this.button4.TabIndex = 5;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 369);
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
            this.VolumeScrollBar.Location = new System.Drawing.Point(268, 304);
            this.VolumeScrollBar.Name = "VolumeScrollBar";
            this.VolumeScrollBar.Size = new System.Drawing.Size(17, 126);
            this.VolumeScrollBar.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // materialSwitch1
            // 
            this.materialSwitch1.AutoSize = true;
            this.materialSwitch1.Depth = 0;
            this.materialSwitch1.Location = new System.Drawing.Point(1, 69);
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
            this.label2.Location = new System.Drawing.Point(8, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search...";
            // 
            // muteBox
            // 
            this.muteBox.AutoSize = true;
            this.muteBox.Location = new System.Drawing.Point(270, 288);
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
            this.sortToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 70);
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
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 438);
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Internet Radio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
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
    }
}

