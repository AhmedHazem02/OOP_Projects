using My_ATM_App.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_ATM_App.App
{
    class Entry
    {
        static void Main(string[] args)
        {
            ATMAPP atmapp= new ATMAPP();
            atmapp.Inial();
            atmapp.Run(); 
        }
    }
}
 