using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
	[ServiceContract]
	public interface ITestService
	{
		[OperationContract]
		void AddTest(Test test);
		[OperationContract]
		bool IsTextNameExist(string name);

		[OperationContract]
		Test GetTestById(int id);
		[OperationContract]
		Test GetTestByName(string name);

		[OperationContract]
		Test GetTestByIdWithQuestions(int id);
		[OperationContract]
		Test GetTestByNameWithQuestions(string name);

		[OperationContract]
		IEnumerable<Test> GetAllTests();
		[OperationContract]
		IEnumerable<Test> GetAllTestsInCategory(Category category);
	}
}
