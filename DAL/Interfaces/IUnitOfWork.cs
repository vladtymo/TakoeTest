using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepos { get; }
        IRepository<Answer> AnswerRepos { get; }
        IRepository<Category> CategoryRepos { get; }
        IRepository<Question> QuestionRepos { get; }
        IRepository<Test> TestRepos { get; }
        IRepository<Result> ResultRepos { get; }
        void Save();
    }
}
