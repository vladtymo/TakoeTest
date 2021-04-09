using DAL;
using DAL.Entities;
using DAL.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private /*static*/ TestDb context = new TestDb();
        private GenericRepository<User> userRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Test> testRepository;
        private GenericRepository<Question> questionRepository;
        private GenericRepository<Answer> answerRepository;
        private GenericRepository<Result> resultRepos;

        public IRepository<User> UserRepos
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        public IRepository<Answer> AnswerRepos
        {
            get
            {
                if (this.answerRepository == null)
                {
                    this.answerRepository = new GenericRepository<Answer>(context);
                }
                return answerRepository;
            }
        }
        public IRepository<Question> QuestionRepos
        {
            get
            {
                if (this.questionRepository == null)
                {
                    this.questionRepository = new GenericRepository<Question>(context);
                }
                return questionRepository;
            }
        }
        public IRepository<Test> TestRepos
        {
            get
            {
                if (this.testRepository == null)
                {
                    this.testRepository = new GenericRepository<Test>(context);
                }
                return testRepository;
            }
        }
        public IRepository<Category> CategoryRepos
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }
        public IRepository<Result> ResultRepos
        {
            get
            {
                if (this.resultRepos == null)
                {
                    this.resultRepos = new GenericRepository<Result>(context);
                }
                return resultRepos;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
