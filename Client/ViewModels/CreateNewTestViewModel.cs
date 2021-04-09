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
using System.Windows;
using System.Windows.Input;

namespace Client
{
    public class CreateNewTestViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionViewModel> questions = new ObservableCollection<QuestionViewModel>();
        public ObservableCollection<AnswerViewModel> answers = new ObservableCollection<AnswerViewModel>();
        public ObservableCollection<int> prices = new ObservableCollection<int>();

        TestServiceClient testService;
        TestViewModel testViewModel;
        IMapper mapper;

        private RelayCommand removeCommand;
        public ICommand RemoveCommand => removeCommand;
        private DelegateCommand addPartCommand;
        public ICommand AddPartCommand => addPartCommand;
        private DelegateCommand addAnswerCommand;
        public ICommand AddAnswer => addAnswerCommand;
        private DelegateCommand saveCommand;
        public ICommand SaveCommand => saveCommand;
        private DelegateCommand cancelCommand;

        public ICommand CancelCommand => cancelCommand;

        public CreateNewTestViewModel()
        {
            testService = new TestServiceClient();
            testViewModel = new TestViewModel();

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

            for (int i = 0; i < 10; i++)
            {
                prices.Add(i + 1);
            }
            removeCommand = new RelayCommand(obj =>
            {
                int index = (int)obj;
                if (index != -1)
                {

                    answers.RemoveAt(index);
                    selectedQuestion.Answers.Clear();
                    for (int i = 0; i < answers.Count; i++)
                    {
                        answers[i].Index = i;
                        selectedQuestion.Answers.Add(answers[i]);
                    }
                }
            });
            addPartCommand = new DelegateCommand(AddQuestion);
            addAnswerCommand = new DelegateCommand(addAnswer);
            saveCommand = new DelegateCommand(save);
            cancelCommand = new DelegateCommand(cancel);
        }

        private bool visibility = false;
        public bool Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                OnPropertyChanged();
            }
        }
        private QuestionViewModel selectedQuestion;

        public QuestionViewModel SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                selectedQuestion = value;
                OnPropertyChanged();
                if (selectedQuestion != null)
                {
                    SelectedQuestionText = selectedQuestion.Question;
                    SelectedQuestionPrice = selectedQuestion.Price;

                    answers.Clear();
                    foreach (var item in selectedQuestion.Answers)
                    {
                        answers.Add(item);
                    }
                }
            }
        }

        private string selectedQuestionText;
        public string SelectedQuestionText
        {
            get { return selectedQuestionText; }
            set
            {
                selectedQuestionText = value;
                OnPropertyChanged();
                SelectedQuestion.Question = SelectedQuestionText;
            }
        }

        private string testName;
        public string TestName
        {
            get => testName;
            set
            {
                testName = value;
                OnPropertyChanged();
                testViewModel.Name = testName;
            }
        }

        private int selectedQuestionPrice;
        public int SelectedQuestionPrice
        {
            get { return selectedQuestionPrice; }
            set
            {
                selectedQuestionPrice = value;
                OnPropertyChanged();
                SelectedQuestion.Price = selectedQuestionPrice;
            }
        }

        public void AddQuestion()
        {
            questions.Add(new QuestionViewModel());
            Visibility = true;
        }
        public void addAnswer()
        {
            answers.Add(new AnswerViewModel() { Index = answers.Count });
            selectedQuestion.Answers.Add(answers[answers.Count - 1]);
        }
        private void CloseWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }
        public void save()
        {
            testViewModel.Questions = questions;
            TestDTO dto = mapper.Map<TestDTO>(testViewModel);
            testService.AddTest(dto);
            CloseWindow();
        }
        public void cancel()
        {
            CloseWindow();
        }
    }
}
