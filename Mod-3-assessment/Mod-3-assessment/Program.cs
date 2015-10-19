using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment
{
    class Program
    {
        static void Main(string[] args)
        {



            
            // While no one is pressing any keys just keep on beeping
            while (!Console.KeyAvailable)
            {
                Console.Beep(3200,100);
            }



            

        }
    }
}
