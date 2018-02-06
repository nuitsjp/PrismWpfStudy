using System.Collections.Generic;
using ManageUsecase.Presentation.Views;
using System.Windows;
using Prism.Modularity;
using DryIoc;
using Prism.DryIoc;

namespace ManageUsecase.Presentation
{
    class Bootstrapper : DryIocBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        private Stack<IContainer> Containers { get; } = new Stack<IContainer>();

        protected override IContainer CreateContainer()
        {
            var container = base.CreateContainer();
            Containers.Push(container);
            return container;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.Register<INavigationService, NavigationService>(Reuse.Transient);

            Container.RegisterTypeForNavigation<FirstPage>();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        }
    }
}
