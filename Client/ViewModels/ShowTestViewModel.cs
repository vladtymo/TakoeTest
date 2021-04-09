using AutoMapper;
using Client.ClassesViewModel;
using Client.TestServiceReference;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    public class ShowTestViewModel : ViewModelBase
    {
        IMapper mapper;
        public ObservableCollection<TestInfo> Tests = new ObservableCollection<TestInfo>();
        TestServiceClient testService = new TestServiceClient();

        public ShowTestViewModel()
        {
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

            TestDTO[] allTests = testService.GetAllTests();

            for (int i = 0; i < allTests.Length; i++)
            {
                Tests.Add(new TestInfo(mapper.Map<TestViewModel>(allTests[i])));
            }
        }
    }
    public class TestInfo : ViewModelBase
    {
        TestViewModel test;

        public TestViewModel Test 
        { 
            get => test; 
            set => SetProperty(ref test, value); 
        }

        TestIntroWindow passingTest;

        private RelayCommand startTestCommand;
        public ICommand StartTestCommand => startTestCommand;
        public TestInfo(TestViewModel test)
        {
            this.test = test;
            startTestCommand = new RelayCommand(o =>
            {
                passingTest = new TestIntroWindow(test);
                passingTest.ShowDialog();
            });
        }
    }
}
