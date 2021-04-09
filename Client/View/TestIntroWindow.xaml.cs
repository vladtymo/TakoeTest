using AutoMapper;
using Client.ClassesViewModel;
using Client.TestServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for TestIntroWindow.xaml
    /// </summary>
    public partial class TestIntroWindow : Window
    {
        TestServiceClient testService;
        TestViewModel testModel;
        IMapper mapper;
        public TestIntroWindow(TestViewModel modelTest)
        {
            InitializeComponent();
            testService = new TestServiceClient();
            this.testModel = modelTest;
            this.DataContext = modelTest;

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<TestDTO, TestViewModel>();
                    cfg.CreateMap<QuestionDTO, QuestionViewModel>()
                        .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Value))
                        .ForMember(dst => dst.Question, opt => opt.MapFrom(src => src.Text));
                    cfg.CreateMap<AnswerDTO, AnswerViewModel>();

                    cfg.CreateMap<TestViewModel, TestDTO>();
                    cfg.CreateMap<QuestionViewModel, QuestionDTO>()
                        .ForMember(dst => dst.Value, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dst => dst.Text, opt => opt.MapFrom(src => src.Question));
                    cfg.CreateMap<AnswerViewModel, AnswerDTO>();
                });

            mapper = new Mapper(config);

            ////НЕ КОСТИЛЬ. ОТВЕЧАЮ!!!
            ////НЕ ЛІЗЬ, УБ'Є
            //foreach (var question in testService.GetQuestionsByCurrTest(testModel.Id))
            //{
            //    question.Answers = testService.GetAnswersByCurrQuest(testModel.Id);
            //    testModel.Questions.Append(mapper.Map<QuestionViewModel>(question));
            //}

            testModel = mapper.Map<TestViewModel>(testService.GetTestByNameWithQuestions(testModel.Name));
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            PassingTestWindow window = new PassingTestWindow(testModel);
        }
    }
}
