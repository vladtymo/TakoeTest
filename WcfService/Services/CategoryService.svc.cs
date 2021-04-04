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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CategoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CategoryService.svc or CategoryService.svc.cs at the Solution Explorer and start debugging.
    public class CategoryService : ICategoryService
    {
        UnitOfWork unit;

        public CategoryService()
        {
            unit = new UnitOfWork();
        }

        public void AddCategory(Category category)
        {
            unit.CategoryRepos.Insert(category);
            unit.Save();
        }
        public bool IsCategoryNameExist(string name) => unit.CategoryRepos.Get(c => c.Name == name).Count() != 0;

        public Category GetCategoryById(int id) => unit.CategoryRepos.GetById(id);
        public Category GetCategoryByName(string name) => unit.CategoryRepos.Get(c => c.Name == name).SingleOrDefault();

        public void AddTestToCategory(Category category, Test testToAdd)
        {
            category.Tests.Append(testToAdd);
            unit.CategoryRepos.Update(category);
            unit.Save();
        }
    }
}
