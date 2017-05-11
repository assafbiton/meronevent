using Siri_sm_demo.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siri_sm_demo
{
    class Print_sm_response
    {

        public static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["siriDB"].ConnectionString;

        public static void print_sm_respone(ServiceDeliveryStructure Response , string text)
        {

            try
            {
                int i = 65;
                StopMonitoringDeliveryStructure smds = new StopMonitoringDeliveryStructure();
                MonitoredStopVisitStructure msvs = new MonitoredStopVisitStructure();
                using (StreamWriter LogFile = new StreamWriter("siri_sm_track.txt", true))
                {
                    //LogFile.WriteLine("Start of siri_sm_track.txt");
                    //LogFile.WriteLine("{0}", "ResponseTimestamp:         " + Response.ResponseTimestamp);
                    //LogFile.WriteLine("{0}", "ProducerRef:               " + Response.ProducerRef.Value);
                    //LogFile.WriteLine("{0}", "ResponseMessageIdentifier: " + Response.ResponseMessageIdentifier.Value);
                    //LogFile.WriteLine("{0}", "RequestMessageRef:         " + Response.RequestMessageRef.Value);
                    //LogFile.WriteLine("{0}", "Status:                    " + Response.Status);
                    if (Response.Status == false)
                    {
                        //LogFile.WriteLine(" ");
                        //LogFile.WriteLine("{0}", "There was an error");
                        //LogFile.WriteLine("{0}", "ErrorText:                 " + Response.ErrorCondition.Description.Value);
                    }
                    if (Response.Status == true)
                    {
                        for (int smds_num = 0; smds_num < Response.StopMonitoringDelivery.Length; smds_num++)
                        {
                            //LogFile.WriteLine("    Start of StopMonitoringDelivery num {0}", smds_num);
                            
                            smds = Response.StopMonitoringDelivery[smds_num];
                            //LogFile.WriteLine("{0}", "        ResponseTimestamp:         " + smds.ResponseTimestamp);
                            //LogFile.WriteLine("{0}", "        Status:                    " + smds.Status);
                            if (smds.Status == false)
                            {
                                //LogFile.WriteLine("{0}", "        Error description:         " + smds.ErrorCondition.Description.Value);
                            }
                            if (smds.Status == true)
                            {
                                for (int msvs_num = 0; msvs_num < smds.MonitoredStopVisit.Length; msvs_num++)
                                {
                                    msvs = smds.MonitoredStopVisit[msvs_num];


                                    // Console.WriteLine("{0} .", msvs_num);
                                   InsertData(msvs, LogFile);

                                    //LogFile.WriteLine("            Start of MonitoredStopVisit num {0}", msvs_num);
                                    //LogFile.WriteLine("                RecordedAtTime:           {0}", msvs.RecordedAtTime);
                                    //LogFile.WriteLine("                ItemIdentifier:           {0}", msvs.ItemIdentifier);
                                    //LogFile.WriteLine("                MonitoringRef:            {0}", msvs.MonitoringRef.Value);
                                    //LogFile.WriteLine("                LineRef:                  {0}", msvs.MonitoredVehicleJourney.LineRef.Value);
                                    //LogFile.WriteLine("                DirectionRef:             {0}", msvs.MonitoredVehicleJourney.DirectionRef.Value);
                                    //LogFile.WriteLine("                PublishedLineName:        {0}", msvs.MonitoredVehicleJourney.PublishedLineName.Value);
                                    //if (msvs.MonitoredVehicleJourney.VehicleRef == null)
                                    //{
                                    //    LogFile.WriteLine("                vehicleRef:               is null");
                                    //}
                                    //else
                                    //{
                                    //    LogFile.WriteLine("                vehicleRef:               {0}", msvs.MonitoredVehicleJourney.VehicleRef.Value);
                                    //}
                                    //LogFile.WriteLine("                OperatorRef:              {0}", msvs.MonitoredVehicleJourney.OperatorRef.Value);
                                    //LogFile.WriteLine("                DestinationRef:           {0}", msvs.MonitoredVehicleJourney.DestinationRef.Value);
                                    //if (msvs.MonitoredVehicleJourney.VehicleLocation == null)
                                    //{
                                    //    LogFile.WriteLine("                VehicleLocation:          is null");
                                    //}
                                    //else
                                    //{
                                    //    LogFile.WriteLine("                VehicleLocation:          {0}",
                                    //           msvs.MonitoredVehicleJourney.VehicleLocation.Items[0] + ","
                                    //         + msvs.MonitoredVehicleJourney.VehicleLocation.Items[1]);
                                    //}

                                    //LogFile.WriteLine("                StopPointRef:             {0}", msvs.MonitoredVehicleJourney.MonitoredCall.StopPointRef.Value);
                                    //LogFile.WriteLine("                OriginAimedDepartureTime: {0}", msvs.MonitoredVehicleJourney.OriginAimedDepartureTime);
                                    //LogFile.WriteLine("                AimedArrivalTime:         {0}", msvs.MonitoredVehicleJourney.MonitoredCall.AimedArrivalTime);
                                    //LogFile.WriteLine("                ExpectedArrivalTime:      {0}", msvs.MonitoredVehicleJourney.MonitoredCall.ExpectedArrivalTime);
                                    //LogFile.WriteLine("            End   of MonitoredStopVisit num {0}", msvs_num);
              
                                }

                            }
                           // LogFile.WriteLine("    End of StopMonitoringDelivery num {0}", smds_num);
                        }
                    }
                   // LogFile.WriteLine("End of siri_sm_track.txt");
                }
            }
            catch (Exception e) { Console.WriteLine("{0} Exception caught.", e); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msvs"></param>
        /// <param name="LogFile"></param>
        public static void InsertData(MonitoredStopVisitStructure msvs, StreamWriter LogFile)
        {
        SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Insert_tbl_SIRI_proccess", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("RecordedAtTime",DateTime.Now);
            cmd.Parameters.AddWithValue("ItemIdentifier", msvs.ItemIdentifier.ToString());
            cmd.Parameters.AddWithValue("MonitoringRef", msvs.MonitoringRef.Value.ToString());
            cmd.Parameters.AddWithValue("LineRef", msvs.MonitoredVehicleJourney.LineRef.Value.ToString());
            cmd.Parameters.AddWithValue("PublishedLineName", msvs.MonitoredVehicleJourney.PublishedLineName.Value.ToString());
            cmd.Parameters.AddWithValue("vehicleRef", msvs.MonitoredVehicleJourney.VehicleRef.Value==null?"" : msvs.MonitoredVehicleJourney.VehicleRef.Value.ToString());
            cmd.Parameters.AddWithValue("DestinationRef", msvs.MonitoredVehicleJourney.DestinationRef.Value.ToString());       
            cmd.Parameters.AddWithValue("VehicleLocation", msvs.MonitoredVehicleJourney.VehicleLocation == null ?"":msvs.MonitoredVehicleJourney.VehicleLocation.Items[0].ToString() + ","+ msvs.MonitoredVehicleJourney.VehicleLocation.Items[1].ToString());
            cmd.Parameters.AddWithValue("StopPointRef", msvs.MonitoredVehicleJourney.MonitoredCall.StopPointRef.Value==null?"": msvs.MonitoredVehicleJourney.MonitoredCall.StopPointRef.Value.ToString());
            cmd.Parameters.AddWithValue("OriginAimedDepartureTime", msvs.MonitoredVehicleJourney.OriginAimedDepartureTime.ToString());
            cmd.Parameters.AddWithValue("AimedArrivalTime", msvs.MonitoredVehicleJourney.MonitoredCall.AimedArrivalTime.ToString());
            cmd.Parameters.AddWithValue("ExpectedArrivalTime", msvs.MonitoredVehicleJourney.MonitoredCall.ExpectedArrivalTime.ToString());

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogFile.WriteLine("Exception sql : " + ex.ToString());
                throw new Exception("Execption adding account. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }


   
    }
}
