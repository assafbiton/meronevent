using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace netalizerAccess
{
    [XmlRoot(ElementName = "column")]
    public class Row
    {
        public string plate { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {

            string uri = "http://gazpacho.netalizer.co.il/GazpachoApi/reports?orgId=1821&user=tahbura_lag_ba_omer&password=uDp5g38S47b23hd&returnDetails=1";


            XDocument xml = XDocument.Load(uri);
            XName url = XName.Get("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XName loc = XName.Get("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");

            List<Row> items = (from r in xml.Root.Elements("report")
                               select new Row
                               {
                                   plate = (string)r.Element("fields").Element("field").Attribute("value"),
                                   latitude = (string)r.Element("events").Element("event").Attribute("latitude"),
                                   longitude = (string)r.Element("events").Element("event").Attribute("longitude")
                               }).ToList();

            foreach (XElement element in xml.Descendants("fields"))
            {
                Console.WriteLine(element.Element("field").Attribute("value").Value);
            }
 
       
            Console.ReadKey();
        }
    }
}
    

