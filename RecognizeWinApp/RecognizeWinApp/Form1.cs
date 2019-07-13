using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecognizeWinApp
{
    public partial class Form1 : Form
    {

        private Graphics g;
        private Pen pen;
        private int x, y;
        private bool moving;
        


        public Form1()
        {
            InitializeComponent();
            g = panel3.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            x = y = -1;
            moving = false;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = Color.Black;

        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = Color.DarkBlue;
        }
        private void pictureBox53_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = Color.Red;
        }
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = y = -1;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x != -1 && y != -1)
            {
                g.DrawLine(pen,new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        
    }
}
