using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace My_Exam
{
    internal class Partial:Question
    {
        Dictionary<int , Question>Content=new Dictionary<int, Question>(); // id ,question
        Dictionary<int, Answer> Ans = new Dictionary<int, Answer>(); // id ,Answer of Question
        Dictionary<int, Answer> user_will_input = new Dictionary<int, Answer>(); // id ,Answer of Question user will input

        public void Take(int n)
        { 
            for(int i=1;i<=n;i++)
            {
                For_T_OR_F for_T_OR_F = new For_T_OR_F();
                for_T_OR_F.Set_Date(ref Content, ref Ans, i);
            }

        }

        public void Show_Ques(Exam_Details details)
        {
            
            Console.WriteLine("-------------- Partial Exam  T Or F Only --------------");
            Console.WriteLine($"The Time Of Exam is : {details.Time}\nNumber Of Question : {details.Number_Of_Questions}");
            Console.WriteLine("-----------------------------------------------------");
            details.Show_Q(ref user_will_input, ref Content);
            Console.WriteLine("The Exam Is Finish");
        }

        public void Show_Answer()
        {
            Console.WriteLine("The Correct Answer");
            foreach (var i in Ans) { Console.WriteLine($"Answer Question {i.Key}: is {i.Value.Text}"); }
        }
    }
}

