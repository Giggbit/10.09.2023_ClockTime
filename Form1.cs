using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08._09._2023_Стрелочные_часы
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Bitmap bitmap_2;
        Graphics g;
        Graphics gr;
        Timer timer;
        int x = 209, y = 60;

        public Form1() {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bitmap_2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g = Graphics.FromImage(pictureBox1.Image = bitmap);
            gr = Graphics.FromImage(pictureBox2.Image = bitmap_2);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e) {
            g.Clear(BackColor);
            gr.Clear(BackColor);

            DateTime time = DateTime.Now;
            Font font = new Font("Arial", 14);

            g.DrawString("12", font, Brushes.Black, pictureBox1.Width / 2 - 15, 45);
            g.DrawString("6", font, Brushes.Black, pictureBox1.Width / 2 - 5, 265);
            g.DrawString("3", font, Brushes.Black, 265, pictureBox1.Height / 2 - 10);
            g.DrawString("9", font, Brushes.Black, 45, pictureBox1.Height / 2 - 10);
            g.DrawEllipse(Pens.Black, pictureBox1.Width / 8, pictureBox1.Height / 8, 250, 250);

            double HourAngle = (time.Hour * 360.0 / 12.0 + (time.Minute / 60.0) * (360.0 / 12.0)) - 90;
            double HourRadians = Math.PI * HourAngle / 180.0;
            int HourX = (pictureBox1.Width / 2) + (int)(Math.Cos(HourRadians) * (250 / 2 - 55));
            int HourY = (pictureBox1.Height / 2) + (int)(Math.Sin(HourRadians) * (250 / 2 - 55));
            g.DrawLine(Pens.Black, pictureBox1.Width / 2, pictureBox1.Height / 2, HourX, HourY);

            double MinAngle = time.Minute * 360 / 60 - 90;
            double MinRadians = Math.PI * MinAngle / 180;
            int MinX = (pictureBox1.Width / 2) + (int)(Math.Cos(MinRadians) * (250 / 2 - 35));
            int MinY = (pictureBox1.Height / 2) + (int)(Math.Sin(MinRadians) * (250 / 2 - 35));
            g.DrawLine(Pens.Black, pictureBox1.Width / 2, pictureBox1.Height / 2, MinX, MinY);

            double SecAngle = (time.Second * 360.0 / 60.0) - 90;
            double SecRadians = Math.PI * SecAngle / 180.0;
            int SecX = (pictureBox1.Width / 2) + (int)(Math.Cos(SecRadians) * (250 / 2 - 15));
            int SecY = (pictureBox1.Height / 2) + (int)(Math.Sin(SecRadians) * (250 / 2 - 15));
            g.DrawLine(Pens.Red, pictureBox1.Width / 2, pictureBox1.Height/ 2, SecX, SecY);

            g.FillEllipse(Brushes.Black, pictureBox1.Width / 2 - 4, pictureBox1.Height / 2 - 4, 8, 8);

            Font font_time = new Font("Arial", 20);
            gr.DrawRectangle(Pens.Black, pictureBox2.Width / 5, 0, 200, 45);
            gr.DrawString(time.ToLongTimeString(), font_time, Brushes.Black ,110, 5);

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }
    }
}
