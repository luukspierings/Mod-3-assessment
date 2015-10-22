﻿using Mod_3_assessment.Domain;
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
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ <¦" + map.Ship.ToChar() + "  ¦> ~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~ +----------+ ~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~███~~~~~~~~~~");
            Console.WriteLine("                                        ");
            

            String[] maparray = new String[5];

            int rowmineA = 0;
            int rowmineB = 2;
            int rowmineC = 4;

            Road roadA = map.MineA.Origin;
            Road roadB = map.MineB.Origin;
            Road roadC = map.MineC.Origin;

            
            maparray[rowmineA] = maparray[rowmineA] + map.MineA.ToChar();
            maparray[rowmineB] = maparray[rowmineB] + map.MineB.ToChar();
            maparray[rowmineC] = maparray[rowmineC] + map.MineC.ToChar();


            for (int s = 0; s < maparray.Length; s++)
            {
                if (s != rowmineA && s != rowmineB && s != rowmineC)
                {
                    maparray[s] = maparray[s] + "   ";
                }
            }

            for (int i = 0; i < maparray.Length; i++)
            {


                roadA = map.MineA.Origin;
                roadB = map.MineB.Origin;
                roadC = map.MineC.Origin;

                rowmineA = 0;
                rowmineB = 2;
                rowmineC = 4;

                Boolean secondswitchB = false;


                
                    while (roadA != null)
                    {
                        if (rowmineA == i && roadA.GetType() == new Road().GetType())
                        {

                            maparray[i] = maparray[i] + roadA.ToChar();


                        }
                        else if (i < 2 && roadA.GetType() == new Road().GetType())
                        {
                            maparray[i] = maparray[i] + "-";
                        }

                        if (roadA.Direction == Direction.Up && roadA.GetType() == new Road().GetType())
                        {
                            rowmineA--;
                        }

                        if (roadA.Direction == Direction.Down && roadA.GetType() == new Road().GetType())
                        {
                            rowmineA++;
                            
                        }


                        if (roadA.GetType() == new SwitchSplit().GetType())
                        {
                            SwitchSplit temp = (SwitchSplit)roadA;
                            roadA = temp.RoadUp;
                            rowmineA--;
                            
                        }
                        else
                        {
                            roadA = roadA.Next;
                        }
                    }
                    
                

                for (int b = 0; b < 13 && roadB != null; b++)
                {
                        if (rowmineB == i && roadB.GetType() == new Road().GetType())
                        {
                            if (rowmineB == 2)
                            {
                                maparray[i] = maparray[i] + roadB.ToChar();
                            }
                            
                         
                        }
                        else if (i == 2 && roadB.GetType() == new Road().GetType())
                        {
                            maparray[i] = maparray[i] + "-";
                        }

                        if (roadB.Direction == Direction.Up && roadB.GetType() == new Road().GetType())
                        {
                            rowmineB--;
                        }

                        if (roadB.Direction == Direction.Down && roadB.GetType() == new Road().GetType())
                        {
                            rowmineB++;
                            Console.WriteLine(rowmineB);
                        }


                        if (roadB.GetType() == new SwitchSplit().GetType())
                        {
                            SwitchSplit temp = (SwitchSplit)roadB;
                            if (!secondswitchB)
                            {
                                roadB = temp.RoadDown;
                                secondswitchB = !secondswitchB;
                                rowmineB++;
                                
                            }
                            else
                            {
                                roadB = temp.RoadUp;
                                
                                rowmineB--;
                            }
                            
                            
                            
                        }
                        else
                        {
                            roadB = roadB.Next;
                        }
                }

                



                
                    while (roadC != null)
                    {
                        if (rowmineC == i && roadC.GetType() == new Road().GetType())
                        {

                            maparray[i] = maparray[i] + roadC.ToChar();


                        }

                        if (roadC.Direction == Direction.Up && roadC.GetType() == new Road().GetType())
                        {
                            rowmineC--;
                        }

                        if (roadC.Direction == Direction.Down && roadC.GetType() == new Road().GetType())
                        {
                            rowmineC++;
                            
                        }


                        if (roadC.GetType() == new SwitchSplit().GetType())
                        {
                            SwitchSplit temp = (SwitchSplit)roadC;
                            roadC = temp.RoadDown;
                            rowmineC++;

                        }
                        else
                        {
                            roadC = roadC.Next;
                        }
                    }

                







            }


            Console.Clear();
            Console.WriteLine(maparray[0]);
            Console.WriteLine(maparray[1]);
            Console.WriteLine(maparray[2]);
            Console.WriteLine(maparray[3]);
            Console.WriteLine(maparray[4]);

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
