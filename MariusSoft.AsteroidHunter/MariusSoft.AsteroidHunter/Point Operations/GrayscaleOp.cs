namespace MariusSoft.AsteroidHunter
{
    public enum PointOps { Linear, Log, Exp, Gamma, ArcSinH };

    /// <summary>
    /// Parent class for Gray Scale Operations.
    /// </summary>
    public abstract class  GrayscaleOp
    {
        public byte[] lookUpTable = new byte[256];

        // Function to compute the lookup table. Will be overriden in each grayscale operation.
        // The third parameter is zero for linear, log and exponential operations.
        // The third parameter will be gamma value for gamma operation.
        public abstract void ComputeLookUpTable(int low, int high, double gamma);

        public abstract double ComputeScale(double low, double high, double value);
    }
}
