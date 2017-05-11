<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cars_stucks.aspx.cs" Inherits="Cars_stucks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >
        <div style="float:right;">
        <div>רכבים תקועים</div>
        <div style="border:1px solid  #808080;border-radius: 5px;padding:3px; direction:rtl;">
            <table style=" width:500px; direction:rtl; ">
                <tr style="font-weight:bold;"><td>מספר הרכב</td><td>מיקום</td><td>פרטי נהג</td><td>שם חברה</td></tr>
                <%
                       Random r = new Random();
                    
                       

                        for (int i = 0; i < 30; i++)
                        {
                            Response.Write("<tr><td>"+ r.Next(0, 1000000).ToString() +"</td><td><a href='"+r.Next(0, 100).ToString()+"."+r.Next(0, 1000000).ToString()+",34."+r.Next(0, 1000000).ToString()+"'>הצג</a></td><td>עמוס 050-1234567</td><td>אגד</td></tr>");
                    } %>
               
            </table>

        </div>
            </div>
        <div style="float:left">
                <div style="float:left;border:1px solid  #808080;border-radius: 5px;padding:3px;">
<iframe width="600" height="450" frameborder="0" style="border:0" src="https://www.google.com/maps/embed/v1/view?zoom=8&center=31.0461%2C34.8516&key=AIzaSyC8wakd8aHuXHuG_EwkgkI2lOKEOS3YTRc" allowfullscreen></iframe>
    </div>

        </div>

    </div>
</asp:Content>

