﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Road
    {
        protected Direction _direction;
        protected Cart _currentcart;
        protected Road _next;
        protected Road _previous;

        public Road(){

            _direction = Direction.Right;
        
        }


        public Direction Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Cart Currentcart
        {
            get { return _currentcart; }
            set { _currentcart = value; }
        }


        public Road Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public Road Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }

        public String ToChar()
        {


            if (Currentcart != null)
            {
                return Currentcart.ToChar() + "";
            }
            else if (Previous == null)
            {
                return "═";
            }
            else if (Previous.GetType() == new SwitchSplit().GetType() && this == ((SwitchSplit)Previous).RoadDown)
            {
                return "╚";
            }
            else if (Previous.GetType() == new SwitchSplit().GetType() && this == ((SwitchSplit)Previous).RoadUp)
            {
                return "╔";
            }

            if (Direction == Direction.Up && Previous.Direction == Direction.Right)
            {
                return "╝";
            }
            else if (Direction == Direction.Down && Previous.Direction == Direction.Right)
            {
                return "╗";
            }
            else if(Direction == Direction.Right && Previous.Direction == Direction.Down){
                return "╚";
            }
            else if(Direction == Direction.Right && Previous.Direction == Direction.Up)
            {
                return "╔";
            }
            else
            {
                return "═";
            }

        }

        public void renderCart()
        {
            
            if (Next != null && Next.Currentcart == null)
            {
                Next.Currentcart = Currentcart;
                Currentcart = null;


                

            }
            else
            {
                
            }





        }
        


    }
}
