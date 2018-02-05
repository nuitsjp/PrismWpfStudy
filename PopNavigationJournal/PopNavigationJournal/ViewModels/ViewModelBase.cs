using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PopNavigationJournal.ViewModels
{
    public abstract class ViewModelBase : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive { get; private set; } = true;

        protected void Pop(IRegionManager regionManager, string regionName)
        {
            var journal = regionManager.Regions[regionName].NavigationService.Journal;
            if (journal.CanGoBack)
            {
                KeepAlive = false;
                journal.GoBack();
            }
        }
    }
}
