using System;
using System.Data;
using System.Data.SqlClient;

namespace PointerAccess
{
    class Program
    {

        public static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["siriDB"].ConnectionString;

        static void Main(string[] args)
        {



            try
            {
                ituranWS.Service3 s3 = new ituranWS.Service3();
                ituranWS.ServiceAllPlatformData sapd = new ituranWS.ServiceAllPlatformData();

                sapd = s3.GetAllPlatformsData("gm123", "gm123", "", "", "", "");

                pointerInsertData(sapd);
            }
            catch (Exception)
            {

                throw;
            }


        }

        protected static void pointerInsertData(ituranWS.ServiceAllPlatformData sapd)
        {



            foreach (var item in sapd.VehList)
            {

                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Insert_tbl_pointer_proccess", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Plate", item.Plate.ToString());
                cmd.Parameters.AddWithValue("LastLocationTime", item.LastLocationTime);
                cmd.Parameters.AddWithValue("LastLatitude", item.LastLatitude.ToString());
                cmd.Parameters.AddWithValue("LastLongitude", item.LastLongitude.ToString());
                cmd.Parameters.AddWithValue("UAID", item.UAID.ToString());
                cmd.Parameters.AddWithValue("PlatfromId", item.PlatfromId.ToString());
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
}
