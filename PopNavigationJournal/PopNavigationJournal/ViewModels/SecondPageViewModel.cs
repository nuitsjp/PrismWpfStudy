using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;

namespace PopNavigationJournal.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        public IRegionManager RegionManager { get; }

        public ICommand PopCommand => new DelegateCommand(() => Pop(RegionManager, "ContentRegion"));

        public SecondPageViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }
    }
}
