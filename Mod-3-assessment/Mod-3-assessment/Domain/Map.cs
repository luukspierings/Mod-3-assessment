using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Map
    {

        private Mine _mineA;
        private Mine _mineB;
        private Mine _mineC;

        private Ship _ship;

        private int _score;


        public Map()
        {

            _ship = new Ship();
            _score = 0;


            buildMap();

            
        }

        public void buildMap()
        {
            Road originA = new Road();
            Road originB = new Road();
            Road originC = new Road();

            _mineA = new Mine(originA, 'A');
            _mineB = new Mine(originB, 'B');
            _mineC = new Mine(originC, 'C');

            Road A = buildRoad(2, originA);
            A.Direction = Direction.Down;
            Road B = buildRoad(2, originB);
            B.Direction = Direction.Up;
            Road C = buildRoad(5, originC);
            C.Direction = Direction.Up;


            SwitchJoin ABjoin = new SwitchJoin();

            ABjoin.DirectionJoin = Direction.Down;
            A.Next = ABjoin;
            B.Next = ABjoin;
            ABjoin.PreviousUp = A;
            ABjoin.PreviousDown = B;

            Road ABroad = new Road();
            ABjoin.Next = ABroad;
            ABroad.Previous = ABjoin;

            SwitchSplit ABsplit = new SwitchSplit();

            ABsplit.Direction = Direction.Down;
            ABroad.Next = ABsplit;
            ABsplit.Previous = ABroad;

            ABsplit.RoadUp = new Road();
            ABsplit.RoadUp.Previous = ABsplit;
            
            A = buildRoad(4, ABsplit.RoadUp);
            A.Direction = Direction.Down;

            ABsplit.RoadDown = new Road();
            ABsplit.RoadDown.Previous = ABsplit;
            
            B = buildRoad(1, ABsplit.RoadDown);
            B.Direction = Direction.Down;

            SwitchJoin BCjoin = new SwitchJoin();
            BCjoin.DirectionJoin = Direction.Up;
            B.Next = BCjoin;
            C.Next = BCjoin;
            BCjoin.PreviousUp = B;
            BCjoin.PreviousDown = C;

            Road BCroad = new Road();
            BCjoin.Next = BCroad;
            BCroad.Previous = BCjoin;

            SwitchSplit BCsplit = new SwitchSplit();
            BCsplit.Direction = Direction.Down;

            BCroad.Next = BCsplit;
            BCsplit.Previous = BCroad;

            BCsplit.RoadUp = new Road();
            BCsplit.RoadUp.Previous = BCsplit;
            
            B = buildRoad(1, BCsplit.RoadUp);
            B.Direction = Direction.Up;


            BCsplit.RoadDown = new Road();
            BCsplit.RoadDown.Previous = BCsplit;
            
            C = buildRoad(6, BCsplit.RoadDown);

            for (int i = 0; i < 8; i++)
            {
                Parking temp = new Parking();

                C.Next = temp;
                temp.Previous = C;

                C = temp;



            }

           






            ABjoin = new SwitchJoin();
            ABjoin.DirectionJoin = Direction.Down;
            A.Next = ABjoin;
            B.Next = ABjoin;
            ABjoin.PreviousUp = A;
            ABjoin.PreviousDown = B;

            ABroad = new Road();
            ABjoin.Next = ABroad;
            ABroad.Previous = ABjoin;

            Road dock = buildRoad(6, ABroad);
            dock.Previous.Direction = Direction.Up;

            _ship.Dock = dock;

            buildRoad(9, dock);

        }



        public Road buildRoad(int howmuch, Road begin)
        {

            Road last = new Road();
            begin.Next = last;
            last.Previous = begin;

            for (int i = 1; i < howmuch; i++)
            {
                Road temp = new Road();
                last.Next = temp;
                temp.Previous = last;
                last = temp;
            }

            return last;



        }

        public void changeSwitch(int switchnumber)
        {

            if (switchnumber == 1)
            {
                changeSwitchJoin(_mineA.Origin);
            }
            else if (switchnumber == 2)
            {
                changeSwitchSplit(_mineA.Origin);              
            }
            else if (switchnumber == 3)
            {
                changeSwitchJoin(_mineC.Origin);
            }
            else if (switchnumber == 4)
            {
                changeSwitchSplit(_mineC.Origin);
            }
            else if (switchnumber == 5)
            {
                Road temp = _mineA.Origin;

                while (temp.Next.GetType() != new SwitchSplit().GetType())
                {
                    temp = temp.Next;
                }

                changeSwitchJoin(((SwitchSplit)temp.Next).RoadUp);

            }
            
        }

        public void changeSwitchSplit(Road road)
        {
            while (road.Next.GetType() != new SwitchSplit().GetType())
            {
                road = road.Next;
            }

            SwitchSplit tempSwitch = (SwitchSplit)road.Next;

            if (tempSwitch.Direction == Direction.Up && road.Next.Currentcart == null)
            {
                tempSwitch.Direction = Direction.Down;
            }
            else if (road.Next.Currentcart == null)
            {
                tempSwitch.Direction = Direction.Up;
            }
        }

        public void changeSwitchJoin(Road road)
        {
            while (road.Next.GetType() != new SwitchJoin().GetType())
            {
                road = road.Next;
            }

            SwitchJoin tempSwitch = (SwitchJoin)road.Next;

            if (tempSwitch.DirectionJoin == Direction.Up && road.Next.Currentcart == null)
            {
                tempSwitch.DirectionJoin = Direction.Down;
            }
            else if (road.Next.Currentcart == null)
            {
                tempSwitch.DirectionJoin = Direction.Up;
            }
        }



        public Ship Ship
        {
            get { return _ship; }
            set { _ship = value; }
        }
        public Mine MineA
        {
            get { return _mineA; }
            set { _mineA = value; }
        }
        public Mine MineB
        {
            get { return _mineB; }
            set { _mineB = value; }
        }
        public Mine MineC
        {
            get { return _mineC; }
            set { _mineC = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

    }
}
