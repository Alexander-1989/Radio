using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radio
{
    public partial class StationEditor : Form
    {
        private readonly RadioStation _currentStation = null;

        public StationEditor() : this(null) { }

        public StationEditor(RadioStation station)
        {
            InitializeComponent();
            _currentStation = station;
            if (station != null)
            {
                textBox1.Text = station.Name;
                textBox2.Text = station.URL;
            }
        }

        private bool ValidateText()
        {
            return textBox1.GetValidator().SetValidateRules().Validate() &
                textBox2.GetValidator().SetValidateRules("http", "https").Validate();
        }

        public RadioStation CreateNewStation()
        {
            return ValidateText() ? new RadioStation(textBox1.Text, textBox2.Text) : null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateText();
        }

        public new void ShowDialog(IWin32Window owner)
        {
            if (owner is Form form)
            {
                int x = form.Location.X + ((form.Width - Width) / 2);
                int y = form.Location.Y + ((form.Height - Height) / 2);
                Location = new Point(x, y);
            }
            base.ShowDialog(owner);
        }

        private void StationCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_currentStation != null && ValidateText())
            {
                _currentStation.Name = textBox1.Text;
                _currentStation.URL = textBox2.Text;
            }
        }

        private void StationEditor_Load(object sender, EventArgs e)
        {

        }
    }
}