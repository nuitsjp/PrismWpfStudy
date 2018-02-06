using System.Windows.Input;
using ManageUsecase.Presentation.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ManageUsecase.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly INavigationService _navigationService;

        public ICommand NavigateFirstPageCommand => new DelegateCommand(() => _navigationService.RequestNavigate<FirstPageViewModel>());

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
