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

namespace WcfService
{
    public class TestService : ITestService
    {
        UnitOfWork unit;
        IMapper mapper;

        public TestService()
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

        public void AddTest(TestDTO test)
        {
            foreach (var quest in test.Questions)
            {
                foreach (var el in quest.Answers)
                    unit.AnswerRepos.Insert(mapper.Map<Answer>(el));

                unit.QuestionRepos.Insert(mapper.Map<Question>(quest));
            }

            unit.TestRepos.Insert(mapper.Map<Test>(test));
            unit.Save();
        }
        public bool IsTextNameExist(string name) => unit.TestRepos.Get(t => t.Name == name).Count() != 0;

        public TestDTO GetTestById(int id) => mapper.Map<TestDTO>(unit.TestRepos.GetById(id));
        public TestDTO GetTestByName(string name) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Name == name).SingleOrDefault());
        public TestDTO GetTestByIdWithQuestions(int id) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Id == id, null, $"{nameof(Test.Questions)},{nameof(Question.Answers)}").SingleOrDefault());
        public TestDTO GetTestByNameWithQuestions(string name) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Name == name, null, $"{nameof(Test.Questions)},{nameof(Question.Answers)}").SingleOrDefault());

        public IEnumerable<TestDTO> GetAllTests() => mapper.Map<IEnumerable<TestDTO>>(unit.TestRepos.Get());
        public IEnumerable<TestDTO> GetAllTestsInCategory(CategoryDTO category) => mapper.Map<IEnumerable<TestDTO>>(unit.TestRepos.Get(t => t.Category.Id == category.Id));
    }
}
