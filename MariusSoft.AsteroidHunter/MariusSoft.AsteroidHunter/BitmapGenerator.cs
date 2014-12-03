using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using nom.tam.fits;

namespace MariusSoft.AsteroidHunter
{
    public class BitmapGenerator
    {
        #region Private variables
        #region Default Image
        /// <summary>
        /// The default bits given for the FITS image
        /// </summary>
        private readonly double[] _inputData;

        /// <summary>
        /// Statistics for the default FITS image
        /// </summary>
        private readonly BitmapStatistics _inputStatistics;

        /// <summary>
        /// Size of the input image
        /// </summary>
        private readonly Size _inputSize;
        #endregion

        #region Default coordinate information

        private PointF _WCSReferenceValue;
        private PointF _WCSReferencePixel;
        private PointF _WCSInclination;
        private PointF _WCSScale;
        private double _WCSRotation;
        private string _WCSType;
        #endregion

        #region Modified Image
        /// <summary>
        /// The default bits given for the FITS image
        /// </summary>
        private readonly double[] _modifiedData;

        /// <summary>
        /// Statistics for the modified FITS image
        /// </summary>
        private readonly BitmapStatistics _modifiedStatistics;
        #endregion
        #endregion

        #region Properties
        /// <summary>
        /// Statistics for the default FITS image
        /// </summary>
        public BitmapStatistics InputStatistics
        {
            get { return _inputStatistics; }
        }

        /// <summary>
        /// Size of the input image
        /// </summary>
        public Size InputSize
        {
            get { return _inputSize; }
        }

        /// <summary>
        /// The default bits given for the FITS image
        /// </summary>
        public double[] InputData
        {
            get { return _inputData; }
        }

        /// <summary>
        /// The default bits given for the FITS image
        /// </summary>
        public double[] ModifiedData
        {
            get { return _modifiedData; }
        }

        /// <summary>
        /// Statistics for the modified FITS image
        /// </summary>
        public BitmapStatistics ModifiedStatistics
        {
            get { return _modifiedStatistics; }
        }

        public PointF WcsReferenceValue
        {
            get { return _WCSReferenceValue; }
        }

        public PointF WcsReferencePixel
        {
            get { return _WCSReferencePixel; }
         
        }

        public double WcsRotation
        {
            get { return _WCSRotation; }
        }

        public PointF WcsInclination
        {
            get { return _WCSInclination; }
        }

        public string WcsType
        {
            get { return _WCSType; }
        }

        public PointF WcsScale
        {
            get { return _WCSScale; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor 
        /// </summary>
        /// <param name="fitsImage">FITS image to load image from</param>
        public BitmapGenerator(string fitsImage)
        {
            if (!File.Exists(fitsImage))
            {
                fitsImage = fitsImage.Replace("arch", "fits");
            }

            //Load FITS _modifiedBitmapData
            Fits f = new Fits(fitsImage);
            BasicHDU[] hdus = f.Read();
            hdus[0].Info();

            _WCSReferenceValue = new PointF(float.Parse(hdus[0].Header.FindCard("CRVAL1").Value), float.Parse(hdus[0].Header.FindCard("CRVAL2").Value));
            _WCSReferencePixel = new PointF(float.Parse(hdus[0].Header.FindCard("CRPIX1").Value), float.Parse(hdus[0].Header.FindCard("CRPIX2").Value));
            _WCSScale = new PointF(float.Parse(hdus[0].Header.FindCard("CDELT1").Value), float.Parse(hdus[0].Header.FindCard("CDELT2").Value));
            _WCSRotation = -180 + double.Parse(hdus[0].Header.FindCard("CROTA1").Value);
            _WCSType = hdus[0].Header.FindCard("CTYPE1").Value.Split('-').Last();
            

            _inputSize = new Size(hdus[0].Axes[1], hdus[0].Axes[0]);
            _inputData = new double[hdus[0].Axes[1] * hdus[0].Axes[0]];
            _modifiedData = new double[_inputData.Length];
            _inputStatistics = new BitmapStatistics(ref _inputData);

            Array dataAray = (Array)hdus[0].Data.Kernel;
            for (int y = 0; y < InputSize.Height; y++)
            {
                short[] row = (short[])dataAray.GetValue(y);

                for (int x = 0; x < InputSize.Width; x++)
                {
                    //Normalize the short to an int to support full range of values
                    int val = row[x] + short.MaxValue+1;

                    InputData[(y * InputSize.Width) + x] = val;
                }
            }

            f.Close();
            f = null;

            _inputStatistics.Recalculate();
            _modifiedStatistics = new BitmapStatistics(ref _modifiedData);
            ResetToDefault();
            ModifiedStatistics.Recalculate();
        }
        #endregion

        /// <summary>
        /// Resets the modified bitmap to the default FITS image
        /// </summary>
        public void ResetToDefault()
        {
            Array.Copy(_inputData, _modifiedData, _inputData.Length);
            _modifiedStatistics.CopyFrom(InputStatistics);
        }

        /// <summary>
        /// Scale the image by subtracting the min, limiting the max, and scaling to desired value
        /// </summary>
        public void Scale(double min, double max, double maxscale, GrayscaleOp operation)
        {
            const double valueScale =(short.MaxValue*2) + 1;

            double diffComputed = ((_inputStatistics.Max - _inputStatistics.Min) / (max - min));
            double scale = maxscale / valueScale;

            for (int i = 0; i < _inputData.Length; i++)
            {
                _modifiedData[i] = Math.Max(0, (Math.Min((((_inputData[i] - min) * diffComputed) + min), max) * scale));

            }

            double minimum = _modifiedData.Min();
            double maximum = _modifiedData.Max();
            

             for (int i = 0; i < _modifiedData.Length; i++)
            {
                _modifiedData[i] = operation.ComputeScale(minimum, maximum, _modifiedData[i]);
            }
        }


        #region Private Methods
        private string getFirstValue(string data)
        {
            while (data.Contains("  "))
            {
                data = data.Replace("  ", " ");
            }

            return data.Split(' ')[0];
        }

        private void FromShort(short number, out byte byte1, out byte byte2)
        {
            byte2 = (byte)(number >> 8);
            byte1 = (byte)(number & 255);
        }

        private int GetStride(int width, PixelFormat pxFormat)
        {
            //float bitsPerPixel = System.Drawing.Image.GetPixelFormatSize(format);
            int bitsPerPixel = ((int)pxFormat >> 8) & 0xFF;
            //Number of bits used to store the image _modifiedBitmapData per line (only the valid _modifiedBitmapData)
            int validBitsPerLine = width * bitsPerPixel;
            //4 bytes for every int32 (32 bits)
            int stride = ((validBitsPerLine + 31) / 32) * 4;
            return stride;
        }
        #endregion
    }
}