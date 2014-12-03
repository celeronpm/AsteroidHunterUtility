using System;

namespace MariusSoft.AsteroidHunter
{

    public class ArcSinH : GrayscaleOp
    {
        public override void ComputeLookUpTable(int low, int high, double gamma)
        {
            double a, b;

            double lHigh = asinh(high + 1.0);
            double lLow = asinh(low + 1.0);
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
                    intVal = (int) (a * asinh(i+1) +b) ;
                    if (intVal > 255) intVal = 255;
                    if (intVal < 0) intVal = 0;
                    lookUpTable[i] = (byte)intVal;
                }
            }
        }


        /// <summary>
        /// Returns the hyperbolic arc sine of the specified number.
        /// </summary>
        /// <param name="xx"></param>
        /// <returns></returns>
        public static double asinh(double xx)
        {
            double x;
            int sign;
            if (xx == 0.0) return xx;
            if (xx < 0.0)
            {
                sign = -1;
                x = -xx;
            }
            else
            {
                sign = 1;
                x = xx;
            }
            return sign * Math.Log(x + Math.Sqrt(x * x + 1));
        }


        public override double ComputeScale(double low, double high, double value)
        {
            return asinh(value);
        }
    }
}
