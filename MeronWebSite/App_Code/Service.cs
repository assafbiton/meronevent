using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;


namespace MeronWS
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    public class Service : IService
    {
        public string DoWork(string DeviceType)
        {
            return DeviceType;
        }

        public List<tbl_sire_line> getalllines()
        {
            DataClassesDataContext dc = new DataClassesDataContext();


            List<tbl_sire_line> lst = new List<tbl_sire_line>();

            lst=  dc.tbl_sire_lines.Select(x => x).ToList();
            return lst;

        }
    }
}
