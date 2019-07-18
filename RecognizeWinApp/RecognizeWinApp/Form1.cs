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
        private Queue<string> data;
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
            WriteLabels();
            data = new Queue<string>();
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
            string temp = "";
            for (int i = 0; i < this.HEIGHT; i++)
            {
                for (int j = 0; j < this.WIDTH; j++)
                {
                    Console.Write(dataMatrix[i, j]);
                    temp += dataMatrix[i, j];
                }
                Console.Write("\n");

            }
            data.Enqueue(temp);
            temp = "";

            // Open the file to read from.

            

            transformToMatrix();
        }



        private void WriteLabels()
        {
            using (StreamReader sr = File.OpenText("trainP.csv"))
            {
                if (sr.ReadLine() == null)
                {
                    sr.Close();
                    using (StreamWriter sw = File.AppendText("trainP.csv"))
                    {
                        string LabelStr = "label,";
                        for (int i = 0; i < this.HEIGHT * this.WIDTH - 1; i++)
                        {
                            LabelStr += "pixel" + i + ",";
                        }
                        LabelStr += "pixel" + (this.HEIGHT * this.WIDTH - 1);
                        sw.WriteLine(LabelStr);
                    }
                }
            }
        }




        private void Button2_Click(object sender, EventArgs e) //   train
        {

             
                using (StreamWriter sw = File.AppendText("trainP.csv"))
                {
                    foreach (string item in data)
                    {
                        sw.WriteLine(item + Environment.NewLine);
                    }

                }

                Console.WriteLine("\n\n\n\n\n");
                using (StreamReader sr = File.OpenText("trainP.csv"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            
        }

        private void Button3_Click(object sender, EventArgs e) // compute
        {

        }

        private void transformToMatrix()
        {
            g.Clear(Color.WhiteSmoke);
            for (int i = 0; i < this.HEIGHT; i++)
            {
                for (int j = 0; j < this.WIDTH; j++)
                {     
                    
                }
            }
        }


        private void WriteMatrixFile()
        {




            //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", csv);
        }



        public int[,] getDataMatrix()
        {
            return dataMatrix;
        }


    }   
}
