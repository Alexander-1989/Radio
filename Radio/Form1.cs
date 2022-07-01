using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using System.Linq;
using Radio.Service;

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
            string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop, false)).GetFirst();
            if (fileName?.Length > 0 && Path.GetExtension(fileName).Equals(".txt"))
            {
                ReadStationList(fileName);
            }
        }

        private void ReadStationList(string fileName)
        {
            listBox1.Items.Clear();
            stationList.Clear();
            string extension = Path.GetExtension(fileName);

            if (extension.Equals(".txt"))
            {
                stationList = InitStationList(fileName);
            }
            else if (extension.Equals(".xml"))
            {
                stationList = serrializer.ReadFromFile(fileName);
            }

            if (stationList?.Count > 0)
            {
                listBox1.Items.AddRange(stationList.ToArray());
            }
        }

        private List<RadioStation> InitStationList(string fileName)
        {
            List<RadioStation> stations = new List<RadioStation>();
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        int id = 1;
                        string prefix = "http";

                        while (!reader.EndOfStream)
                        {
                            int startIndex = 0;
                            int endIndex = -1;
                            string line = reader.ReadLine();

                            if (!string.IsNullOrEmpty(line) && line[0] != '#' && line[0] != ';' && (endIndex = line.IndexOf(prefix)) > -1)
                            {
                                string name = line.Substring(startIndex, endIndex - 1).Trim();
                                startIndex = endIndex;
                                endIndex = line.IndexOf(' ', startIndex);
                                string url = endIndex < startIndex ? line.Substring(startIndex) : line.Substring(startIndex, endIndex - startIndex);
                                stations.Add(new RadioStation(name, url, id++));
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
            return stations;
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

        private void KeysEvent(Keys key)
        {
            switch (key)
            {
                case Keys.Enter:
                case Keys.P:
                    PlayStation();
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
            Location = new Point(INI.Parse("General", "X"), INI.Parse("General", "Y"));
            VolumeScrollBar.Value = INI.Parse("General", "Volume");
            materialSwitch1.Checked = INI.Read("General", "Theme") == "DARK";

            if (File.Exists(defaultXmlStationFile))
            {
                stationList = serrializer.ReadFromFile(defaultXmlStationFile);
            }
            else if (File.Exists(defaultTxtStationFile))
            {
                stationList = InitStationList(defaultTxtStationFile);
            }
            else
            {
                stationList = new List<RadioStation>();
            }

            if (stationList?.Count > 0)
            {
                listBox1.Items.AddRange(stationList.ToArray());
            }

            string sortBy = INI.Read("General", "Sort by");
            if (!string.IsNullOrEmpty(sortBy) && !toolStripComboBox1.Text.Equals(sortBy))
            {
                toolStripComboBox1.Text = sortBy;
            }

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
            INI.Write("General", "Sort by", toolStripComboBox1.Text);
            INI.Write("Station", "CurrentStation", $"{currentStation}");
            if (!listBox1.IsEmpty())
            {
                serrializer.WriteToFile(defaultXmlStationFile, stationList);
            }
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

        private void ReIndexStations(List<RadioStation> stationList)
        {
            for (int i = 0; i < stationList.Count; i++)
            {
                stationList[i].ID = i + 1;
            }
        }

        private void AddItems(RadioStation[] list)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(list);
        }

        private void SortListBox(ListBox listBox, IComparer<RadioStation> comparer = null)
        {
            if (listBox != null)
            {
                RadioStation[] stations = listBox1.Items.OfType<RadioStation>().ToArray();
                Array.Sort(stations, comparer);
                AddItems(stations);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.Text)
            {
                case "Name":
                    SortListBox(listBox1, RadioStation.SortByName);
                    break;
                case "PlayCount":
                    SortListBox(listBox1, RadioStation.SortByPlayingCount);
                    break;
                default:
                    SortListBox(listBox1);
                    break;
            }
            listBox1.SelectedItem = currentStation;
        }

        private void loadStationsFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text File|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReadStationList(openFileDialog1.FileName);
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML File|*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = openFileDialog1.FileName;
                string destFile = Path.Combine(Environment.CurrentDirectory, "Stations.xml");
                File.Copy(sourceFile, destFile, true);
                ReadStationList(sourceFile);
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                if (!string.IsNullOrEmpty(fileName) && stationList?.Count > 0)
                {
                    serrializer.WriteToFile(fileName, stationList);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteSelectedStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stationList.Remove((RadioStation)listBox1.SelectedItem);
            ReIndexStations(stationList);
            AddItems(stationList.ToArray());
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