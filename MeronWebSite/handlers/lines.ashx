<%@ WebHandler Language="C#" Class="lines" %>

using System;
using System.Web;
using System.Linq;

public class lines : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string method = context.Request["method"];
        switch (method)
        {
                case "getlines":

                    break;
            default:
                break;
        }
        System.Web.Script.Serialization.JavaScriptSerializer JsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        context.Response.ContentType = "application/json";
        DataClassesDataContext dc = new DataClassesDataContext();
        tbl_sire_line tbline = new tbl_sire_line();
        var lines = dc.tbl_sire_lines.Select(x =>  new { x.ID, x.LineID });
        context.Response.Write(JsonSerializer.Serialize(lines));
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}