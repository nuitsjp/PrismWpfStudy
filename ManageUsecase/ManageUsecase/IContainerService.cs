namespace ManageUsecase
{
    public interface IContainerService
    {
        void OpenScope();
        T Resolve<T>();
        void CloseScope();
    }
}