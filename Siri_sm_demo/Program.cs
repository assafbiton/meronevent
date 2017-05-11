using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siri_sm_demo.ServiceReference1;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Siri_sm_demo
{
    class Program
    {

        public static string connection  = System.Configuration.ConfigurationManager.ConnectionStrings["siriDB"].ConnectionString;
        public static string RequestorRef = "AB258525";
        static void Main(string[] args)
        {

            DateTime[] dtarr = new DateTime[24];
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            List<Lines> lines = new List<Lines>();

            lines = GetAllLines();
            foreach (var item in lines)
            {


                for (int i = 0; i < dtarr.Length; i++)
                {


                    dt = dt.AddMinutes(5);

                    try
                    {

                        ServiceRequestStructure Request = new ServiceRequestStructure();
                        Request.RequestorRef = new ParticipantRefStructure();
                        Request.RequestorRef.Value = RequestorRef;
                        Request.RequestTimestamp = dt;
                        Request.MessageIdentifier = new MessageQualifierStructure();
                        Request.MessageIdentifier.Value = "11111700:12223351669188:4684";

                        StopMonitoringRequestStructure smrs = new StopMonitoringRequestStructure();
                        smrs.version = "IL2.7";
                        smrs.RequestTimestamp = DateTime.Now;
                        smrs.Language = "he";
                        smrs.LineRef = new LineRefStructure();
                        smrs.LineRef.Value = item.Line_ID;//line number
                        smrs.MessageIdentifier = new MessageQualifierStructure();
                        smrs.MessageIdentifier.Value = "55";
                        smrs.MonitoringRef = new MonitoringRefStructure();
                        smrs.MonitoringRef.Value = item.Dest_Station_ID;//"06109" jerusalm  //"36112" bat yam
                        smrs.MaximumStopVisits = "30";
                        smrs.PreviewInterval = "PT60M";
                        smrs.StartTime = DateTime.Now;
                        smrs.MinimumStopVisitsPerLine = "1";
                        Request.StopMonitoringRequest = new StopMonitoringRequestStructure[1];
                        Request.StopMonitoringRequest[0] = smrs;

                        Siri_sm_demo.ServiceReference1.SOAPPortClient SS = new SOAPPortClient();

                        ServiceDeliveryStructure Response = new ServiceDeliveryStructure();
                        Response = SS.GetStopMonitoringService(Request);

                        int bp = 0;

                        Print_sm_response.print_sm_respone(Response, connection.ToString());

                    }
                    catch (Exception ex)
                    {
                        Console.ReadKey();
                        throw new Exception("Execption adding account. " + ex.Message);

                    }
                }
            }
        }

        public static List<Lines> GetAllLines()
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_GetAllLines", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataReader reader = cmd.ExecuteReader();

            List<Lines> lstLines = new List<Lines>();

            while (reader.Read())
            {
                Lines lines = new Lines();
                lines.Line_ID = reader["Line_ID"].ToString(); 
                lines.Dest_Station_ID = reader["Dest_Station_ID"].ToString();
                lstLines.Add(lines);
            }

            conn.Close();

            return lstLines;
        }
    }
}
