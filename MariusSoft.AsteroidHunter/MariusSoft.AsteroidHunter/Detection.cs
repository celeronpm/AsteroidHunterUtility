namespace MariusSoft.AsteroidHunter
{
    /// <summary>
    /// Detection info
    /// </summary>
    public struct Detection
    {
        /// <summary>
        /// Sequential numbering of detection output of program (from lowest x pixel position in frame 1)
        /// </summary>
        public int DetNumber { get; set; }

        /// <summary>
        /// Which observation this data is relevant to (1,2,3, or 4)
        /// </summary>
        public int Frame { get; set; }

        /// <summary>
        /// .sext number of this object
        /// </summary>
        public double Sexnum { get; set; }

        /// <summary>
        /// Julian date
        /// </summary>
        public double Timetag { get; set; }

        /// <summary>
        /// Right ascension of object in decimal hours
        /// </summary>
        public double RaHours { get; set; }

        /// <summary>
        /// Declination of object in decimal degrees
        /// </summary>
        public double DecDeg { get; set; }

        /// <summary>
        /// Location in pixels
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Location in pixels
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Brightness of the target in magnitudes
        /// </summary>
        public double Mag { get; set; }

        /// <summary>
        /// Full width half max of Gaussian fit in pixels
        /// </summary>
        public double Fwhm { get; set; }

        /// <summary>
        /// Ratio of long axis to short axis
        /// </summary>
        public double Elong { get; set; }

        /// <summary>
        /// Position angle of the long axis
        /// </summary>
        public double Theta { get; set; }

        /// <summary>
        /// Error in fit to straight line
        /// </summary>
        public double Rmserr { get; set; }

        /// <summary>
        /// From .sext - peak value minus threshold over background
        /// </summary>
        public double Deltamu { get; set; }

        public Detection(string data): this()
        {
            while (data.Contains("  "))
            {
                data = data.Replace("  ", " ");
            }


            string[] pieces = data.Split(' ');

            DetNumber = int.Parse(pieces[0]);
            Frame = int.Parse(pieces[1]);
            Sexnum = int.Parse(pieces[2]);
            Timetag = double.Parse(pieces[3]);
            RaHours = double.Parse(pieces[4]);
            DecDeg = double.Parse(pieces[5]);
            X = double.Parse(pieces[6]);
            Y = double.Parse(pieces[7]);
            Mag = double.Parse(pieces[8]);
            Fwhm = double.Parse(pieces[9]);
            Elong = double.Parse(pieces[10]);
            Theta = double.Parse(pieces[11]);
            Rmserr = double.Parse(pieces[12]);
            Deltamu = double.Parse(pieces[13]);
        }
    }
}