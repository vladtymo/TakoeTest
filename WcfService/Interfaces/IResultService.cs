using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IResultService" in both code and config file together.
    [ServiceContract]
    public interface IResultService
    {
        [OperationContract]
        void AddResult(Result result);
    }
}
