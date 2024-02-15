using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ATM_App.UI
{
    public static class Utinity
    {
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"{prompt}");
            return Console.ReadLine();
        }
        public static void PressEnter()
        {
            Console.WriteLine("\nPlease Enter To Continue");
            Console.ReadLine();
        }
        public static void PrintMsg(string msg, bool succ=true) // Red Or Yello
        { 
            if(succ) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            PressEnter();
        }
        public static string GetSecInput(string input) {
           
            bool IsInput = true;
            string ast = "";
            StringBuilder inp=new StringBuilder();
            while (true)
            {
                if(IsInput) 
                    Console.WriteLine(input);
                IsInput= false;
                  ConsoleKeyInfo InputKey= Console.ReadKey(true);
                if (InputKey.Key == ConsoleKey.Enter)
                {
                    if (inp.Length == 6) break;
                    else
                    {
                        PrintMsg("\nPlz Enter 6 Digits .", false);
                        IsInput = true;
                        inp.Clear();
                        continue;
                    }

                }
                if (InputKey.Key == ConsoleKey.Backspace && inp.Length > 0)
                {
                    inp.Remove(inp.Length - 1, 1);
                }
                else if (InputKey.Key != ConsoleKey.Backspace)
                {
                    inp.Append(InputKey.KeyChar);
                    Console.Write(ast+"*");
                }
                
            }
            return inp.ToString();
        }
        public static void Print_Dot(int Time = 10)
        {
          
            for (int i = 0; i < Time; i++)
            {
                Console.Write('.');
                Thread.Sleep(200); // For Waiting
            }
            Console.Clear();
        }
       
    }
}

