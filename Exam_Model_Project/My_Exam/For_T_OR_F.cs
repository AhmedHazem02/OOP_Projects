using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Exam
{
    internal class For_T_OR_F
    {
        public void Set_Date(ref Dictionary<int, Question> Content, ref Dictionary<int, Answer> Ans,int i)
        {
            
            Console.WriteLine($"Please Enter  T||F Question {i} : ");
            string B = Console.ReadLine();
            Console.WriteLine("Please Enter Mark Of this Question: ");
            int M = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter The Right Answer For This Question True (1) False (2)");
            int An = int.Parse(Console.ReadLine());

            while (An > 2 || An < 1)
            {
                Console.WriteLine("Plz Enter Valid Answer True (1) False (2)");
                An = int.Parse(Console.ReadLine()); ;
            }


            Question newQuestion = new Question
            {
                Head = "T||F Question : ",
                Body = B,
                Mark = M,
            };
            newQuestion.Have.Add("True");
            newQuestion.Have.Add("False");
            Content.Add(i, newQuestion);

            Answer newAns = new Answer
            {
                id = An, // id of answer
                Text = An == 1 ? "True" : "False",

            };
            Ans.Add(i, newAns); // i-> id of question

            Console.Clear();

        }
    }
}
