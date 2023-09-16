using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using Radio.Service;
using Radio.Utilities;

namespace Radio
{
    public partial class Form1 : MaterialForm
    {
        internal enum MediaPlayerState : byte
        {
            Stopped,
            Playing
        }

        private MediaPlayerState playerState;
        private RadioStation currentStation;
        private StationSort sort;
        private bool isMinimize;
        private int lastVolume;
        private int Volume
        {
            get
            {
                return (100 * mediaPlayer.Volume / volumeInterval) + 100;
            }
            set
            {
                mediaPlayer.Volume = (volumeInterval * value / 100) - volumeInterval;
            }
        }
        private const int volumeInterval = 4050;
        private const int maxLengthString = 24;
        private readonly INIFile INI = new INIFile();
        private readonly Serrializer serrializer = new Serrializer();
        private readonly MaterialSkinManager themeManager = MaterialSkinManager.Instance;
        private List<RadioStation> stationList = null;
        private readonly MediaPlayer.MediaPlayer mediaPlayer = new MediaPlayer.MediaPlayer();
        private readonly string defaultTxtStationFile = Path.Combine(Environment.CurrentDirectory, "Stations.txt");
        private readonly string defaultXmlStationFile = Path.Combine(Environment.CurrentDirectory, "Stations.xml");

        public Form1()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            SystemEvents.SessionSwitch += (s, e) => RefreshRadio();
            pictureBox1.Image = imageList1.Images[0];
            DragEnter += Form1_DragEnter;
            DragDrop += Form1_DragDrop;
            listBox1.MouseDown += ListBox1_MouseDown;
            listBox1.DoubleClick += ListBox1_DoubleClick;
            listBox1.KeyDown += ListBox1_KeyDown;
            VolumeScrollBar.ValueChanged += VolumeScrollBar_ValueChanged;
            SearchBox.TextChanged += SearchBoxTextChanged;
            SearchBox.KeyDown += TextBox1_KeyDown;
            notifyIcon1.MouseDown += NotifyIcon1_MouseDown;
            notifyIcon1.Icon = Properties.Resources.RadioIco;
            button1.KeyDown += Buttons_KeyDown;
            button2.KeyDown += Buttons_KeyDown;
            button3.KeyDown += Buttons_KeyDown;
            button4.KeyDown += Buttons_KeyDown;
            muteBox.KeyDown += Buttons_KeyDown;
            materialSwitch1.KeyDown += Buttons_KeyDown;
            themeManager.AddFormToManage(this);
            themeManager.ColorScheme = new ColorScheme
                (
                Primary.Yellow500,
                Primary.Blue500,
                Primary.Blue500,
                Accent.LightBlue200,
                TextShade.BLACK
                );
            label3.Text = DateTime.Now.ToShortDateString();
        }

        private void ShowRadio()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void HideRadio()
        {
            ShowInTaskbar = false;
            notifyIcon1.Text = Text;
        }

        private void CloseRadio()
        {
            isMinimize = false;
            Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideRadio();
            }
        }

        private void NotifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowRadio();
            }
            else
            {
                contextMenuStrip2.Show(MousePosition);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, false) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop, false)).GetFirst();
            if (!string.IsNullOrEmpty(fileName))
            {
                string[] extensions = { ".txt", ".xml" };
                string fileExtension = Path.GetExtension(fileName);
                if (extensions.Contains(fileExtension))
                {
                    ReadStationList(fileName);
                }
            }
        }

        private void ShowMessageBox(string message)
        {
            MsgBox messageBox = new MsgBox(message);
            messageBox.Show(this);
        }

        private void ReadStationList(string fileName)
        {
            stationList?.Clear();
            listBox1.Items.Clear();
            string extension = Path.GetExtension(fileName);
            string XMLextension = Path.GetExtension(defaultXmlStationFile);
            string TXTextension = Path.GetExtension(defaultTxtStationFile);

            if (extension.Equals(XMLextension))
            {
                stationList = serrializer.ReadFromFile(fileName);
            }
            else if (extension.Equals(TXTextension))
            {
                stationList = Utility.ReadStationsFromTxtFile(fileName);
            }
            else if (stationList == null)
            {
                stationList = new List<RadioStation>();
            }

            if (stationList?.Count > 0)
            {
                listBox1.Items.AddRange(stationList.ToArray());
            }
        }

        private void ShowVolume(int volume)
        {
            if (volume < 10)
            {
                label1.Text = $"     {volume}%";
            }
            else if (volume < 100)
            {
                label1.Text = $"   {volume}%";
            }
            else
            {
                label1.Text = $"{volume}%";
            }
        }

        private void Mute(bool mute)
        {
            if (mute)
            {
                lastVolume = VolumeScrollBar.Value;
                VolumeScrollBar.Value = 100;
                label1.Text = "Mute";
            }
            else
            {
                VolumeScrollBar.Value = lastVolume;
            }
        }

        private void PlayStation()
        {
            currentStation = listBox1.SelectedItem as RadioStation;
            if (currentStation != null)
            {
                if (currentStation.Name.Length > maxLengthString)
                {
                    Text = currentStation.Name + "         ";
                    timer1.Enabled = true;
                }
                else
                {
                    Text = currentStation.Name;
                    timer1.Enabled = false;
                }

                currentStation.PlayCount++;
                mediaPlayer.Open(currentStation.URL);
                playerState = MediaPlayerState.Playing;
            }
        }

        private void Stop()
        {
            mediaPlayer.Stop();
            playerState = MediaPlayerState.Stopped;
            timer1.Enabled = false;
            Text = "Internet Radio";
        }

        private void SearchBoxTextChanged(object sender, EventArgs e)
        {
            string searchItem = SearchBox.Text;
            listBox1.Items.Clear();

            foreach (RadioStation station in stationList)
            {
                if (station.Name.ContainsWithoutCase(searchItem))
                {
                    listBox1.Items.Add(station);
                }
            }

            if (string.IsNullOrEmpty(searchItem))
            {
                label2.Visible = true;
                listBox1.SelectedItem = currentStation;
            }
            else
            {
                label2.Visible = false;
            }

            pictureBox1.Visible = listBox1.Items.Count == 0;

            SortListBox(listBox1, sort);
        }

        private void KeysEvent(Keys key)
        {
            switch (key)
            {
                case Keys.Enter:
                case Keys.P:
                    PlayStation();
                    break;
                case Keys.G:
                    GetScreen();
                    break;
                case Keys.M:
                    muteBox.Checked = !muteBox.Checked;
                    break;
                case Keys.S:
                    Stop();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void Buttons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                KeysEvent(e.KeyData);
            }
        }

        private void ListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysEvent(e.KeyData);
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            PlayStation();
        }

        private void ListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void VolumeScrollBar_ValueChanged(object sender, EventArgs e)
        {
            int volume = 100 - VolumeScrollBar.Value;
            Volume = volume;
            ShowVolume(volume);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PlayStation();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.IsNullOrEmpty())
            {
                if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                {
                    listBox1.SelectedIndex++;
                }
                else
                {
                    listBox1.SelectedIndex = 0;
                }

                PlayStation();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.IsNullOrEmpty())
            {
                if (listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex--;
                }
                else
                {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

                PlayStation();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(INI.Parse("General", "X"), INI.Parse("General", "Y"));
            VolumeScrollBar.Value = INI.Parse("General", "Volume");
            materialSwitch1.Checked = INI.Read("General", "Theme").Equals("DARK");
            string fileName = File.Exists(defaultXmlStationFile) ? defaultXmlStationFile : defaultTxtStationFile;
            ReadStationList(fileName);
            Enum.TryParse(INI.Read("General", "Sort by"), out sort);
            minimizeToolStripMenuItem.Checked = isMinimize = INI.Parse<bool>("General", "MinimizeOnClose");
            toolStripComboBox1.Text = sort.ToString();
            listBox1.Text = INI.Read("Station", "CurrentStation");
            ShowVolume(100 - VolumeScrollBar.Value);
            PlayStation();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            INI.Write("General", "X", Location.X);
            INI.Write("General", "Y", Location.Y);
            int volume = !muteBox.Checked ? VolumeScrollBar.Value : lastVolume;
            INI.Write("General", "Volume", volume);
            INI.Write("General", "Theme", themeManager.Theme);
            INI.Write("General", "Sort by", sort);
            INI.Write("General", "MinimizeOnClose", minimizeToolStripMenuItem.Checked);
            INI.Write("Station", "CurrentStation", $"{currentStation}");
            serrializer.WriteToFile(defaultXmlStationFile, stationList);
        }

        private void MaterialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch1.Checked)
            {
                themeManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                themeManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
        }

        private void MuteBox_CheckedChanged(object sender, EventArgs e)
        {
            VolumeScrollBar.Enabled = !muteBox.Checked;
            Mute(muteBox.Checked);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Text = Text.Substring(1) + Text[0];
        }

        private void CopyStationAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is RadioStation station)
            {
                Clipboard.SetText(station.URL);
                ShowMessageBox($"URL station \"{station.Name}\" copied");
            }
        }

        private void RefreshRadio()
        {
            Invalidate();
            if (mediaPlayer.PlayState != MediaPlayer.MPPlayStateConstants.mpPlaying &&
                playerState == MediaPlayerState.Playing)
            {
                PlayStation();
            }
        }

        private void ReindexStationList(List<RadioStation> stationList)
        {
            for (int i = 0; i < stationList.Count; i++)
            {
                stationList[i].ID = i + 1;
            }
        }

        private void AddStation(List<RadioStation> stationList, ListBox listBox, int index, RadioStation item)
        {
            stationList.Insert(index, item);
            ReindexStationList(stationList);
            listBox.Items.Insert(index, item);
        }

        private void RemoveStation(List<RadioStation> stationList, ListBox listBox, RadioStation item)
        {
            stationList.Remove(item);
            ReindexStationList(stationList);
            listBox.Items.Remove(item);
        }

        private void SortListBox(ListBox listBox, IComparer<RadioStation> comparer)
        {
            if (listBox != null)
            {
                RadioStation[] stations = listBox.Items.OfType<RadioStation>();
                Array.Sort(stations, comparer);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(stations);
                listBox1.SelectedItem = currentStation;
            }
        }

        private void SortListBox(ListBox listBox, StationSort sort)
        {
            switch (sort)
            {
                case StationSort.Default:
                    SortListBox(listBox, null);
                    break;
                case StationSort.Name:
                    SortListBox(listBox, RadioStation.SortByName);
                    break;
                case StationSort.PlayCount:
                    SortListBox(listBox, RadioStation.SortByPlayingCount);
                    break;
            }
        }

        private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(toolStripComboBox1.Text, out sort);
            SortListBox(listBox1, sort);
        }

        private void ImportStationsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML File|*.xml|Text File|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReadStationList(openFileDialog1.FileName);
            }
        }

        private void ExportStationsToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "XML File|*.xml";
            saveFileDialog1.FileName = "Stations.xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                if (!string.IsNullOrEmpty(fileName) && stationList?.Count > 0)
                {
                    serrializer.WriteToFile(fileName, stationList);
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseRadio();
        }

        private void GetInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is RadioStation station)
            {
                MessageBox.Show(station.GetInfo);
            }
        }

        private void GetScreen()
        {
            saveFileDialog1.Filter = "Image File|*.png";
            saveFileDialog1.FileName = Utility.GetRandomName(".png");
            using (Image image = Utility.GetScreen(this))
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void GetScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetScreen();
        }

        private void AddNewStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StationEditor stationCreator = new StationEditor())
            {
                stationCreator.ShowDialog(this);
                RadioStation station = stationCreator.CreateNewStation();
                if (station != null)
                {
                    int index = listBox1.SelectedIndex + 1;
                    AddStation(stationList, listBox1, index, station);
                    SortListBox(listBox1, sort);
                    ShowMessageBox($"Station \'{station.Name}\' was added");
                }
                else
                {
                    ShowMessageBox("The station was not created and added");
                }
            }
        }

        private void RemoveSelectedStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Remove this station?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (listBox1.SelectedItem is RadioStation item)
                {
                    RemoveStation(stationList, listBox1, item);
                    SortListBox(listBox1, sort);
                    ShowMessageBox($"Station \'{item.Name}\' removed");
                }
            }
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is RadioStation item)
            {
                using (StationEditor stationCreator = new StationEditor(item))
                {
                    stationCreator.ShowDialog(this);
                }
                SortListBox(listBox1, sort);
                ShowMessageBox($"Radio station \'{item.Name}\' edited");
            }
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowRadio();
            CloseRadio();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRadio();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isMinimize)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void MinimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeToolStripMenuItem.Checked = !minimizeToolStripMenuItem.Checked;
            isMinimize = minimizeToolStripMenuItem.Checked;
        }

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM.WM_POWERBROADCAST &&
        //        m.WParam.ToInt32() == WM.PBT_APMRESUMESUSPEND)
        //    {
        //        RefreshRadio();
        //    }
        //    base.WndProc(ref m);
        //}
    }
}