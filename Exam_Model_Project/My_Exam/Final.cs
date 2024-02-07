using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Exam
{
    internal class Final:Question
    {
        public Dictionary<int, Question> Content = new Dictionary<int, Question>(); // id ,question
        Dictionary<int, Answer> Ans = new Dictionary<int, Answer>(); // id ,Answer of Question
        Dictionary<int, Answer> user_will_input = new Dictionary<int, Answer>(); // id ,Answer of Question user will input
        public void Take(int n)
        {
            For_MCQ for_MCQ = new For_MCQ();
            For_T_OR_F for_T_OR_F=new For_T_OR_F();
            for (int i = 1; i <= n; i++)
            {
                
                Console.WriteLine($"Would You Like This Question {i} Mcq (1) Or T || F (2) ");
                 int chose=int.Parse(Console.ReadLine());
                
                 Console.Clear();
                 if (chose == 1) // MCQ
                 {
                    for_MCQ.Set_Date(ref Content, ref Ans, i);
                   
            } 
                else if (chose == 2)
                {
                  
                    for_T_OR_F.Set_Date(ref Content, ref Ans, i);
                }
                Console.Clear();
            }

        }
        public void Show_Ques( Exam_Details details )
        {
            Console.WriteLine("-------------- Final Exam Mcq And T Or F  --------------");
            Console.WriteLine($"The Time Of Exam is : {details.Time}\nNumber Of Question : {details.Number_Of_Questions}");
            Console.WriteLine("-----------------------------------------------------");
            details.Show_Q(ref user_will_input, ref Content);
            Console.WriteLine("The Exam Is Finish");
        }

        public void Show_Ans_Grade()
        {
            int sum = 0;
            for (int i = 1; i <= Content.Count(); i++)
            {
                Console.WriteLine($"Question Number {i}   Mark : {Content[i].Mark}");
                Console.WriteLine(Content[i].Body);
                for (int j = 0; j < Content[i].Have.Count(); j++) Console.WriteLine($"{j + 1}.{Content[i].Have[j]}");
                Console.WriteLine($"Correct Answer is {Ans[i].id}.{Ans[i].Text} \n");

                if (user_will_input[i].id == Ans[i].id)
                {
                    sum += Content[i].Mark;
                }
            }
            Console.WriteLine($"Your Grade is : {sum} ");
        }


    }
}
