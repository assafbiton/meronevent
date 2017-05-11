using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
    {
        if(!string.IsNullOrEmpty(Login2.UserName) && !string.IsNullOrEmpty(Login2.Password))
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            var isUser = (from x in dc.tbl_users
                          where x.userName.Equals(Login2.UserName) && x.password.Equals(Login2.Password) &&
                           x.status == true
                          select x.ID);


            if (isUser.Count() != 0)
            {
                e.Authenticated = true;
                // Session["siriAdmin"] = true;
                Session.Add("siriAdmin", true);
            }
            else
            {
                e.Authenticated = false;
                Session.Add("siriAdmin", false);
            }
        }
        else
        {
            e.Authenticated = false;
            Session.Add("siriAdmin", false);
        }
    }
}