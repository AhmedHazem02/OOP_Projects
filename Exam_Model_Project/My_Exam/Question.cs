using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Exam
{
    internal class Question
    {
        public string Head { set; get; }
        public string Body { set; get; }
        public int Mark { set; get; }
        public Answer answer { set; get; }
        public List<string>Have{ set; get; }=new List<string>();

    }
}
