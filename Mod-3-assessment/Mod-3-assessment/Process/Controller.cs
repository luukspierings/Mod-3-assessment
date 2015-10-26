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
        private Thread thread;

        public Boolean GameFinished { get; set; }


        private int timeSpan = 1000;

        public Controller()
        {
            _map = new Map();
            
            _inputview = new InputView();
            _outputview = new OutputView();
            _outputview.drawMap(_map);
            GameFinished = false;

            _map.MineA.placeCart();
            //_map.MineB.placeCart();
            //_map.MineC.placeCart();


            this.Start();
        }

        public void Start()
        {

            thread = new Thread(new ThreadStart(this.Update));
            thread.Start();

        }

        public void Update()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (!GameFinished)
            {

                long ts = stopwatch.ElapsedMilliseconds;
                
                int inputnumber = _inputview.GetInput();

                if(inputnumber != 0)
                {
                    _map.changeSwitch(inputnumber);
                    _outputview.drawMap(_map);
                    inputnumber = 0;
                }
                


                if (ts >= this.timeSpan)
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

            Boolean godown = true;

            List<Cart> carts = new List<Cart>();


            Cart tempcart;


            // C

            while (roadC != null)
            {
                if (roadC.GetType() == new SwitchSplit().GetType())
                {
                    SwitchSplit temp = (SwitchSplit)roadC;
                    roadlast = roadC;
                    roadC = temp.RoadDown;


                }
                else
                {
                    roadlast = roadC;
                    roadC = roadC.Next;
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
                    tempcart = roadlast.Currentcart;

                    if (temp.renderCart())
                    {

                        carts.Add(tempcart);
                    }


                }
                else if (roadlast.Next != null && roadlast.Next.GetType() == new SwitchJoin().GetType())
                {
                    SwitchJoin temp = (SwitchJoin)roadlast.Next;
                    if (temp.DirectionJoin == Direction.Down)
                    {
                        tempcart = roadlast.Currentcart;
                        if (roadlast.renderCart())
                        {
                            carts.Add(tempcart);
                        }
                    }


                }
                else
                {
                    tempcart = roadlast.Currentcart;
                    if (roadlast.renderCart())
                    {
                        carts.Add(tempcart);
                    }
                }


                if (roadlast.GetType() == new SwitchJoin().GetType())
                {
                    SwitchJoin temp = (SwitchJoin)roadlast;
                    roadlast = temp.PreviousDown;


                }
                else
                {
                    roadlast = roadlast.Previous;
                }

            }

            // B

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

            


            while (roadlast != null)
            {
                if ( roadlast.GetType() == new SwitchSplit().GetType())
                {
                    SwitchSplit temp = (SwitchSplit)roadlast;

                    tempcart = roadlast.Currentcart;
                    if (temp.renderCart())
                    {
                        carts.Add(tempcart);
                    }



                }
                else if (roadlast.Next != null && roadlast.Next.GetType() == new SwitchJoin().GetType())
                {
                    SwitchJoin temp = (SwitchJoin)roadlast.Next;
                    if (godown && temp.DirectionJoin == Direction.Up)
                    {
                        tempcart = roadlast.Currentcart;
                        if (roadlast.renderCart())
                        {
                            carts.Add(tempcart);
                        }

                    }
                    else if (!godown && temp.DirectionJoin == Direction.Down)
                    {
                        tempcart = roadlast.Currentcart;
                        if (roadlast.renderCart())
                        {
                            carts.Add(tempcart);
                        }

                    }

                }
                else
                {
                    tempcart = roadlast.Currentcart;
                        if (roadlast.renderCart())
                        {
                            carts.Add(tempcart);
                        }
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


            
            // A


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
                    tempcart = roadlast.Currentcart;
                    
                    if (temp.renderCart())
                    {
                        
                        carts.Add(tempcart);
                    }
                    

                }
                else if (roadlast.Next != null && roadlast.Next.GetType() == new SwitchJoin().GetType())
                {
                    SwitchJoin temp = (SwitchJoin)roadlast.Next;
                    if (temp.DirectionJoin == Direction.Up)
                    {
                        tempcart = roadlast.Currentcart;
                        if (roadlast.renderCart())
                        {
                            carts.Add(tempcart);
                        }
                    }


                }
                else
                {
                    tempcart = roadlast.Currentcart;
                    if (roadlast.renderCart())
                    {
                        carts.Add(tempcart);
                    }
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








            foreach(Cart c in carts)
            {
                c.Moved = false;
            }

                

        }






    }
}
