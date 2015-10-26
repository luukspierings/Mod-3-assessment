using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod_3_assessment.Presentation;
using Mod_3_assessment.Domain;

namespace Mod_3_assessment.Process
{
    
    class Controller
    {
        private InputView _inputview;
        private OutputView _outputview;
        private Map _map;

        public Boolean GameFinished { get; set; }


        private int timeSpan = 2000;

        public Controller()
        {
            _map = new Map();
            
            _inputview = new InputView();
            _outputview = new OutputView();
            _outputview.drawMap(_map);
            GameFinished = false;


            _map.MineA.placeCart();



            this.Start();


            Console.ReadLine();
            


        }

        public void Start()
        {

            Thread thread = new Thread(new ThreadStart(this.Update));
            thread.Start();

        }

        public void Update()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (!GameFinished)
            {

                long ts = stopwatch.ElapsedMilliseconds;


                if (stopwatch.ElapsedMilliseconds >= this.timeSpan)
                {
                    _outputview.drawMap(_map);
                    this.render();
                    

                    stopwatch.Restart();
                }

            }
        }


        public void render()
        {

            Road roadA = _map.MineA.Origin;
            Road roadB = _map.MineB.Origin;
            Road roadC = _map.MineC.Origin;

            Road roadlast = new Road();


            int currentline = 0;
            Boolean godown = true;



            while (roadB != null)
            {
                if (roadB.GetType() == new SwitchSplit().GetType())
                {
                    SwitchSplit temp = (SwitchSplit)roadB;
                    roadlast = roadB;
                    roadB = temp.RoadUp;


                }
                else
                {
                    roadlast = roadB;
                    roadB = roadB.Next;
                }

            }

            if (roadlast.Currentcart != null)
            {
                roadlast.Currentcart = null;
            }


            while (roadlast != null)
            {
                if (roadlast.Direction == Direction.Up)
                {
                    currentline++;
                }

                if (roadlast.Direction == Direction.Down)
                {
                    currentline--;

                }
                Console.Write(currentline);
                if (currentline >= 2 && roadlast.GetType() == new SwitchSplit().GetType())
                {
                    SwitchSplit temp = (SwitchSplit)roadlast;
                    temp.renderCart();



                }
                else if (currentline >= 2 && roadlast.Next != null && roadlast.Next.GetType() == new SwitchJoin().GetType())
                {
                    SwitchJoin temp = (SwitchJoin)roadlast.Next;
                    if (godown && temp.DirectionJoin == Direction.Up)
                    {
                        roadlast.renderCart();

                    }
                    else if (!godown && temp.DirectionJoin == Direction.Down)
                    {
                        roadlast.renderCart();

                    }

                }
                else if (currentline >= 2)
                {
                    roadlast.renderCart();
                }



                if (roadlast.GetType() == new SwitchJoin().GetType())
                {
                    SwitchJoin temp = (SwitchJoin)roadlast;
                    if (!godown)
                    {
                        roadlast = temp.PreviousUp;
                        godown = !godown;
                    }
                    else if (godown)
                    {
                        roadlast = temp.PreviousDown;
                        godown = !godown;
                    }




                }
                else
                {
                    roadlast = roadlast.Previous;
                }

            }


            



            while (roadA != null)
            {
                if (roadA.GetType() == new SwitchSplit().GetType())
                {
                    SwitchSplit temp = (SwitchSplit)roadA;
                    roadlast = roadA;
                    roadA = temp.RoadUp;
                    

                }
                else
                {
                    roadlast = roadA;
                    roadA = roadA.Next;
                }
                
            }

            if (roadlast.Currentcart != null)
            {
                roadlast.Currentcart = null;
            }

            while (roadlast != null)
            {
                
                if (roadlast.GetType() == new SwitchSplit().GetType())
                {
                    SwitchSplit temp = (SwitchSplit)roadlast;
                    temp.renderCart();
                    

                }
                else if (roadlast.Next != null && roadlast.Next.GetType() == new SwitchJoin().GetType())
                {
                    SwitchJoin temp = (SwitchJoin)roadlast.Next;
                    if (temp.DirectionJoin == Direction.Up)
                    {
                        roadlast.renderCart();
                    }


                }
                else
                {
                    roadlast.renderCart();
                }


                if (roadlast.GetType() == new SwitchJoin().GetType())
                {
                    SwitchJoin temp = (SwitchJoin)roadlast;
                    roadlast = temp.PreviousUp;
                    

                }
                else
                {
                    roadlast = roadlast.Previous;
                }
                
            }



            

           

            

            
            Console.WriteLine("update finished");


        }






    }
}
