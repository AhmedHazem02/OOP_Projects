using My_ATM_App.Domain.Entities;
using My_ATM_App.Domain.Entities.Interface;
using My_ATM_App.Domain.Enums;
using My_ATM_App.UI;
using static My_ATM_App.UI.Utinity;
namespace My_ATM_App.App
{
   
   
    internal class ATMAPP :UserLogin,IAccountAction, ITransaction
    {
        private List<UserAccount> AccountsList;
        private UserAccount Select_Account;
        private List<Transaction> TransactionList;
        private const decimal MinKeptAmount = 500;
        private readonly Appsecreen screen;
        public ATMAPP()
        {
            screen = new Appsecreen();
        }
        public void Inial()
        {
            AccountsList = new List<UserAccount> {

               new UserAccount
               {
                   Id = 1,
                   Full_Name = "Ahmed Hazem",
                   Account_Number=12456,
                   Caed_Number=321321,
                   Card_Pin=123456,
                   AccountBalance=5000000.00m,
                   Is_Locked=false,
                   Total_Login=0,

               },

            new UserAccount
            {
                Id = 2,
                Full_Name = "Omer Hazem",
                Account_Number = 123456,
                Caed_Number = 987654,
                Card_Pin = 123456,
                AccountBalance = 6000.00m,
                Is_Locked = false,
                Total_Login=0,

            },


            new UserAccount
            {
                Id = 3,
                Full_Name = "Mohmmed Hazem",
                Account_Number = 12456,
                Caed_Number = 123456,
                Card_Pin = 123456,
                AccountBalance = 70000.00m,
                Is_Locked = false,
                Total_Login = 0,
            },
            new UserAccount
            {
                Id = 4,
                Full_Name = "Mahmmoud Hazem",
                Account_Number = 15687,
                Caed_Number = 321321,
                Card_Pin = 123456,
                AccountBalance = 500m,
                Is_Locked = true,

            }
            };
            TransactionList = new List<Transaction>();
        }
        private static long Trans_Id;
        public static long Get_Id_Trans()
        {
            return ++Trans_Id;
        }
        public void Run()
        {
            Console.Clear();
            Appsecreen.Welcome();
            CheckCardPass();
            while (true)
            {
                Appsecreen.DisplayMenu();
                ProcessMenu();
                Console.Clear();
            }
        }

        public void CheckCardPass()
        {
            bool isCorrectLogin = false;
            while (isCorrectLogin == false)
            {

                UserAccount inputAccount = Appsecreen.UserLoginForm();
                Appsecreen.Waiting();
                bool find = false ;
                foreach ( UserAccount  account in  AccountsList)
                {
                    if (inputAccount.Caed_Number == account.Caed_Number) {
                        find = true;
                      
                        if (inputAccount.Card_Pin == account.Card_Pin)
                        {
                           
                            if (inputAccount.Is_Locked == false)
                            {
                                Select_Account = account;
                                Console.WriteLine($"Welcome Back, {account.Full_Name}.");
                                isCorrectLogin = true; 
                                account.Total_Login = 0;
                                break;
                            }
                            else
                            {
                                Appsecreen.PrintLockScreen();
                            }
                        }
                        else
                        {
                            Utinity.PrintMsg("\nInvalid Card Number Or PIN Number .", false);
                            account.Total_Login++;
                        } 
                        
                        if(account.Total_Login>3) { Appsecreen.PrintLockScreen(); }
                    }
                }
                if (find == false)
                {
                    Utinity.PrintMsg("\nInvalid Card Number Or PIN Number .", false);
                }

                
                
            }

        }
        public void ProcessMenu()
        {
            switch(Vaildator.convert<int>("An Option : ")){
                case (int)AppMenu.CheckBalance:
                    Console.WriteLine("Checking Accoutn Blace...");
                    CheckBlance();
                    break;

                case (int)AppMenu.PlaceDeposit:
                    Console.WriteLine("Place Deposit...");
                    PlaceDeposit();
                    break;

                case (int)AppMenu.MakeWithdrawal:
          
                    MakewithDrawal();
                    break;

                case (int)AppMenu.InternalTansfer:
                    Console.Clear();
                    var interTran = screen.InternalTransfer();
                    InternalTansfer(interTran);
                    break;

                case (int)AppMenu.ViewTransaction:
                    Console.Clear();
                    viewTran();
                    Utinity.PressEnter();
                    break;

                case (int)AppMenu.Logout:
                    Console.WriteLine("Loging Out...");
                    Appsecreen.LogOut();
                    PrintMsg("You Have Sucess Log Out. Plz collect Your ATM Card .", true);
                    Run();
                    break;
                    default:Utinity.PrintMsg("Invalid Option", false);
                    break;

            }
        }

        public void CheckBlance()
        {
            PrintMsg($"Your Account Blance is : {Select_Account.AccountBalance}"); 
        }

        public void PlaceDeposit()
        {
            Console.WriteLine("\nOnly Multilples Of 500 And 1000 Only Allow");
            var TrnsacDeposit = Vaildator.convert<int>("Amout EG");
            Console.WriteLine("\nChecing And Counting Bank Notes.");
            Print_Dot();
            Console.WriteLine();
            if (TrnsacDeposit <= 0)
            {
                PrintMsg("Amout Can Not Be Negative", false);
                return;
            }
            if (TrnsacDeposit % 500 != 0)
            {
                PrintMsg("Enter Deposite Amount in Multiples of 500 Or 1000", false);
                return;
            }
            if (PreviewBankNotesAccount(TrnsacDeposit) == false)
            {
                PrintMsg("You Cancelled Your Action", false);
                return;
            }
            insert_Trans(Select_Account.Id,Tran_Type.Deposite, TrnsacDeposit,"");
            //UpDate
            Select_Account.AccountBalance += TrnsacDeposit;
            // print Msg
            PrintMsg($"Your Deposit of {TrnsacDeposit}  Was Sucessfully",true);


        }
        private bool PreviewBankNotesAccount(int Amount)
        {
            int Th_1000 = Amount / 1000;
            int Fi_500 = (Amount % 1000) / 500;
            Console.WriteLine("\nSummary");
            Console.WriteLine("---------");
            Console.WriteLine($"EG 1000 X {Th_1000}={1000 * Th_1000}");
            Console.WriteLine($"EG 500 X {Fi_500}={500 * Fi_500}");
            Console.WriteLine($"Total Amount : {Amount}\n\n");
            int op = Vaildator.convert<int>("1 To Confirm");
            return op.Equals(1);

        }

        public void MakewithDrawal()
        {

            var Tran_amt = 0;
            int selectedAmount = Appsecreen.SelectAmount();
            if (selectedAmount == -1)
            {
                selectedAmount = Appsecreen.SelectAmount();
            }
            else if (selectedAmount != 0)
            {
                Tran_amt = selectedAmount;
            }
            else
            {
                Tran_amt = Vaildator.convert<int>($"Amount EG");
            }

                // input Validtion
                if (Tran_amt <= 0) Utinity.PrintMsg("Amount Must Be Grater Than Zero . Try Again ", false);
                if (Tran_amt % 500 != 0)
                {
                    PrintMsg("Enter Withdraw Amount in Multiples of 500 Or 1000", false);
                    return;
                }

                // Business Logic

                if (Tran_amt > Select_Account.AccountBalance)
                {
                    PrintMsg("Withdraw Fail \n Your Blance Is Too Low To Withdraw" +
                        $" {Tran_amt}",false);
                    return;
                }
                if(Select_Account.AccountBalance -Tran_amt<MinKeptAmount) {

                    PrintMsg("Withdraw Fail \n Your Account Needs To Have Minimum" +
                        $" {MinKeptAmount}", false);
                    return;
                }

                // Bind withdrawl detials to transactio;
                insert_Trans(Select_Account.Id,Tran_Type.Withdrawal,Tran_amt,"");

                // update Account Blance

                Select_Account.AccountBalance-=Tran_amt;
                //sucess msg
                PrintMsg($"You Have successfully Withdrawn "
                    + $"{Tran_amt}");
            

        }
        public void insert_Trans(long _userId, Tran_Type _type, decimal _amount, string Description)
        {
            var transaction = new Transaction()
            {
                Tran_Id = Trans_Id,
                UserAccountID = _userId,
                Tran_Date = DateTime.Now,
                tran_type = _type,
                Tran_Amount = _amount,
                Desecription = Description
            };

            // add To List

            TransactionList.Add(transaction);


        }
        public void InternalTansfer(InternalTransfer internalTransfer)
        {
            if (internalTransfer.TransferAmount <= 0)
            {
                Utinity.PrintMsg("Amount Must Be Grater Than Zero . Try Again ", false);
                return;
            }

            if (internalTransfer.TransferAmount > Select_Account.AccountBalance)
            {
                PrintMsg("Internal Transfer Fail \n Your Do Not Have Enough Blance In You Account " +
                    $" To Transfer {internalTransfer.TransferAmount}", false);
                return;

            }

            if (Select_Account.AccountBalance - internalTransfer.TransferAmount < MinKeptAmount)
            {

                PrintMsg("Transfer Fail \n Your Account Needs To Have Minimum" +
                    $" {MinKeptAmount}", false);
                return;
            }

            // checking Reciver is Account number is Valid

            var selectedUserAccount = (from acc in AccountsList
                                      where acc.Account_Number==internalTransfer.ReciepintBankAccountNumber
                                      select acc).FirstOrDefault();
            if (selectedUserAccount == null)
            {
                PrintMsg("Tansfer Fail . Recieber Bank Account Number Invalid", false);
                return;
            }

            // chech receiver name

            if(!(selectedUserAccount.Full_Name.Equals(internalTransfer.ReciepintBankAccountName))) 
            {
                PrintMsg("Tansfer Fail . Recieber Bank User Name Invalid", false);
                Console.WriteLine(selectedUserAccount.Full_Name);
                Console.WriteLine(internalTransfer.ReciepintBankAccountName);
                return;
            }
            // add transaction Sender
            insert_Trans(Select_Account.Id, Tran_Type.Transfer, -internalTransfer.TransferAmount, "Transfered " +
                 $"To Id= {selectedUserAccount.Id}\nName= {selectedUserAccount.Full_Name} ");

            // up date sender account
           Select_Account.AccountBalance-=internalTransfer.TransferAmount;

            //add Transaction Reciver
            insert_Trans(selectedUserAccount.Id, Tran_Type.Transfer, internalTransfer.TransferAmount, "Transfered "
                + $"Account Number = {Select_Account.Account_Number}\nUser Name = {Select_Account.Full_Name}");
            selectedUserAccount.AccountBalance += internalTransfer.TransferAmount;

            // print sucess msg
            PrintMsg("Successfully Transfered " +
                $"{internalTransfer.TransferAmount} To {internalTransfer.ReciepintBankAccountName}");
        }
        public void viewTran()
        {
            var FilterTansList = TransactionList.Where(t => t.UserAccountID == Select_Account.Id).ToList();
            if(FilterTansList.Count <= 0) PrintMsg("You No Have Transaction Yet");
            else
            {
                int op = 1;
                foreach (var filter in FilterTansList) {
                    Console.WriteLine($"\nTransaction {op++} : \n" +
                        $"User Id = {filter.UserAccountID}\n" +
                        $"Transaction Id = {filter.Tran_Id}\n" +
                        $"Date = {filter.Tran_Date} \n" +
                        $"Type = {filter.tran_type} \n" +
                        $"Amount = {filter.Tran_Amount} \n" +
                        $"Description = \n{filter.Desecription}\n");
                    Console.WriteLine("----------------------------------\n");
                }
            }
           
        }
    }
}
