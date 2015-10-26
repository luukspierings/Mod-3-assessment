using Mod_3_assessment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment
{
    class SwitchSplit: Road
    {

        private Road _roadup;
        private Road _roaddown;

        public Road RoadUp
        {
            get { return _roadup; }
            set { _roadup = value; }
        }

        public Road RoadDown
        {
            get { return _roaddown; }
            set { _roaddown = value; }
        }


        public Boolean renderCart()
        {


            if (Currentcart != null && Direction == Direction.Up && RoadUp.Currentcart == null && !Currentcart.Moved)
            {
                Currentcart.Moved = true;
                RoadUp.Currentcart = Currentcart;
                
                Currentcart = null;

                return true;
                

            }
            else if (Currentcart != null && Direction == Direction.Down && RoadDown.Currentcart == null && !Currentcart.Moved)
            {
                Currentcart.Moved = true;
                RoadDown.Currentcart = Currentcart;
                
                Currentcart = null;


                return true;

            }
            else
            {
                return false;
            }



        }




    }
}
