using System;
using System.Linq;

namespace MariusSoft.AsteroidHunter
{
    /// <summary>
    /// Enum that represents statistics about an image
    /// </summary>
    public class BitmapStatistics
    {
        private readonly double[] _data;

        public double Min { get; set; }

        public double Max { get; set; }

        public double Mean { get; set; }

        public double Median { get; set; }

        public double StandardDeviation { get; set; }

        public void Recalculate()
        {
            Console.Write("Recalculating Image Stats    ");

            Min = _data.Min();
            Max = _data.Max();

            double ret = 0;
            if (_data.Count() > 0)
            {
                //Compute the Average      
                double avg = _data.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = _data.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (_data.Count() - 1));
            }

            StandardDeviation = ret;
            double s = _data.Aggregate<double, double>(0, (current, t) => current + t);
            Mean = s / _data.Length;

            //double[] temp = new double[_data.Length];
            //Array.Copy(_data, temp, _data.Length);
            //Array.Sort(temp);
            //double mid = (temp.Length - 1) / 2.0;
            //Median =  (temp[(int)(mid)] + temp[(int)(mid + 0.5)]) / 2.0;
           // temp = null;

            Console.Write("Done" + Environment.NewLine);
        }
        public BitmapStatistics(ref double[] data)
        {
            _data = data;
        }

        public void CopyFrom(BitmapStatistics stats)
        {
            Min = stats.Min;
            Max = stats.Max;
            Mean = stats.Mean;
            Median = stats.Median;
            StandardDeviation = stats.StandardDeviation;
        }
    }
}