namespace MariusSoft.AsteroidHunter
{
    /// <summary>
    /// Known object
    /// </summary>
    public struct KnownObject
    {
        /// <summary>
        /// Julian date
        /// </summary>
        public double TimeTag { get; set; }

        /// <summary>
        /// Right ascension of object in decimal degrees
        /// </summary>
        public double RaDeg { get; set; }

        /// <summary>
        /// Right ascension of object in decimal hours
        /// </summary>
        public double RaHours { get; set; }

        /// <summary>
        /// Decination in decimal degrees
        /// </summary>
        public double DecDeg { get; set; }

        /// <summary>
        /// Brightness of the target in magnitudes
        /// </summary>
        public double Mag { get; set; }


        public KnownObject(string data)
            : this()
        {
            while (data.Contains("  "))
            {
                data = data.Replace("  ", " ");
            }

            string[] pieces = data.Split(' ');

            TimeTag = double.Parse(pieces[0]);
            RaDeg = double.Parse(pieces[1]);
            DecDeg = double.Parse(pieces[2]);
            Mag = double.Parse(pieces[3]);

            RaHours = RaDeg / 15;
        }
    }
}