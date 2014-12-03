using System;

namespace MariusSoft.AsteroidHunter
{
    public class LinearOp : GrayscaleOp
    {
        public override void ComputeLookUpTable(int low, int high, double gamma)
        {
            double a, b;
            int range = high - low;
            a = 255.0 / range;
            b = -a * low;
            int intVal;

            for (int i = 0; i < 256; ++i)
            {
                if (i <= low)
                    lookUpTable[i] = 0;
                else if (i > high)
                    lookUpTable[i] = 255;
                else
                {
                    intVal = Convert.ToInt32(a * i + b);
                    if (intVal > 255) intVal = 255;
                    if (intVal < 0) intVal = 0;
                    lookUpTable[i] = (byte)intVal;
                }
            }
        }

        public override double ComputeScale(double low, double high, double value)
        {
            double a = high / (high - low);
            double b = -a * low;

            return a * value + b;
        }
    }
}
