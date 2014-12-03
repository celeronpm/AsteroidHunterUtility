using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using MariusSoft.AsteroidHunter;

namespace PointProcessing
{
    /// <summary>
    /// Graph Control
    /// User control to display the histogram of an image. Uses GDI+ methods to draw 
    /// the histogram, and draw the tick marks and boundary lines.
    /// 
    /// Exposes just one public method:
    /// 1. SetImage, to set the pixel (bytes) values corresponding to an 8-bit grayscale image.
    ///    Internally, this method creates the histogram (a 256-element int array), and depicts 
    ///    this histogram graphically. Fits the histogram into the display area.
    ///    
    /// Exposes one property: HistMax, which is the maximum value in the histogram, to be displayed
    ///    in the parent form.
    /// </summary>
    public class GraphControl : UserControl
    {
        double[] pixels8;
        double[] histogram = new double[0];
        double histMax;
        int margin;
        int smallMargin;
        private bool creating;

        private double black;
        private double white;

        public GraphControl()
        {
            InitializeComponent();
            pixels8 = new double[0];
            margin = 10;
            smallMargin = 5;
            histMax = 0;
        }

        public void SetRange(double Black, double White)
        {
            black = Black;
            white = White;
            Invalidate();
        }

        public void SetImage(double[] pix, double Black, double White)
        {
            black = Black;
            white = White;
            pixels8 = pix;
            CreateHistogram();
            Invalidate();
        }

        private void DrawBoundary()
        {
            Point p1 = new Point(margin, margin);
            Point p2 = new Point(Width - margin, margin);
            Point p3 = new Point(Width - margin, Height - margin);
            Point p4 = new Point(margin, Height - margin);
            Graphics g = Graphics.FromHwnd(this.Handle);
            Pen p = new Pen(Color.Firebrick);
            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p2, p3);
            g.DrawLine(p, p3, p4);
            g.DrawLine(p, p4, p1);

            Point pv1, pv2, ph1, ph2;
            pv1 = new Point();
            pv2 = new Point();
            ph1 = new Point();
            ph2 = new Point();
            int i, iNoVDivisions = 10, iNoHDivisions = 10;
            int iVertSpace = Convert.ToInt32((Height - 2.0 * margin) / iNoVDivisions);
            int iHorizSpace = Convert.ToInt32((Width - 2.0 * margin) / iNoHDivisions);

            // Tick marks for the vertical axis
            for (i = 0; i < iNoVDivisions; ++i)
            {
                pv1.X = smallMargin;
                pv1.Y = margin + i * iVertSpace;
                pv2.X = margin;
                pv2.Y = pv1.Y;
                g.DrawLine(p, pv1, pv2);
            }
            // Draw the last tick mark for vertical axis
            pv1.Y = Height - margin;
            pv2.Y = pv1.Y;
            g.DrawLine(p, pv1, pv2);

            // Tick marks for the horizontal axis
            for (i = 0; i < iNoHDivisions; ++i)
            {
                ph1.X = margin + i * iHorizSpace;
                ph1.Y = Height - margin;
                ph2.X = ph1.X;
                ph2.Y = Height - smallMargin;
                g.DrawLine(p, ph1, ph2);
            }
            // Draw the last tick mark for horizontal axis
            ph1.X = Width - margin;
            ph2.X = ph1.X;
            g.DrawLine(p, ph1, ph2);

            p.Dispose();
        }

        private void DrawHistogram()
        {
            // Find out the horizontal scale
            int xLength = Width - (2 * margin);
            //List<Point> listPoint = new List<Point>();

            int maxX = Width-margin;
            int minX = margin;

            // Find out what the vertical scale is
            double yLength = Height - (2 * margin);

            // Draw the different lines comprising the histogram
            int i;
            Point pt1, pt2;
            pt1 = new Point();
            pt2 = new Point();

            Pen p = new Pen(Color.Gray);
            p.Width = xLength / (maxX - minX);
            Pen p1 = new Pen(Color.DarkGray);
            Graphics g = Graphics.FromHwnd(Handle);
          
            // Demonstrates two different ways of drawing the histogram
            for (i = 0; i < xLength; ++i)
            {
                pt1.X = margin +1 + i;
                pt1.Y = Height - margin;

                pt2.X = pt1.X;
                pt2.Y = (int)(pt1.Y - histogram[i]);

                g.DrawLine(p, pt1, pt2);
               // listPoint.Add(pt2);
            }


            p = new Pen(Color.Black);
            pt1.X = (int)(margin + 1 + (xLength*black));
            pt1.Y = Height - margin;
            pt2.X = pt1.X;
            pt2.Y = (int)(pt1.Y - yLength);
            g.DrawLine(p, pt1, pt2);

            pt1.X = (int)(margin + 1 + (xLength * (1/white)));
            pt1.Y = Height - margin;
            pt2.X = pt1.X;
            pt2.Y = (int)(pt1.Y - yLength);
            g.DrawLine(p, pt1, pt2);

            p.Dispose();
            p1.Dispose();
        }

        private void CreateHistogram()
        {
            if (pixels8.Length > 0 && Width > 0)
            {
                creating = true;
                int xLength = Width - (2 * margin);
                histogram = new double[xLength];
                double modifier = (histogram.Length-1) / pixels8.Max();

                histMax = 0;
                int i;
                int iVal;

                for (i = 0; i < pixels8.Length; ++i)
                {
                    iVal = (int)(pixels8[i] * modifier);
                    ++histogram[iVal];
                }

                double max = histogram.Max();
                LogOp op = new LogOp();
                for (i = 0; i < histogram.Length; ++i)
                {
                    histogram[i] = op.ComputeScale(0, max, histogram[i]);
                }

                double min = histogram.Where(x => x > 0).OrderBy(x => x).First();
                for (i = 0; i < histogram.Length; ++i)
                {
                    histogram[i] = Math.Max(0, histogram[i] - min);
                }


                histMax = histogram.Max();
                // Find out what the vertical scale is
                double yLength = Height - (2 * margin);
                double scale = (yLength / histMax);

                for (i = 0; i < histogram.Length; ++i)
                {
                    histogram[i] = (double)(histogram[i] * scale);
                }

                creating = false;
            }
        }

        private void GraphControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (pixels8.Length > 0 && !creating)
            {
                DrawBoundary();
                DrawHistogram();
            }
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GraphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GraphControl";
            this.Size = new System.Drawing.Size(237, 151);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphControl_Paint);
            this.Resize += new System.EventHandler(this.GraphControl_Resize);
            this.ResumeLayout(false);

        }

        private void GraphControl_Resize(object sender, EventArgs e)
        {
            CreateHistogram();
            Invalidate();
        }
    }
}