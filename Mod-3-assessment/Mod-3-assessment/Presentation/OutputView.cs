using Mod_3_assessment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Presentation
{
    class OutputView
    {

        public OutputView()
        {

            drawMenu();
        }


        public void drawMap(Map map)
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~ +----------+ ~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ <¦"+  map.Ship.ToChar() + "¦> ~~~");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");







        }

        public void drawMenu()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Goudkoorts                                |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("| betekenis van de symbolen   |   doel van het spel    |");
            Console.WriteLine("|                             |                        |");
            Console.WriteLine("|      _ : spoor              |  Beweeg de splitsingen |");
            Console.WriteLine("|   / of \\ : bocht            |  zodat de karretjes    |");
            Console.WriteLine("|      O : leeg karretje      |  op het schip gelost   |");
            Console.WriteLine("|      Ø : vol karretje       |  worden                |");
            Console.WriteLine("|      x : gesloten splitsing |                        |");
            Console.WriteLine("|      . : rangeerterrein     |                        |");
            Console.WriteLine("└──────────────────────────────────────────────────────┘");
        
            ConsoleKeyInfo input;
            Console.WriteLine();
            Console.WriteLine("> press key to start");
            input = Console.ReadKey();





        }





    }
}
