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

        public TestDTO GetTestById(int id) => mapper.Map<TestDTO>(unit.TestRepos.GetById(id));
        public TestDTO GetTestByName(string name) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Name == name).SingleOrDefault());
        public TestDTO GetTestByIdWithQuestions(int id) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Id == id, null, $"{nameof(Test.Questions)},{nameof(Question.Answers)}").SingleOrDefault());
        public TestDTO GetTestByNameWithQuestions(string name) => mapper.Map<TestDTO>(unit.TestRepos.Get(t => t.Name == name, null, $"Questions").SingleOrDefault());
        public IEnumerable<QuestionDTO> GetQuestionsByCurrTest(int testId) => mapper.Map<IEnumerable<QuestionDTO>>(unit.QuestionRepos.Get(q => q.TestId == testId));
        public IEnumerable<AnswerDTO> GetAnswersByCurrQuest(int questId) => mapper.Map<IEnumerable<AnswerDTO>>(unit.AnswerRepos.Get(a => a.QuestionId == questId));

        public TestDTO[] GetAllTests()
        {
            IEnumerable<TestDTO> tmp = mapper.Map<IEnumerable<TestDTO>>(unit.TestRepos.Get());
            return tmp.ToArray();
        }
        public IEnumerable<TestDTO> GetAllTestsInCategory(CategoryDTO category) => mapper.Map<IEnumerable<TestDTO>>(unit.TestRepos.Get(t => t.Category.Id == category.Id));


    }
}
