using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using MariusSoft.WCSTools;

namespace MariusSoft.AsteroidHunter.Windows
{
    public partial class ImagePanel : UserControl
    {
        double[] _sourceData;
        Bitmap _bitmap;
        double _horizontalOffsetInPixels;
        double _verticalOffsetInPixels;
        int _imageWidth;
        int _imageHeight;
        private int _detectionsImageNumber = 0;
        private bool _isWorking;
        private DetectionFile _detectionFile;
        private double _zoomLevel = 1;
        private double _horizontalScrollTickSize;
        private double _verticalScrollTickSize;
        private Point _clickPosition;
        private Point _scrollPosition;
        private BitmapGenerator gen;

        // Delegate
        public delegate void IntHandler(int value);
        public delegate void PointFHandler(PointF value);
        public delegate void PointHandler(Point value);
        public delegate void PointHandlerDouble(Point value, Point value2);

        public event PointHandlerDouble Scrolled;
        public new event PointHandler MouseMove;


        #region 
        /// <summary>
        /// Current scrollbar values
        /// </summary>
        public Point ScrollValues
        {
            get { return new Point(hScrollBar.Value, vScrollBar.Value); }
        }

        /// <summary>
        /// Current zoom level
        /// </summary>
        public double ZoomLevel
        {
            get { return _zoomLevel; }
        }
        #endregion

        #region Constructors
        public ImagePanel()
        {
            InitializeComponent();
            _sourceData = new double[0];
            hScrollBar.Visible = false;
            vScrollBar.Visible = false;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Set the scroll values
        /// </summary>
        public void SetScroll(Point scroll)
        {
            hScrollBar.Value = Math.Min(hScrollBar.Maximum,  scroll.X);
            vScrollBar.Value = Math.Min(vScrollBar.Maximum, scroll.Y);
            CalculateOffsets();
            Invalidate();
        }

        /// <summary>
        /// Sets parameter
        /// </summary>
        public void SetParameters(double[] arr, int wid, int hei, bool resetScroll, DetectionFile detectionFile, BitmapGenerator gen, double scale = 65535, int detections = 0)
        {
            Console.Write("Loading Image in Panel");
            _detectionFile = detectionFile;
            _detectionsImageNumber = detections;
            _imageWidth = wid;
            _imageHeight = hei;
            this.gen = gen;
            _sourceData = arr;

            if (_bitmap != null)
            {
                _bitmap.Dispose();
                _bitmap = null;
            }

            CreateImage(scale);
            if (resetScroll)
            {
                vScrollBar.Visible = true;
                hScrollBar.Visible = true;
            }

            CalculateOffsets();
            Invalidate();

            Console.Write("Done" + Environment.NewLine);
        }

        /// <summary>
        /// Set visible levels
        /// </summary>
        /// <param name="black">The percent of the value to treat as dark</param>
        /// <param name="white">The perfect of the image to be treated as pure white</param>
        /// <param name="scale">The max value in the dataset</param>
        public void SetLevels(double black, double white, double scale)
        {
            if (_bitmap == null)
            {
                return;
            }
            _isWorking = true;

            double blackVal = scale * black;
            double scaled = 255 / scale;
            BitmapData bmd = _bitmap.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.ReadOnly, _bitmap.PixelFormat);

            // This 'unsafe' part of the code populates the bitmap _bitmap with data stored in _sourceData.
            // It does so using pointers, and therefore the need for 'unsafe'. 
            unsafe
            {
                int pixelSize = 3;
                int i, j, j1, i1;
                byte b;

                for (i = 0; i < bmd.Height; ++i)
                {
                    byte* row = (byte*)bmd.Scan0 + (i * bmd.Stride);
                    i1 = i * bmd.Width;

                    for (j = 0; j < bmd.Width; ++j)
                    {
                        j1 = j * pixelSize;

                        double va = _sourceData[i1 + j] - blackVal;
                        va *= white;

                        if (va > scale)
                        {
                            va = scale;
                        }
                        else if (va < 0)
                        {
                            va = 0;
                        }

                        b = (byte)(va * scaled);

                        row[j1] = b;            // Red
                        row[j1 + 1] = b;            // Green
                        row[j1 + 2] = b;            // Blue
                    }
                }
            } // end unsafe      
            _bitmap.UnlockBits(bmd);
            _isWorking = false;
            this.Invalidate();
        }

        /// <summary>
        /// Sets the detections to show
        /// </summary>
        public void ShowDetections(int detectionsToDraw)
        {
            _detectionsImageNumber = detectionsToDraw;
            Invalidate();
        }

        /// <summary>
        /// Scrool to coords
        /// </summary>
        public void GoTo(double x, double y)
        {
            SetScroll(new Point(
                (int)((x - ((panel.Width / ZoomLevel) / 2)) / _horizontalScrollTickSize),
                (int)((y- ((panel.Height / ZoomLevel) / 2)) / _verticalScrollTickSize )));
        }

        public void ZoomIn()
        {
            _zoomLevel = ZoomLevel * 1.1;
            CalculateOffsets();
            Invalidate();
        }

        public void ZoomOut()
        {
            _zoomLevel = ZoomLevel * .9;
            CalculateOffsets();
            Invalidate();
        }

        public void ZoomReset()
        {
            _zoomLevel = 1;
            CalculateOffsets();
            Invalidate();
        }

        #endregion

        #region Private Events
        /// <summary>
        /// Scroll
        /// </summary>
        private void scrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            CalculateOffsets();
            if (Scrolled != null)
            {
                Scrolled(ScrollValues, new Point((int)_horizontalOffsetInPixels, (int)_verticalOffsetInPixels));
            }
            Invalidate();
        }

        /// <summary>
        /// Mouse moved
        /// </summary>
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            //Let parent know
            if (MouseMove != null)
            {
                double movedX = e.X / _zoomLevel;
                double movedY = e.Y / _zoomLevel;

                MouseMove(new Point((int)(movedX + _horizontalOffsetInPixels) + 1, (int)(movedY + _verticalOffsetInPixels) + 1));
            }

            if (e.Button == MouseButtons.Left)
            {
                double movedX = ((_clickPosition.X - e.X) / ZoomLevel) / _horizontalScrollTickSize;
                double movedY = ((_clickPosition.Y - e.Y) / ZoomLevel) / _verticalScrollTickSize;

                hScrollBar.Value = (int) Math.Min(Math.Max(_scrollPosition.X + movedX, 0), hScrollBar.Maximum);
                vScrollBar.Value = (int) Math.Min(Math.Max(_scrollPosition.Y + movedY, 0), vScrollBar.Maximum);

                scrollBar_Scroll(null, null);
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            _clickPosition = e.Location;
            _scrollPosition = new Point(hScrollBar.Value, vScrollBar.Value);

            Cursor.Current = Cursors.Hand;
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            scrollBar_Scroll(null, null);
        }

        private void panel_MouseEnter(object sender, EventArgs e)
        {
            if (!Focused)
            {
                Focus();
            }
        }
        #endregion

        #region Private Helper Methods
        /// <summary>
        /// Calculate image offsets
        /// </summary>
        private void CalculateOffsets()
        {
            //Number of vertical increments
            int horizontalIncrements = ((hScrollBar.Maximum - hScrollBar.LargeChange + 1) - hScrollBar.Minimum);
            int verticalIncrements = ((vScrollBar.Maximum - vScrollBar.LargeChange + 1) - vScrollBar.Minimum);

            double maxX = _imageWidth - (panel.Width / _zoomLevel);
            double maxY = _imageHeight - (panel.Height / _zoomLevel);

            _horizontalScrollTickSize = (maxX / horizontalIncrements);
            _verticalScrollTickSize = (maxY / verticalIncrements);

            _horizontalOffsetInPixels = (maxX * ((double)hScrollBar.Value / horizontalIncrements));
            _verticalOffsetInPixels = (maxY * ((double)vScrollBar.Value / verticalIncrements));
        }

        /// <summary>
        /// Create the image from the image data
        /// </summary>
        /// <param name="scale"></param>
        private void CreateImage(double scale)
        {
            double scaled = 256 / scale;
            Bitmap bmp1 = new Bitmap(_imageWidth, _imageHeight, PixelFormat.Format24bppRgb);
            BitmapData bmd = bmp1.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.ReadOnly, bmp1.PixelFormat);

            // This 'unsafe' part of the code populates the bitmap _bitmap with data stored in _sourceData.
            // It does so using pointers, and therefore the need for 'unsafe'. 
            unsafe
            {
                int pixelSize = 3;
                int i, j, j1, i1;
                byte b;

                for (i = 0; i < bmd.Height; ++i)
                {
                    byte* row = (byte*)bmd.Scan0 + (i * bmd.Stride);
                    i1 = i * bmd.Width;

                    for (j = 0; j < bmd.Width; ++j)
                    {
                        b = (byte)(_sourceData[i1 + j] * scaled);
                        j1 = j * pixelSize;
                        row[j1] = b;            // Red
                        row[j1 + 1] = b;            // Green
                        row[j1 + 2] = b;            // Blue
                    }
                }
            } // end unsafe      
            bmp1.UnlockBits(bmd);
            _bitmap = bmp1;
        }

        /// <summary>
        /// Paint the image
        /// </summary>
        private void ImagePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

            if (_sourceData.Length > 0 && _bitmap != null && !_isWorking)
            {
                Graphics g = Graphics.FromHwnd(panel.Handle);
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                
                g.ScaleTransform((float)ZoomLevel, (float)ZoomLevel);
                g.TranslateTransform((float) -_horizontalOffsetInPixels, (float) -_verticalOffsetInPixels);

                g.DrawImage(_bitmap, 0, 0, _imageWidth, _imageHeight);

                if (_detectionsImageNumber > 0)
                {
                  // var c = _detectionFile.DetInfos.Where(x => x.DetNumber == 148);
                    double X;
                    double Y;
                    int width;

                    foreach (Detection detection in _detectionFile.DetInfos.Where(x => x.Frame == _detectionsImageNumber))
                    {

                        WCSUtil.ffxypx(detection.RaHours * 15, detection.DecDeg, gen.WcsReferenceValue.X, gen.WcsReferenceValue.Y, gen.WcsReferencePixel.X,
                            gen.WcsReferencePixel.Y, gen.WcsScale.X, gen.WcsScale.Y, gen.WcsRotation, '-' + gen.WcsType, out X,
                            out Y);

                        Y = _imageHeight - Y;

                        width = (int)Math.Max(detection.Fwhm*2, 14);

                        g.DrawRectangle(Pens.Green, (int)(_imageWidth - X - (width / 2.0)), (int)(Y - (width / 2.0)), width, width);
                        //g.DrawRectangle(Pens.Red, (int)(detection.X - (width / 2.0)), (int)(detection.Y - (width / 2.0)), width,width);
                        g.DrawString(detection.DetNumber.ToString(), new Font("Verdana", 5), Brushes.Green, (int)(_imageWidth - (X - width / 2.0)), (int)(Y - width / 2.0) - 10);
                    }
                }

                g.DrawRectangle(Pens.Blue, (int)_horizontalOffsetInPixels - 1, (int)_verticalOffsetInPixels - 1, 65, 65);
            }
        }
        #endregion
    }
}
