using Prism.Regions;

namespace ManageUsecase
{
    public interface INavigationService
    {
        void RequestNavigate<T>(NavigationParameters navigationParameters = null) where T : class;
    }
}