using System;

namespace MariusSoft.AsteroidHunter
{
    public class GammaOp : GrayscaleOp
    {
        public override void ComputeLookUpTable(int low, int high, double gamma)
        {
            double a, b;
            a = Math.Pow(low, gamma);
            b = Math.Pow(high, gamma);

            double scale = 255.0 / (b - a);
            int intVal;

            for (int i = 0; i < 256; ++i)
            {
                if (i <= low)
                    lookUpTable[i] = 0;
                else if (i > high)
                    lookUpTable[i] = 255;
                else
                {
                    intVal = Convert.ToInt32(Math.Round(scale * (Math.Pow(i, gamma) - a)));
                    if (intVal > 255) intVal = 255;
                    if (intVal < 0) intVal = 0;
                    lookUpTable[i] = (byte)intVal;
                }
            }
        }

        public override double ComputeScale(double low, double high, double value)
        {

            return 0;
        }
    }
}
