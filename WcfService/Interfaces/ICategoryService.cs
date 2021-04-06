using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICategoryService" in both code and config file together.
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        void AddCategory(Category category);
        [OperationContract]
        bool IsCategoryNameExist(string name);

        [OperationContract]
        Category GetCategoryById(int id);
        [OperationContract]
        Category GetCategoryByName(string name);

        [OperationContract]
        void AddTestToCategory(Category category, Test testToAdd);

        [OperationContract]
        IEnumerable<Category> GetAllCategories();
    }
}
