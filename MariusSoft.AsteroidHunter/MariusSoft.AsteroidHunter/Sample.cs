using System;
using System.IO;
using System.Threading.Tasks;

namespace MariusSoft.AsteroidHunter
{
    public class Sample
    {
        private DetectionFile _detectionFile;
        private readonly ExistingKnownObjectFile _knownObjectFile;
        private readonly RejectionFile _rejectiedObjectFile;
        private readonly BitmapGenerator[] _frames = new BitmapGenerator[4];


        public BitmapGenerator[] Frames
        {
            get { return _frames; }
        }

        public ExistingKnownObjectFile KnownObjectFile
        {
            get { return _knownObjectFile; }
        }

        public RejectionFile RejectiedObjectFile
        {
            get { return _rejectiedObjectFile; }
        }

        public DetectionFile DetectionFile
        {
            get { return _detectionFile; }
        }

        public Sample(string file)
        {
            FileInfo fileI = new FileInfo(file);

            _detectionFile = new DetectionFile(fileI.FullName);
            _knownObjectFile = new ExistingKnownObjectFile(fileI.FullName.Replace(fileI.Extension, ".ephm"));
            _rejectiedObjectFile = new RejectionFile(fileI.FullName.Replace(fileI.Extension, ".rjct"));

            for(int i=0; i< 4; i++)
            {
                Frames[i] = new BitmapGenerator(fileI.Directory.FullName + "\\" + DetectionFile.ImageFiles[i]);
                GC.Collect();
                break;
            };
        }
    }
}
