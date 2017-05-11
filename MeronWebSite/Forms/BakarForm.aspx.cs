using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_BakarForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region auth
        if (Session["siriAdmin"] != null)
        {
            bool var1 = (bool)Session["siriAdmin"];
            if (var1 != true)
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        #endregion
    }

}