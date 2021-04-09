using DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EntityFramework
{
    public class TestDb : DbContext
    {
        public TestDb()
            : base("name=TestDb")
        {
            Database.SetInitializer(new Initializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Result> Results { get; set; }
    }
}