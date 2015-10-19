using Mod_3_assessment.Domain;
using Mod_3_assessment.Presentation;
using Mod_3_assessment.Process;
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

            while (!Console.KeyAvailable)
            {
                Console.Beep(3200,100);
            }

            Controller controller = new Controller();
            InputView inputview = new InputView();
            Map map = new Map();
        }
    }
}
