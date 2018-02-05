using System.Windows.Input;
using PopNavigationJournal.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PopNavigationJournal.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public IRegionManager RegionManager { get; }

        public ICommand NavigateFirstPageCommand => new DelegateCommand(() => RegionManager.RequestNavigate("ContentRegion", nameof(FirstPage)));

        public MainWindowViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

    }
}
