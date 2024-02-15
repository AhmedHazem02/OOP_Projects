using My_ATM_App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ATM_App.Domain.Entities
{
    public class Transaction
    {
        public long Tran_Id { get; set; }
        public long UserAccountID { get; set; }
        public DateTime Tran_Date { get; set; }
        public Tran_Type tran_type { get; set; }
        public string Desecription { get; set; }
        public Decimal Tran_Amount {  get; set; }

    }
}
