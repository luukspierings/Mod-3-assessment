﻿using Mod_3_assessment.Domain;
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


        public void renderCart()
        {


            if (Direction == Direction.Up && RoadUp.Currentcart == null)
            {
                RoadUp.Currentcart = Currentcart;
                Currentcart = null;


                

            }
            else if(Direction == Direction.Down && RoadDown.Currentcart == null)
            {
                RoadDown.Currentcart = Currentcart;
                Currentcart = null;

                


            }
            else
            {
                
            }



        }




    }
}
