using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PopNavigationJournal.Views;
using Prism.Regions;

namespace PopNavigationJournal.ViewModels
{
    public class FirstPageViewModel : ViewModelBase
    {
        public FirstPageViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        public IRegionManager RegionManager { get; }

        public ICommand NavigateSecondPageCommand => new DelegateCommand(() => RegionManager.RequestNavigate("ContentRegion", nameof(SecondPage)));
    }
}
