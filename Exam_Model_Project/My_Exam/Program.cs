namespace My_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Subject sub = new Subject(1, "C#");
                sub.Create_Exam();

                Console.WriteLine("Would You Start Exam Yes (1) No (2)");

                int inp = int.Parse(Console.ReadLine());
                while (inp != 1 && inp != 2)
                {
                    Console.WriteLine("Plz Enter Valid Number { 1 Or 2 }");
                    inp = int.Parse(Console.ReadLine());
                }
                Console.Clear();
                if (inp == 1) sub.Start_Exam();
                else Console.WriteLine("Program End");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
