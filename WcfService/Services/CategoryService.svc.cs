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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CategoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CategoryService.svc or CategoryService.svc.cs at the Solution Explorer and start debugging.
    public class CategoryService : ICategoryService
    {
        UnitOfWork unit;
        IMapper mapper;

        public CategoryService()
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

        public void AddCategory(CategoryDTO category)
        {
            unit.CategoryRepos.Insert(mapper.Map<Category>(category));
            unit.Save();
        }
        public bool IsCategoryNameExist(string name) => unit.CategoryRepos.Get(c => c.Name == name).Count() != 0;

        public CategoryDTO GetCategoryById(int id) => mapper.Map<CategoryDTO>(unit.CategoryRepos.GetById(id));
        public CategoryDTO GetCategoryByName(string name) => mapper.Map<CategoryDTO>(unit.CategoryRepos.Get(c => c.Name == name).SingleOrDefault());

        public void AddTestToCategory(CategoryDTO category, TestDTO testToAdd)
        {
            //category.Tests.Append(testToAdd);
            //unit.CategoryRepos.Update(mapper.Map<Category>(category));
            //unit.Save();
        }

        public IEnumerable<CategoryDTO> GetAllCategories() => mapper.Map<IEnumerable<CategoryDTO>>(unit.CategoryRepos.Get());
    }
}
