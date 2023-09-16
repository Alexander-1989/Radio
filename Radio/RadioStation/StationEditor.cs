using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radio
{
    public partial class StationEditor : Form
    {
        private readonly RadioStation currentStation = null;

        public StationEditor()
        {
            InitializeComponent();
        }

        public StationEditor(RadioStation station) : this()
        {
            currentStation = station;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            ValidateText();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int x = Owner.Location.X + ((Owner.Width - Width) / 2);
            int y = Owner.Location.Y + ((Owner.Height - Height) / 2);
            Location = new Point(x, y);
        }

        private void StationCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (currentStation != null && ValidateText())
            {
                currentStation.Name = textBox1.Text;
                currentStation.URL = textBox2.Text;
            }
        }
    }
}