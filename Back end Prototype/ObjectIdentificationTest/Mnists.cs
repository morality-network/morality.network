using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ObjectIdentificationTest
{
    public class Mnists
    {
        public List<Mnist> MnistList { get; set; }

        public Mnists()
        {
            MnistList = new List<Mnist>();
        }
       
        public void AddAll(double[][] features, List<string> labels)
        {
            for(int i= 0;i<features.Count();i++)
            {
                MnistList.Add(new Mnist()
                {
                    ImageFeatures = features[i],
                    Label = labels[i]
                });
            }
        }

        public static Mnists Load(string fileLocation)
        {
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            using (StreamReader intputFile = new StreamReader(fileLocation))
            {
                var json = intputFile.ReadToEnd();
                return serializer.Deserialize<Mnists>(json);
            }
        }

        public void Save(string saveFolder)
        {
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            var json = serializer.Serialize(this);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(saveFolder, $@"imgs_{DateTime.Now.Ticks}.json")))
            {
                outputFile.Write(json);
            }
        }

        public Mnist GetRandomMnist()
        {
            var rand = new Random();
            return MnistList[rand.Next(MnistList.Count)];
        }
    }
}
