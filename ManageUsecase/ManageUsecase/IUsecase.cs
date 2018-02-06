using System;

namespace ManageUsecase
{
    public interface IUsecase
    {
        string Name { get; }
        event EventHandler Completed;
    }
}
