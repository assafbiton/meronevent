using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebServices
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           ituranWS.Service3 s3 = new ituranWS.Service3();
           ituranWS.ServiceAllPlatformData sapd = new ituranWS.ServiceAllPlatformData();

            sapd= s3.GetAllPlatformsData("gm123", "gm123", "", "", "", "");

            foreach (var item in sapd.VehList)
            {

            }
        }
    }
}