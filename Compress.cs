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
    public partial class Compress : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        OpenFileDialog open = new OpenFileDialog();
        public string filename = "";

        public Compress()
        {
            InitializeComponent();
        }
        private void Compress_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }

        }

        private void Compress_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Compress_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
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

        private void Compress_Load(object sender, EventArgs e)
        {

        }

        private void back1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();

        }

        private void upload_Click(object sender, EventArgs e)
        {
            
            open.Multiselect = true;
            open.Filter = "Text File|*.txt|All Files|*.*";
            if(open.ShowDialog()==DialogResult.OK)
            {
                txtupload.Text += open.FileNames;
            }
            filename = open.FileName;



        }

		private void ucompress_Click(object sender, EventArgs e)
		{
			


			HuffmanCoding hc = new HuffmanCoding();
			hc.Compress(filename);
			hc.DisplayCodes();
		}

		private void txtupload_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
