using DAL;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "QuestionAnswerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select QuestionAnswerService.svc or QuestionAnswerService.svc.cs at the Solution Explorer and start debugging.
    public class QuestionAnswerService : IQuestionAnswerService
    {
        UnitOfWork unit;

        public QuestionAnswerService()
        {
            unit = new UnitOfWork();
        }

    }
}
