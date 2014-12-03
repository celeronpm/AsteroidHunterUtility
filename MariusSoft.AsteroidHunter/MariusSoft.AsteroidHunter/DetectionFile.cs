using System;
using System.Collections.Generic;
using System.IO;

namespace MariusSoft.AsteroidHunter
{
    /// <summary>
    /// Class used to load a detection file
    /// </summary>
    public class DetectionFile
    {
        #region Private variables

        private string formatVersion;
        private string[] imageFiles = new string[4];
        private List<Detection> detInfos = new List<Detection>();

        #endregion

        #region Properties

        public List<Detection> DetInfos
        {
            get { return detInfos; }
            set { detInfos = value; }
        }

        public string[] ImageFiles
        {
            get { return imageFiles; }
            set { imageFiles = value; }
        }

        #endregion

        public DetectionFile(string filePath)
        {
            Console.WriteLine("Loadings detections file");

            if (!File.Exists(filePath))
            {
                throw new Exception("Can not access .dets file " + filePath);
            }

            FileStream myStream = new FileStream(filePath, FileMode.Open);
            StreamReader myReader = new StreamReader(myStream);

            formatVersion = myReader.ReadLine();

            if (formatVersion != "DETSV2.0")
            {
                throw new Exception("Invalid detection file version: " + formatVersion);
            }

            //Skip 4/4 detection
            myReader.ReadLine();

            //get names of files
            for (int i = 0; i < 4; i++)
            {
                ImageFiles[i] = myReader.ReadLine().Split(' ')[0];
            }

            //Load det structs
            while (true)
            {
                string data = myReader.ReadLine();

                if (data == null)
                {
                    break;
                }

                DetInfos.Add(new Detection(data));
            }

            Console.WriteLine(string.Format("Detections file loaded, {0} detections found", detInfos.Count));
        }
    }
}