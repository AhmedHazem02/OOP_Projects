using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ATM_App.App
{
    public class InternalTransfer
    {
        public decimal TransferAmount {  get; set; }
        public long ReciepintBankAccountNumber {  get; set; }
        public string ReciepintBankAccountName { get; set; }
    }
}
