namespace MariusSoft.AsteroidHunter
{
    public struct RejectedObject
    {
        //<designation>  CYYYY MM DD.ddddd HH MM SS.ss <+/->DD MM SS.s	<mag + bandpass> <obscode>
        //In order: designation, Year, Month, decimal day, RA (in hours, min, sec), Dec (in degrees, minutes, seconds), magnitude. bandpass will be the V band (visible) and obscode will be 703 (Catalina’s main telescope)

        public string Designation { get; set; }
        public string Year { get; set; }
        public int Month { get; set; }
        public double Decimalday { get; set; }
        public int RaHours { get; set; }
        public int RaMin { get; set; }
        public double RaSec { get; set; }
        public double DecDegrees { get; set; }
        public double DecMin { get; set; }
        public double DecSec { get; set; }
        public double Magnitue { get; set; }

        public RejectedObject(string data)
            : this()
        {
            while (data.Contains("  "))
            {
                data = data.Replace("  ", " ");
            }


            string[] pieces = data.Split(' ');

            Designation = pieces[0];
            Year = pieces[1];
            Month = int.Parse(pieces[2]);
            Decimalday = double.Parse(pieces[3]);
            RaHours = int.Parse(pieces[4]);
            RaMin = int.Parse(pieces[5]);
            RaSec = double.Parse(pieces[6]);
            DecDegrees = double.Parse(pieces[7]);
            DecMin = double.Parse(pieces[8]);
            DecSec = double.Parse(pieces[9]);
            Magnitue = pieces.Length > 11 ? double.Parse(pieces[10]) : 0;
        }
    }
}
