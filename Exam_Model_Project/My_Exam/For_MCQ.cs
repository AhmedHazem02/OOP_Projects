using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Exam
{
    internal class For_MCQ
    {
        public void Set_Date(ref Dictionary<int, Question> Content, ref Dictionary<int, Answer> Ans, int i)
        {
            Console.WriteLine("Multi Chose");
            Console.WriteLine($"Please Enter Question {i}");
            string B = Console.ReadLine(); // Body


            Question newQuestion = new Question
            {
                Head = "Chose One Answer",
                Body = B,
            };

            for (int j = 1; j <= 4; j++)  // Take Choses
            {
                Console.WriteLine($"Enter Chose : {j}");
                string ch = Console.ReadLine();
                newQuestion.Have.Add(ch);
            }
            Console.WriteLine($"Please Enter Mark Of this Question {i}: ");
            int M = int.Parse(Console.ReadLine()); // mark
            newQuestion.Mark = M;

            Content.Add(i, newQuestion);

            Console.WriteLine("Please Enter The Right Answer For This Question");
            int An=int.Parse(Console.ReadLine());

            while (An > 4 || An < 1)
            {
                Console.WriteLine("Plz Enter Valid Answer");
                An = int.Parse(Console.ReadLine()); ;
            }


            Answer newAns = new Answer
            {
                id = An, // if of answer
                Text = Content[i].Have[An - 1],

            };
            Ans.Add(i, newAns); // i-> id of question
        }
    }
}
