using My_ATM_App.App;
using My_ATM_App.Domain.Entities;
using My_ATM_App.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ATM_App.UI
{
    public  class Appsecreen
    {
        internal static void Welcome()
        {
            Console.Title = "My ATM APP";

            Console.WriteLine("\n\n--------------------------Welcome To My ATM App------------------\n\n");
            Console.WriteLine("Please Insert Your Atm Card\n");
            Utinity.PressEnter();

        }
        internal static UserAccount UserLoginForm()
        {
            UserAccount TempUser = new UserAccount();
            TempUser.Caed_Number = Vaildator.convert<long>("Your Card Number . ");
            TempUser.Card_Pin = Convert.ToInt32(Utinity.GetSecInput("Enter Your Card PIN"));
            return TempUser;
        }

        internal static void Waiting()
        {
            Console.WriteLine("\nChecking Card Number And PIN...");
            Utinity.Print_Dot(10);
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utinity.PrintMsg("Your Account Is Locked. Plz Go To The Nearest Branch " +
                "To Unlock Your Account. Thank You. ", true);
            Utinity.PressEnter();
            Environment.Exit(1);
        }

        internal static void DisplayMenu()
        {
            Console.WriteLine("--------My ATM Menu---------");
            Console.WriteLine(":                            :");
            Console.WriteLine("1. Account Balance           :");
            Console.WriteLine("2. Cash Deposit              :");
            Console.WriteLine("3. Withdrawal                :");
            Console.WriteLine("4. Transfer                  :");
            Console.WriteLine("5. Transaction               :");
            Console.WriteLine("6. Logout                    :");

        }

        internal static void LogOut()
        {
            Console.WriteLine("Thank You For using My ATM App.");
            Utinity.Print_Dot();
            Console.Clear();
        }

        internal static int SelectAmount()
        {
            Console.WriteLine();
            Console.WriteLine(":1. 500       5. 10,000 ");
            Console.WriteLine(":2. 1000      6. 15,000 ");
            Console.WriteLine(":3. 2000      7. 20,000  ");
            Console.WriteLine(":4. 5000      8. 25,000  ");
            Console.WriteLine(":0. Ohter     ");
            Console.WriteLine();
            int selectAmount = Vaildator.convert<int>("Option: ");
            switch(selectAmount)
            {
                case 1:
                    return 500;
                    break;

                case 2:
                    return 1000;
                    break;
                case 3:
                    return 2000;
                    break;
                case 4:
                    return 5000;
                    break;

                case 5:
                    return 10000;
                    break;

                case 6:
                    return 15000;
                    break;

                case 7:
                    return 20000;
                    break;
                case 8:
                    return 25000;
                    break;

                default:
                    Utinity.PrintMsg("Inalid Input . Try Again", false);
                    SelectAmount();
                    return -1;
                    break;

            }

        }
        internal InternalTransfer InternalTransfer()
        {
            var interTrnafer = new InternalTransfer();
            interTrnafer.ReciepintBankAccountNumber = Vaildator.convert<long>("Recipient Account Number");
            interTrnafer.TransferAmount = Vaildator.convert<decimal>("Plz Enter Amount Would Be Transfer");
            interTrnafer.ReciepintBankAccountName = Utinity.GetUserInput("Recipient Name");
            return interTrnafer;
        }
    }
}
