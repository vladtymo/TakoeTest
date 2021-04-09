using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DTO;

namespace WcfService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
	[ServiceContract]
	public interface ITestService
	{
		[OperationContract]
		void AddTest(TestDTO test);
		[OperationContract]
		bool IsTextNameExist(string name);

		[OperationContract]
		TestDTO GetTestById(int id);
		[OperationContract]
		TestDTO GetTestByName(string name);

		[OperationContract]
		TestDTO GetTestByIdWithQuestions(int id);
		[OperationContract]
		TestDTO GetTestByNameWithQuestions(string name);

		[OperationContract]
		TestDTO[] GetAllTests();
		[OperationContract]
		IEnumerable<TestDTO> GetAllTestsInCategory(CategoryDTO category);
		[OperationContract]
		IEnumerable<QuestionDTO> GetQuestionsByCurrTest(int testId);
		[OperationContract]
		IEnumerable<AnswerDTO> GetAnswersByCurrQuest(int questId);
	}
}
