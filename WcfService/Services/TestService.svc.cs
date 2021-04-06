using DAL;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class TestService : ITestService
    {
        UnitOfWork unit;

        public TestService()
        {
            unit = new UnitOfWork();
        }

        public void AddTest(Test test)
        {
            foreach (var quest in test.Questions)
            {
                foreach (var el in quest.Answers)
                    unit.AnswerRepos.Insert(el);

                unit.QuestionRepos.Insert(quest);
            }

            unit.TestRepos.Insert(test);
            unit.Save();
        }
        public bool IsTextNameExist(string name) => unit.TestRepos.Get(t => t.Name == name).Count() != 0;

        public Test GetTestById(int id) => unit.TestRepos.GetById(id);
        public Test GetTestByName(string name) => unit.TestRepos.Get(t => t.Name == name).SingleOrDefault();
        public Test GetTestByIdWithQuestions(int id) => unit.TestRepos.Get(t => t.Id == id, null, $"{nameof(Test.Questions)},{nameof(Question.Answers)}").SingleOrDefault();
        public Test GetTestByNameWithQuestions(string name) => unit.TestRepos.Get(t => t.Name == name, null, $"{nameof(Test.Questions)},{nameof(Question.Answers)}").SingleOrDefault();

        public IEnumerable<Test> GetAllTests() => unit.TestRepos.Get();
        public IEnumerable<Test> GetAllTestsInCategory(Category category) => unit.TestRepos.Get(t => t.Category == category);
    }
}
