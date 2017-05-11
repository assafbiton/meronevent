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


            ServiceRequestStructure Request = new ServiceRequestStructure();
            Request.RequestorRef = new ParticipantRefStructure();
            Request.RequestorRef.Value = RequestorRef;
            Request.RequestTimestamp = DateTime.Now;
            Request.MessageIdentifier = new MessageQualifierStructure();
            Request.MessageIdentifier.Value = "11111700:12223351669188:4684";

            StopMonitoringRequestStructure smrs = new StopMonitoringRequestStructure();
            smrs.version = "IL2.7";
            smrs.RequestTimestamp = DateTime.Now;
            smrs.Language = "he";
            smrs.MessageIdentifier = new MessageQualifierStructure();
            smrs.MessageIdentifier.Value = "55";
            smrs.MonitoringRef = new MonitoringRefStructure();
            smrs.MonitoringRef.Value = "32902";
            smrs.MaximumStopVisits = "30";
            smrs.PreviewInterval = "PT60M";
            smrs.MinimumStopVisitsPerLine = "1";
            Request.StopMonitoringRequest = new StopMonitoringRequestStructure[1];
            Request.StopMonitoringRequest[0] = smrs;

            try
            {
                Siri_sm_demo.ServiceReference1.SOAPPortClient SS = new SOAPPortClient();
                // SiriServices SS = new SiriServices();
                ServiceDeliveryStructure Response = new ServiceDeliveryStructure();
                Response = SS.GetStopMonitoringService(Request);

                int bp = 0;
               // Console.WriteLine(Response.ErrorCondition.Description.Value);
                Print_sm_response.print_sm_respone(Response, connection.ToString());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
               // throw;
            }
           // Insert_Insert_siri_stations();
        }

        protected static void Insert_Insert_siri_stations(string StationID)
        {
           
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SP_Insert_siri_stations", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("StationID", StationID);



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
}
