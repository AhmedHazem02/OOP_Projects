using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Exam
{
    internal class Exam_Details
    {
        public int Time { get; set; }
        public int Number_Of_Questions {  get; set; }

        // show  
        public  void Show_Q(ref Dictionary<int, Answer> user_will_input, ref Dictionary<int,Question>Content)
        {
            for (int i = 1; i <= Content.Count(); i++)
            {
                Console.WriteLine(Content[i].Head);
                Console.WriteLine($"Question Number {i}   Mark : {Content[i].Mark}");
                Console.WriteLine(Content[i].Body);
                for (int j = 0; j < Content[i].Have.Count(); j++) Console.WriteLine($"{j + 1}.{Content[i].Have[j]}");

                int ans = int.Parse(Console.ReadLine()); // Will User input

                while (ans > Content[i].Have.Count() || ans < 1)
                {
                    Console.WriteLine("Plz Enter Valid Answer");
                    ans = int.Parse(Console.ReadLine()); ;
                }


                Answer newAns = new Answer
                {
                    id = ans, // if of answer
                    Text = Content[i].Have[ans - 1],

                };
                user_will_input.Add(i, newAns); // i-> id of question
                Console.Clear();
            }
        }
    }
}