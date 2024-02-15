using My_ATM_App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ATM_App.Domain.Entities.Interface
{
    public interface ITransaction
    {
        void insert_Trans(long _userId,Tran_Type _type,decimal _amount,string Description);
        void viewTran();
         
    }
}
