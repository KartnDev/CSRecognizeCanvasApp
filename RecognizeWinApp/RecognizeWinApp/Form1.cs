using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libsvm;

namespace RecognizeWinApp
{
    public partial class Form1 : Form
    {
       
        private Graphics g;
        private Pen pen;
        private int x, y;
        private bool moving;
        private int HEIGHT, WIDTH; 
        //data 
        private int[,] dataMatrix;
        private bool analisysValidation = false;


        public Form1(int height,int width)
        {
            InitializeComponent();
            g = panel3.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;            
            x = y = -1;
            moving = false;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            this.HEIGHT = height; this.WIDTH = width;
            dataMatrix = new int[height, width];
            fillZeros(dataMatrix, height, width);
        }

        private void fillZeros(int[,] matrix, int cols, int rows)
        {
            for(int i = 0; i < cols; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public void GetAnalisysValidation()
        {
            
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
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
                dataMatrix[(int)(e.Y / 20), (int)(e.X / 20)] = 1;               
            
            }
        }

        private void button1_Click(object sender, EventArgs e) //   transform button
        {
            for (int i = 0; i < this.HEIGHT; i++)
            {
                for (int j = 0; j < this.WIDTH; j++)
                {
                    Console.Write(dataMatrix[i, j] + " ");
                }
                Console.Write("\n");
            }

            analisysValidation = true;
            transformToMatrix();
        }


        private void transformToMatrix()
        {
            g.Clear(Color.WhiteSmoke);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("", "DataSet.txt"), true))
            {
                for (int i = 0; i < this.HEIGHT; i++)
                {
                    for (int j = 0; j < this.WIDTH; j++)
                    {
                        outputFile.WriteLine(dataMatrix[i, j]);
                    }
                }
            }

            


        }


        public int[,] getDataMatrix()
        {
            return dataMatrix;
        }


    }   
}
