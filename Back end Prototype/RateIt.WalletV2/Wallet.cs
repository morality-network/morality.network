using MoBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RateIt.Wallet
{
    public partial class Wallet : Form
    {

        public Wallet()
        {
            InitializeComponent();
            //tabControlNoHeader1.SelectedIndex = 4;
            //panel1.Visible = (false);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            //16
            if (richTextBox2.Text.Length>7)
            {
                this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }else
            {
                this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 31F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel18.Visible = false;
            panel6.Visible = true;
            panel17.Visible = false;
            panel16.Visible = false;
            panel36.Visible = false;
            tabControlNoHeader1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel18.Visible = true;
            panel6.Visible = false;
            panel17.Visible = false;
            panel16.Visible = false;
            panel36.Visible = false;
            tabControlNoHeader1.SelectedIndex = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel17.Visible = true;
            panel18.Visible = false;
            panel6.Visible = false;
            panel16.Visible = false;
            panel36.Visible = false;
            tabControlNoHeader1.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel16.Visible = true;
            panel17.Visible = false;
            panel18.Visible = false;
            panel6.Visible = false;
            panel36.Visible = false;
            tabControlNoHeader1.SelectedIndex = 1;
        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel16.Visible = false;
            panel17.Visible = false;
            panel18.Visible = false;
            panel6.Visible = false;
            panel36.Visible = true;
        }

        private void sPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_MouseHover(object sender, EventArgs e)
        {
        }

        private void transactionPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
