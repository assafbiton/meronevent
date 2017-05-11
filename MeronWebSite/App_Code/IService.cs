using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MeronWS
{
    [ServiceContract]
    public interface IService
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

        #region MyRegion

        #endregion
    }
}
