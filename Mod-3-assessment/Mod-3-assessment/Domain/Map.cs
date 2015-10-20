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


        public Map()
        {

            _ship = new Ship();

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

            ABjoin.Direction = Direction.Down;
            A.Next = ABjoin;
            B.Next = ABjoin;
            ABjoin.PreviousUp = A;
            ABjoin.PreviousDown = B;

            Road ABroad = new Road();
            ABjoin.Next = ABroad;

            SwitchSplit ABsplit = new SwitchSplit();

            ABsplit.Direction = Direction.Up;
            ABroad.Next = ABsplit;

            ABsplit.RoadUp = new Road();
            ABsplit.RoadUp.Direction = Direction.Up;
            A = buildRoad(4, ABsplit.RoadUp);

            ABsplit.RoadDown = new Road();
            ABsplit.RoadDown.Direction = Direction.Down;
            B = buildRoad(1, ABsplit.RoadDown);
            B.Direction = Direction.Down;

            SwitchJoin BCjoin = new SwitchJoin();
            BCjoin.Direction = Direction.Down;
            B.Next = BCjoin;
            C.Next = BCjoin;
            BCjoin.PreviousUp = B;
            BCjoin.PreviousDown = C;

            Road BCroad = new Road();
            BCjoin.Next = BCroad;

            SwitchSplit BCsplit = new SwitchSplit();
            BCsplit.Direction = Direction.Up;

            BCroad.Next = BCsplit;

            BCsplit.RoadUp = new Road();
            BCsplit.RoadUp.Direction = Direction.Up;
            B = buildRoad(1, BCsplit.RoadUp);
            B.Direction = Direction.Up;


            BCsplit.RoadDown = new Road();
            BCsplit.RoadDown.Direction = Direction.Down;
            C = buildRoad(6, BCsplit.RoadDown);



            ABjoin = new SwitchJoin();
            ABjoin.Direction = Direction.Down;
            A.Next = ABjoin;
            B.Next = ABjoin;
            ABjoin.PreviousUp = A;
            ABjoin.PreviousDown = B;

            ABroad = new Road();
            ABjoin.Next = ABroad;

            Road dock = buildRoad(6, ABroad);
            _ship.Dock = dock;

            buildRoad(9, dock);

        }



        public Road buildRoad(int howmuch, Road begin)
        {

            Road last = new Road();
            begin.Next = last;

            for (int i = 1; i < howmuch; i++)
            {
                Road temp = new Road();
                last.Next = temp;
                last = temp;
            }

            return last;



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


    }
}
