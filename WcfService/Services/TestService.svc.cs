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
using System.Windows;
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
                    cfg.CreateMap<Test, TestDTO>().ForMember(d => d.Category, s => s.Ignore());
                    cfg.CreateMap<Question, QuestionDTO>();
                    cfg.CreateMap<Answer, AnswerDTO>();
                    cfg.CreateMap<Result, ResultDTO>();

                    cfg.CreateMap<UserDTO, User>();
                    cfg.CreateMap<CategoryDTO, Category>();
                    cfg.CreateMap<TestDTO, Test>();
                    cfg.CreateMap<QuestionDTO, Question>();
                    cfg.CreateMap<AnswerDTO, Answer>();
                    cfg.CreateMap<ResultDTO, Result>();
                });
            mapper = new Mapper(config);
        }

        public void AddTest(TestDTO test)
        {
            test.CategoryId = 1;
            unit.TestRepos.Insert(mapper.Map<Test>(test));
            unit.Save();

            foreach (var quest in test.Questions)
            {
                quest.TestId = unit.TestRepos.GetLast().Id;
                unit.QuestionRepos.Insert(mapper.Map<Question>(quest));
                unit.Save();
                int lastId = unit.QuestionRepos.GetLast().Id;

                foreach (var el in quest.Answers)
                {
                    el.QuestionId = lastId;
                    unit.AnswerRepos.Insert(mapper.Map<Answer>(el));
                    unit.Save();
                }
            }
        }
        public bool IsTextNameExist(string name) => unit.TestRepos.Get(t => t.Name == name).Count() != 0;

        public TestDTO GetTestById(int id)
        {
            //return new TestDTO() { Name = "123", PassageTime = new TimeSpan(50) };
            return mapper.Map<TestDTO>(unit.TestRepos.GetById(id));
        }
        public TestDTO GetTestByName(string name) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Name == name).SingleOrDefault());
        public TestDTO GetTestByIdWithQuestions(int id) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Id == id, null, $"{nameof(Test.Questions)},{nameof(Question.Answers)}").SingleOrDefault());
        public TestDTO GetTestByNameWithQuestions(string name) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Name == name, null, $"Questions").SingleOrDefault());
        public IEnumerable<QuestionDTO> GetQuestionsByCurrTest(int testId) => mapper.Map<IEnumerable<QuestionDTO>>(unit.QuestionRepos.Get(q => q.TestId == testId));
        public IEnumerable<AnswerDTO> GetAnswersByCurrQuest(int questId) => mapper.Map<IEnumerable<AnswerDTO>>(unit.AnswerRepos.Get(a => a.QuestionId == questId));

        public IEnumerable<TestDTO> GetAllTests()
        {
            //IEnumerable<Test> list = new List<Test>()
            //{
            //    new Test { Name = "123", PassageTime = new TimeSpan(50), CategoryId = 1, Id = 1 },
            //    new Test { Name = "321", PassageTime = new TimeSpan(100), CategoryId = 1, Id = 2 }
            //};
            //return mapper.Map<IEnumerable<TestDTO>>(list);
            IEnumerable<Test> tmp = unit.TestRepos.Get();
            IEnumerable<TestDTO> tmpDTO = mapper.Map<IEnumerable<TestDTO>>(tmp);

            return tmpDTO;
            //IEnumerable<TestDTO> tmp = (/*includeProperties:$"{nameof(TestDTO.Questions)}"*/));
        }
        public IEnumerable<TestDTO> GetAllTestsInCategory(CategoryDTO category) => mapper.Map<IEnumerable<TestDTO>>(unit.TestRepos.Get(t => t.Category.Id == category.Id));
    }
}
