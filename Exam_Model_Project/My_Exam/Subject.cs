using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Exam
{
    internal class Subject
    {
        public int sub_id {  get; set; }
        public string sub_name { get; set; }
        public Subject(int id, string name)
        {
            sub_id = id;
            sub_name = name;
        }

        Exam_Details details=new Exam_Details();
        Partial partial=new Partial();
        Final final = new Final();
        int check;
        public void Create_Exam()
        {
            #region Main Data
            Console.WriteLine("Please Enter The Type Of Exam You Want To Start ( 1 For Practical ) ( 2 For Final) ");
            check= int.Parse(Console.ReadLine());
            while(check!=1&&check!=2) {
                Console.WriteLine("Plz Enter Valid Number { 1 Or 2 }"); 
                check = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter The Time Of Exam");
            details.Time=int.Parse(Console.ReadLine());
         

            Console.WriteLine("Enter The The Number Of Question in Exam");
            details.Number_Of_Questions = int.Parse(Console.ReadLine());
            #endregion
            Console.Clear();
                       
            if (check == 1)// partial
            {   
                partial.Take(details.Number_Of_Questions);
                   Console.Clear() ;
            }
            else if(check == 2)
            {
                //Final Exam
                final.Take(details.Number_Of_Questions);
                Console.Clear();
            }
        }

        public void Start_Exam()
        {
            if (check == 1)
            {
                partial.Show_Ques(details);
                Console.Clear();
                partial.Show_Answer();
            }
            else if(check==2)
            {
                final.Show_Ques(details);
                Console.Clear();
                final.Show_Ans_Grade();
            }
        }

    }
}
