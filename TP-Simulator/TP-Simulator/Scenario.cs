using System.IO;
using System.Xml.Serialization;

namespace TP_Simulator
{
    public sealed class Scenario
    {
        private static Scenario instance = null;

        public static Scenario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scenario();
                }
                return instance;
            }
        }
        public static void Deserialize(string filename)
        {
            XmlSerializer xd = new XmlSerializer(typeof(Scenario));
            using (StreamReader rd = new StreamReader(filename))
            {
                Scenario scenario = xd.Deserialize(rd) as Scenario;
            }
        }
    }
}
