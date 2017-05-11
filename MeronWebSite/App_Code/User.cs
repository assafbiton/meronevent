using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public string USERNAME { get; set; }
    public string PASSWORD { get; set; }
    public bool STATUS { get; set; }

    public int ID { get; set; }
    public User(string userName, string password, bool status, int id)
    {
        USERNAME = userName;
        PASSWORD = password;
        STATUS = status;
        ID = id;
    }
}