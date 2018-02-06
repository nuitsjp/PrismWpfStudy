using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUsecase.Usecases
{
    public interface IUsecase
    {
        event EventHandler Completed;
    }
}
