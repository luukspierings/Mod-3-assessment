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


        private List<Cart> carts;



        public Controller()
        {
            _map = new Map();
            carts = new List<Cart>();
            
            _inputview = new InputView();
            _outputview = new OutputView();
            _outputview.drawMap(_map, 0);
            GameFinished = false;

           


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

            Random random = new Random();
            int timebeforemine = random.Next(1, 4);
            int maxtime = 8;
            int lvl = 0;

            while (!GameFinished)
            {

                long ts = stopwatch.ElapsedMilliseconds;
                
                int inputnumber = _inputview.GetInput();

                if(inputnumber != 0)
                {
                    _map.changeSwitch(inputnumber);
                    _outputview.drawMap(_map, lvl);
                    inputnumber = 0;
                }
                


                if (ts >= this.timeSpan)
                {
                    _outputview.drawMap(_map, lvl);
                    this.render();
                    
                    

                    
                    timebeforemine--;

                    if (timebeforemine == 0)
                    {
                        switch (random.Next(0, 3))
                        {
                            case 0:
                                _map.MineA.placeCart();
                                break;
                            case 1:
                                _map.MineB.placeCart();
                                break;
                            case 2:
                                _map.MineC.placeCart();
                                break;

                        }


                        timebeforemine = random.Next(3, maxtime);
                    }
                    if(_map.Score > 9 && _map.Score < 20){
                        maxtime = 7;
                        lvl = 1;
                    }
                    else if (_map.Score > 20 && _map.Score < 30)
                    {
                        maxtime = 6;
                        lvl = 2;
                    }
                    else if (_map.Score > 30 && _map.Score < 40)
                    {
                        maxtime = 5;
                        lvl = 3;
                    }

                    stopwatch.Restart();
                }

            }


            _outputview.drawGameOver(_map);
            _outputview.drawMenu();
            _map = new Map();
            carts = new List<Cart>();
            _outputview.drawMap(_map, 0);
            GameFinished = false;
            this.Start();





        }


        public void render()
        {

            Road roadA = _map.MineA.Origin;
            Road roadB = _map.MineB.Origin;
            Road roadC = _map.MineC.Origin;

            Road roadlast = new Road();

            Boolean godown = true;

            Cart tempcart;


            foreach (Cart c in carts)
            {


                if (c.Spot.GetType() != new Parking().GetType() && !c.Spot.cartMoveAble())
                {
                    GameFinished = true;
                }

                

            }
            foreach (Cart c in carts)
            {


                c.Moved = false;


            }

            carts = new List<Cart>();




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








            




            _map.Score = _map.Score + _map.Ship.unload();


        }






    }
}
