using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RandomPointCurve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //private Point startPoint = new Point(1, 1);
        //private Point endPoint = new Point(250, 250);

        //private void RandomPointCurve_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    g.Clear(Color.Wheat);
        //    int numPoints = 100;
        //    Point[] points = new Point[numPoints];

        //    Random random = new Random();

        //    for (int i = 0; i < numPoints; i++)
        //    {
        //        int x = startPoint.X + (endPoint.X - startPoint.X) * i / (numPoints - 1);
        //        int y = startPoint.Y + (endPoint.Y - startPoint.Y) * i / (numPoints - 1);

        //        int offsetX = (int)(random.NextDouble() * 20 - 10);
        //        int offsetY = (int)(random.NextDouble() * 20 - 10);

        //        x += offsetX;
        //        y += offsetY;

        //        points[i] = new Point(x, y);
        //    }

        //    g.DrawCurve(new Pen(Color.Black, 3), points);

        //}


        private Point startPoint = new Point(1, 1);
        private Point endPoint = new Point(250, 250);

        //private void PointCurve_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    g.Clear(Color.Wheat);
        //    Pen pen = new Pen(Color.Black, 3);

        //    int numPoints = 100;
        //    Point[] points = new Point[numPoints];

        //    Random random = new Random();

        //    int numberOfTheJaggednessOfTheCurve = // custom;

        //    for (int i = 0; i < numPoints; i++)
        //    {
        //        int x = ...
        //        int y = ...



        //        points[i] = new Point(x, y);
        //    }

        //    g.SmoothingMode = SmoothingMode.AntiAlias;
        //    g.DrawCurve(pen, points);
        //}

        private void PointCurve_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Wheat);
            Pen pen = new Pen(Color.Black, 3);

            int numPoints = 10;
            Point[] points = new Point[numPoints];

            Random random = new Random();

            // Introduce a parameter to control the jaggedness of the curve
            int jaggedness = 30; // Adjust this value to control the degree of randomness

            for (int i = 0; i < numPoints; i++)
            {
                int x = startPoint.X + (endPoint.X - startPoint.X) * i / (numPoints - 1);
                int y = startPoint.Y + (endPoint.Y - startPoint.Y) * i / (numPoints - 1);

                // Randomly offset the x and y coordinates based on the jaggedness parameter
                int offsetX = (int)(random.NextDouble() * jaggedness - jaggedness / 2);
                int offsetY = (int)(random.NextDouble() * jaggedness - jaggedness / 2);

                x += offsetX;
                y += offsetY;

                points[i] = new Point(x, y);
            }

            //g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawCurve(pen, points);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = null;
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(PointCurve_Paint);
            pictureBox1.Refresh();
        }

    }
}