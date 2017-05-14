using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
        public string userID { get; set; }
        public string receiveTime { get; set; }
    }

    class Program
    {

        public static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["siriDB"].ConnectionString;

        static void Main(string[] args)
        {



        string dtNow =     Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-ddThh:mm:ss.msZ");
            string dtNowMinsHour = Convert.ToDateTime(DateTime.Now.AddHours(-1)).ToString("yyyy-MM-ddThh:mm:ss.msZ");
       

            //string uri = "http://gazpacho.netalizer.co.il/GazpachoApi/reports?orgId=1821&user=tahbura_lag_ba_omer&password=uDp5g38S47b23hd&returnDetails=1";
            string uri = "http://gazpacho.netalizer.co.il/GazpachoApi/reports?orgId=1821&user=tahbura_lag_ba_omer&password=uDp5g38S47b23hd&returnDetails=1&fromTime="+ dtNowMinsHour + "&tillTime="+ dtNow;



            XDocument xml = XDocument.Load(uri);
            XName url = XName.Get("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XName loc = XName.Get("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");

            List<Row> LSTrOW = new List<Row>();

            IEnumerable<XElement> authors = xml.Descendants("report");
            foreach (XElement report in xml.Root.Elements("report"))
            {
                Row row = new Row();
                if (report.Element("events").Element("event")!=null)
                {
                    row.userID = report.Element("user").Attribute("id").Value;
                    row.latitude = report.Element("events").Element("event").Attributes("latitude").Any() ?  (string)report.Element("events").Element("event").Attribute("latitude"):"";
                    row.longitude = report.Element("events").Element("event").Attributes("longitude").Any() ?  (string)report.Element("events").Element("event").Attribute("longitude"):"";
                    row.plate = (string)report.Element("fields").Element("field").Attribute("value");
                    row.receiveTime=report.Element("events").Element("event").Attributes("time").Any() ?  (string)report.Element("events").Element("event").Attribute("time") :"";
                    LSTrOW.Add(row);
                }



            }
              
          SqlConnection conn2 = new SqlConnection(connection);
                SqlCommand cmd2 = new SqlCommand("DELETEALLFROMRIVA", conn2);
            cmd2.CommandType = CommandType.StoredProcedure;
            conn2.Open();
            cmd2.ExecuteNonQuery();
            conn2.Close();

            foreach (Row element in LSTrOW)
            {
         

                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Insert_Riva_proccess", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (element.latitude !="" && element.longitude!="" && element.plate != null)
                {
                    cmd.Parameters.AddWithValue("userID", element.userID);
                    cmd.Parameters.AddWithValue("plate", element.plate);
                    cmd.Parameters.AddWithValue("inlatitude", element.latitude);
                    cmd.Parameters.AddWithValue("inlongitude", element.longitude);
                    cmd.Parameters.AddWithValue("outlatitude", element.latitude);
                    cmd.Parameters.AddWithValue("outinlongitude", element.longitude);
                    cmd.Parameters.AddWithValue("receiveTime", element.receiveTime);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Execption adding account. " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
 

            }
 
       
          //  Console.ReadKey();
        }
    }
}
    

