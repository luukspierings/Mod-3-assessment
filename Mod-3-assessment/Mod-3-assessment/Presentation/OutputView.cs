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

            String[] maparray = new String[10];

            int rowmineA = 0;
            int rowmineB = 4;
            int rowmineC = 6;

            Road roadA = map.MineA.Origin;
            Road roadB = map.MineB.Origin;
            Road roadC = map.MineC.Origin;

            SwitchJoin ABjoin;
            SwitchSplit ABsplit;
            SwitchJoin BCjoin;
            SwitchSplit BCsplit;
            

            for (int i = 0; i < 30; i++)
            {


                maparray[rowmineA] = maparray[rowmineA] + roadA.ToChar();
                maparray[rowmineB] = maparray[rowmineB] + roadB.ToChar();
                maparray[rowmineC] = maparray[rowmineC] + roadC.ToChar();










                roadA = roadA.Next;
                roadB = roadB.Next;
                roadC = roadC.Next;

            }
















                Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~ +----------+ ~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ <¦"+  map.Ship.ToChar() + "¦> ~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~ +----------+ ~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~███~~~~~~~~~~");
            Console.WriteLine("                                        ");
            Console.WriteLine(map.MineA.ToChar() + "");
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
