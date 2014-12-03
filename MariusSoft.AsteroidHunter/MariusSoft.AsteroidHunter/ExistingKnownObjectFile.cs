using System;
using System.Collections.Generic;
using System.IO;

namespace MariusSoft.AsteroidHunter
{
    /// <summary>
    /// Class used to load the existing known object file
    /// </summary>
    public class ExistingKnownObjectFile
    {
        #region Private variables
        private List<KnownObject> knownObjects = new List<KnownObject>();
        #endregion

        #region Properties
        public List<KnownObject> KnownObjects
        {
            get { return knownObjects; }
            set { knownObjects = value; }
        }
        #endregion

        public ExistingKnownObjectFile(string filePath)
        {
            Console.WriteLine("Loading known object file file");

            if (!File.Exists(filePath))
            {
                throw new Exception("Can not access .ephm file " + filePath);
            }

            FileStream myStream = new FileStream(filePath, FileMode.Open);
            StreamReader myReader = new StreamReader(myStream);

            //Load det structs
            while (true)
            {
                string data = myReader.ReadLine();

                if (data == null)
                {
                    break;
                }

                KnownObjects.Add(new KnownObject(data));
            }

            Console.WriteLine(string.Format("Known object file loaded, {0} objects found", KnownObjects.Count));
        }

    }
}