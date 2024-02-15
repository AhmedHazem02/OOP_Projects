using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ATM_App.Domain.Entities.Interface
{
    public interface IAccountAction
    {
        void CheckBlance();
        void PlaceDeposit();
        void MakewithDrawal();
    }
}
