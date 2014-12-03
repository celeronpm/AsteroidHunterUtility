using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariusSoft.AsteroidHunter
{
    public class RejectionFile
    {
       
            #region Private variables
            private List<RejectedObject> rejectedObjects = new List<RejectedObject>();
            #endregion

            #region Properties
            public List<RejectedObject> RejectedObjects
            {
                get { return rejectedObjects; }
                set { rejectedObjects = value; }
            }
            #endregion

        public RejectionFile(string filePath)
        {
            Console.WriteLine("Loading Reject object file file");

            if (!File.Exists(filePath))
            {
                throw new Exception("Can not access .rjct file " + filePath);
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

                rejectedObjects.Add(new RejectedObject(data));
            }

            Console.WriteLine(string.Format("Reject object file loaded, {0} objects found", RejectedObjects.Count));

        }
    }
}
