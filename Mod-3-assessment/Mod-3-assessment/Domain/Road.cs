using System;
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

        public Boolean renderCart()
        {
            
            if (Next != null && Currentcart != null && Next.Currentcart == null && !Currentcart.Moved)
            {
                Currentcart.Spot = Next;
                Next.Currentcart = Currentcart;
                Currentcart.Moved = true;
                Currentcart = null;
                

                return true;
                

            }
            else if (Currentcart != null && !Currentcart.Moved)
            {
                return true;
            }
            else
            {
                return false;

            }





        }


        public Boolean cartMoveAble()
        {
            if (Next != null && Currentcart != null && Next.Currentcart != null && !Currentcart.Moved && !Next.Currentcart.Moved)
            {
                return false;
            }



            return true;
        }



    }
}
