using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ATM_App.Domain.Entities
{
    internal class UserAccount
    {
        public int Id { get; set; }
        public long Caed_Number {  get; set; }
        public int Card_Pin {  get; set; }
        public long Account_Number {  get; set; }
        public string Full_Name { get; set; }
        public decimal AccountBalance {  get; set; }
        public int Total_Login {  get; set; }
        public bool Is_Locked {  get; set; }

    }
}
