using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Map
    {

        Mine _mineA;
        Mine _mineB;
        Mine _mineC;

        Ship _ship;

        public Map()
        {

            Road originA = new Road();
            Road originB = new Road();
            Road originC = new Road();


            Road A = buildRoad(2, originA);
            Road B = buildRoad(2, originB);
            Road C = buildRoad(5, originC);


            Road temp = originC;

            for (int i = 1; i < 3; i++)
            {


                temp.ToChar();

                temp = temp.Next;

            }




            _mineA = new Mine(originA);
            _mineB = new Mine(originB);
            _mineC = new Mine(originC);

            _ship = new Ship();

        }



        public Road buildRoad(int howmuch, BaseField begin)
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






    }
}
