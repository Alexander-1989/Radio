using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;

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
        private string lastText;
        private string currentStationFile;
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
        private readonly MaterialSkinManager themeManager = MaterialSkinManager.Instance;
        private readonly List<RadioStation> stationList = new List<RadioStation>();
        private readonly MediaPlayer.MediaPlayer mediaPlayer = new MediaPlayer.MediaPlayer();
        private readonly string defaultStationFile = Path.Combine(Environment.CurrentDirectory, "Stations.txt");

        public Form1()
        {
            InitializeComponent();
            SystemEvents.SessionSwitch += (s, e) => RefreshRadio();
            DragEnter += Form1_DragEnter;
            DragDrop += Form1_DragDrop;
            listBox1.MouseDown += ListBox1_MouseDown;
            listBox1.DoubleClick += ListBox1_DoubleClick;
            listBox1.KeyDown += ListBox1_KeyDown;
            VolumeScrollBar.ValueChanged += VolumeScrollBar_ValueChanged;
            SearchBox.TextChanged += SearchBoxTextChanged;
            SearchBox.KeyDown += TextBox1_KeyDown;
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
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, false) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] dropFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (!dropFiles.IsNullOrEmpty() && Path.GetExtension(dropFiles[0]).Equals(".txt"))
            {
                currentStationFile = dropFiles[0];
                InitStationList(currentStationFile);
            }
        }

        private void InitStationList(string fileName)
        {
            listBox1.Items.Clear();
            stationList.Clear();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    int id = 1;
                    int index = -1;
                    string prefix = "http";

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (!string.IsNullOrEmpty(line) &&
                            line[0] != '#' && line[0] != ';' &&
                            (index = line.LastIndexOf(prefix)) > -1)
                        {
                            string name = line.Substring(0, index - 1).Trim();
                            string url = line.Substring(index).Trim();
                            RadioStation station = new RadioStation(name, url, id++);
                            stationList.Add(station);
                            listBox1.Items.Add(station);
                        }
                    }
                }
            }
            catch (Exception) { }
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

                if (currentStation != null)
                {
                    Text = currentStation.Name + " (Mute)         ";
                }
            }
            else
            {
                VolumeScrollBar.Value = lastVolume;
                Text = lastText;
            }
        }

        private void PlayStation()
        {
            currentStation = listBox1.SelectedItem as RadioStation;
            if (currentStation != null)
            {
                if (currentStation.Name.Length > maxLengthString)
                {
                    lastText = currentStation.Name + "         ";
                    timer1.Enabled = true;
                }
                else
                {
                    lastText = currentStation.Name;
                    timer1.Enabled = false;
                }

                Text = lastText;
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

        private bool Contains(string strA, string strB)
        {
            return strA.IndexOf(strB, StringComparison.OrdinalIgnoreCase) > -1;
        }

        private void SearchBoxTextChanged(object sender, EventArgs e)
        {
            string item = SearchBox.Text;
            listBox1.Items.Clear();

            foreach (RadioStation station in stationList)
            {
                if (Contains(station.Name, item))
                {
                    listBox1.Items.Add(station);
                }
            }

            if (string.IsNullOrEmpty(item))
            {
                label2.Visible = true;
                listBox1.SelectedItem = currentStation;
            }
            else
            {
                label2.Visible = false;
            }
        }

        private void Buttons_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.M:
                    muteBox.Checked = !muteBox.Checked;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void ListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    PlayStation();
                    break;
                case Keys.M:
                    muteBox.Checked = !muteBox.Checked;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
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
            if (e.Button == MouseButtons.Right && !listBox1.IsEmpty())
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

        private void button1_Click(object sender, EventArgs e)
        {
            PlayStation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!listBox1.IsEmpty())
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (!listBox1.IsEmpty())
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

        private void button4_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(INI.Parse("Main", "X"), INI.Parse("Main", "Y"));
            VolumeScrollBar.Value = INI.Parse("Main", "Volume");
            materialSwitch1.Checked = INI.Read("Main", "Theme") == "DARK";
            currentStationFile = INI.Read("Main", "StationList");
            if (!File.Exists(currentStationFile))
            {
                currentStationFile = defaultStationFile;
            }
            InitStationList(currentStationFile);
            listBox1.Text = INI.Read("Main", "CurrentStation");
            ShowVolume(100 - VolumeScrollBar.Value);
            PlayStation();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            INI.Write("Main", "X", Location.X);
            INI.Write("Main", "Y", Location.Y);
            int volume = !muteBox.Checked ? VolumeScrollBar.Value : lastVolume;
            INI.Write("Main", "Volume", volume);
            INI.Write("Main", "Theme", themeManager.Theme);
            INI.Write("Main", "StationList", currentStationFile);
            INI.Write("Main", "CurrentStation", $"{currentStation}");
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
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

        private void muteBox_CheckedChanged(object sender, EventArgs e)
        {
            VolumeScrollBar.Enabled = !muteBox.Checked;
            Mute(muteBox.Checked);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = Text.Substring(1) + Text[0];
        }

        private void copyStationAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is RadioStation station)
            {
                Clipboard.SetText(station.URL);
                MsgBox message = new MsgBox($"URL station \"{station.Name}\" copied");
                message.Show(this);
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