using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCChanger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = $"{trackBar1.Value}";
            label2.Text = $"{trackBar2.Value}";
            label3.Text = $"{trackBar3.Value}";
            panel1.BackColor = Color.FromArgb(trackBar1.Value, 0, 0);
            panel2.BackColor = Color.FromArgb(0, trackBar2.Value, 0);
            panel3.BackColor = Color.FromArgb(0, 0, trackBar3.Value);
            panel4.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void Button_Apply_Click(object sender, EventArgs e)
        {
            ColorUtils.SetColor(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Color col = ColorUtils.GetColor();
            trackBar1.Value = col.R;
            trackBar2.Value = col.G;
            trackBar3.Value = col.B;
        }
    }
}
