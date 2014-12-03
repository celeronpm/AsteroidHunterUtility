using System;

namespace MariusSoft.AsteroidHunter
{
    public class LogOp : GrayscaleOp
    {
        public override void ComputeLookUpTable(int low, int high, double gamma)
        {
            double a, b;            

            double lHigh = Math.Log10(high + 1.0);
            double lLow = Math.Log10(low + 1.0);
            double range = lHigh - lLow;

            a = 255.0 / range;
            b = -a * lLow;
            int intVal;

            for (int i = 0; i < 256; ++i)
            {
                if (i <= low)
                    lookUpTable[i] = 0;
                else if (i > high)
                    lookUpTable[i] = 255;
                else
                {
                    intVal = Convert.ToInt32(a * Math.Log10(i + 1) + b);
                    if (intVal > 255) intVal = 255;
                    if (intVal < 0) intVal = 0;
                    lookUpTable[i] = (byte)intVal;
                }
            }
        }

        public override double ComputeScale(double low, double high, double value)
        {
            return ComputeScale(low, high, value, 10);
        }

        public double ComputeScale(double low, double high, double value, double logBase)
        {
            double lHigh = Math.Log(high + 1.0, logBase);
            double lLow = Math.Log(low + 1.0, logBase);
            double range = lHigh - lLow;
            double a = high / range;
            double b = -a * low;

            return a * Math.Log(value + 1, logBase) + b;
        }
    }
}