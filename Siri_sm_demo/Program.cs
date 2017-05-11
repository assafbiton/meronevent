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
                    //smrs.LineRef = new LineRefStructure();
                    //smrs.LineRef.Value = "2961";//line number
                    smrs.MessageIdentifier = new MessageQualifierStructure();
                    smrs.MessageIdentifier.Value = "55";
                    smrs.MonitoringRef = new MonitoringRefStructure();
                    smrs.MonitoringRef.Value = "06109";//"06109" jerusalm  //"36112" bat yam
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
}
