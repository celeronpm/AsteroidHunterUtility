using System;

namespace MariusSoft.AsteroidHunter
{
    public class ExponentOp : GrayscaleOp
    {
        public override void ComputeLookUpTable(int low, int high, double gamma)
        {
            double scale1 = Math.Log10(256.0) / 255.0;
            double a, b;

            a = Math.Exp(scale1 * low) - 1.0;
            b = Math.Exp(scale1 * high) - 1.0;

            double scale2 = 255.0 / (b - a);
            int intVal;

            for (int i = 0; i < 256; ++i)
            {
                if (i <= low)
                    lookUpTable[i] = 0;
                else if (i > high)
                    lookUpTable[i] = 255;
                else
                {
                    intVal = Convert.ToInt32(Math.Round( scale2 * (Math.Exp(scale1 * i ) - 1.0 - a )));
                    if (intVal > 255) intVal = 255;
                    if (intVal < 0) intVal = 0;
                    lookUpTable[i] = (byte)intVal;
                }
            }
        }

        public override double ComputeScale(double low, double high, double value)
        {

            double scale1 = Math.Log10(high) / high;
            double a, b;

            a = Math.Exp(scale1 * low) - 1.0;
            b = Math.Exp(scale1 * high) - 1.0;

            double scale2 = high / (b - a);


            return scale2*(Math.Exp(scale1*value) - 1.0 - a);
        }
    }
}
