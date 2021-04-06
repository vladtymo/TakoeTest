using DAL.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ResultService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ResultService.svc or ResultService.svc.cs at the Solution Explorer and start debugging.
    public class ResultService : IResultService
    {
        UnitOfWork unit;

        public ResultService()
        {
            unit = new UnitOfWork();
        }
        public void AddResult(Result result)
        {
            unit.ResultRepos.Insert(result);
            unit.Save();
        }
    }
}
