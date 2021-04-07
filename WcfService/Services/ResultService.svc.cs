using AutoMapper;
using DAL;
using DAL.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DTO;

namespace WcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ResultService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ResultService.svc or ResultService.svc.cs at the Solution Explorer and start debugging.
    public class ResultService : IResultService
    {
        UnitOfWork unit;
        IMapper mapper;

        public ResultService()
        {
            unit = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<Category, CategoryDTO>();
                    cfg.CreateMap<Test, TestDTO>();
                    cfg.CreateMap<Question, QuestionDTO>();
                    cfg.CreateMap<Answer, AnswerDTO>();

                    cfg.CreateMap<UserDTO, User>();
                    cfg.CreateMap<CategoryDTO, Category>();
                    cfg.CreateMap<TestDTO, Test>();
                    cfg.CreateMap<QuestionDTO, Question>();
                    cfg.CreateMap<AnswerDTO, Answer>();
                });
            mapper = new Mapper(config);
        }
        public void AddResult(ResultDTO result)
        {
            unit.ResultRepos.Insert(mapper.Map<Result>(result));
            unit.Save();
        }
    }
}
