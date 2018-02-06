using System.Reflection;
using Prism.Regions;

namespace ManageUsecase
{
    public class NavigationService : INavigationService
    {
        private static readonly string Suffix = "ViewModel";
        private static readonly int SuffixLength = Suffix.Length;

        private readonly IRegionManager _regionManager;

        public NavigationService(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RequestNavigate<T>(NavigationParameters navigationParameters = null) where T : class
        {
            var source = typeof(T).Name.Substring(0, typeof(T).Name.Length - SuffixLength);
            var usecaseAttribute = typeof(T).GetCustomAttribute<UsecaseAttribute>();
            _regionManager.RequestNavigate("ContentRegion", source);
        }
    }
}