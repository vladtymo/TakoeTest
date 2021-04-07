using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DTO;

namespace WcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICategoryService" in both code and config file together.
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        void AddCategory(CategoryDTO category);
        [OperationContract]
        bool IsCategoryNameExist(string name);

        [OperationContract]
        CategoryDTO GetCategoryById(int id);
        [OperationContract]
        CategoryDTO GetCategoryByName(string name);

        [OperationContract]
        void AddTestToCategory(CategoryDTO category, TestDTO testToAdd);

        [OperationContract]
        IEnumerable<CategoryDTO> GetAllCategories();
    }
}
