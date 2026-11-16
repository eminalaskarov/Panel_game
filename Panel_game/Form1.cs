using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Panel_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        Random g = new Random();
        Random b = new Random();

        Random xL = new Random();
        Random yL = new Random();
        int count = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Users\alesk\Desktop\img\bomba.png";
            pictureBox1.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel p = new Panel();
            p.Size = new Size(60, 60);
            p.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
            p.BackColor = Color.FromArgb(r.Next(0, 256), g.Next(0, 256), b.Next(0, 256));
            this.Controls.Add(p);

            if (p.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                MessageBox.Show("Oyun bitdi! Xalınız: " + count.ToString());
                OyunuSifirla();
            }
            else
            {
                count++;
                label2.Text = count.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OyunuSifirla()
        {
            List<Panel> silinecekler = new List<Panel>();

            foreach (Control c in this.Controls)
            {
                if (c is Panel && c != panel1)
                {
                    silinecekler.Add((Panel)c);
                }
            }

            foreach (Panel p in silinecekler)
            {
                this.Controls.Remove(p);
                p.Dispose();
            }

            count = 0;
            label2.Text = count.ToString();
            pictureBox1.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
        }
    }
}