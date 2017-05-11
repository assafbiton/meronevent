using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IcommonMethods" in both code and config file together.
[ServiceContract]
public interface IcommonMethods
{
    [OperationContract]
    [WebGet(
              ResponseFormat = WebMessageFormat.Json,
              //BodyStyle = WebMessageBodyStyle.Wrapped,
              UriTemplate = "DoWork/{DeviceType}")]
    string DoWork(string DeviceType);

    [OperationContract]
    [WebGet(
               ResponseFormat = WebMessageFormat.Json,
               //BodyStyle = WebMessageBodyStyle.Wrapped,
               UriTemplate = "getalllines")]
    List<tbl_sire_line> getalllines();
}
