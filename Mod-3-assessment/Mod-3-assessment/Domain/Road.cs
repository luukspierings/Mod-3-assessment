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

        public char ToChar()
        {

            if (Direction == Direction.Up)
            {
                return '/';
            }
            else if (Direction == Direction.Down)
            {
                return '\\';
            }
            else
            {
                return '_';
            }

        }


        


    }
}
