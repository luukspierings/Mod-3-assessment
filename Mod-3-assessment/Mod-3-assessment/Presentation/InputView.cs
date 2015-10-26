using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Presentation
{
    class InputView
    {

        public int input()
        {
            int switchnr = -1;

            ConsoleKeyInfo input;
            ConsoleKey key = ConsoleKey.Escape;

            input = Console.ReadKey();
            key = input.Key;


            switch (key)
            {
                case ConsoleKey.D1:
                    switchnr = 1;
                    break;
                case ConsoleKey.D2:
                    switchnr = 2;
                    break;
                case ConsoleKey.D3:
                    switchnr = 3;
                    break;
                case ConsoleKey.D4:
                    switchnr = 4;
                    break;
                case ConsoleKey.D5:
                    switchnr = 5;
                    break;
                default:
                    switchnr = -1;
                    break;



            }




            return switchnr;
        }


    }
}
