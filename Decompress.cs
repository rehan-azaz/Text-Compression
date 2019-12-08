using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Compression
{
    public partial class Decompress : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        OpenFileDialog open = new OpenFileDialog();
        public Decompress()
        {
            InitializeComponent();
        }

        private void Decompress_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Decompress_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Decompress_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void buttonclose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void buttonmin_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void back2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Decompress_Load(object sender, EventArgs e)
        {

        }

        private void dupload_Click(object sender, EventArgs e)
        {
            open.Filter = "Rar File|*.rar|Zip File|*.zip";
            open.Multiselect = true;
            if(open.ShowDialog()==DialogResult.OK)
            {
                txtdeupload.Text = open.FileName;
            }
        }
    }
}
