using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class SwitchJoin: Road
    {

        
        Road _previousup;
        Road _previousdown;

        Direction _directionJoin;


        public Road PreviousUp
        {
            get { return _previousup; }
            set { _previousup = value; }
        }

        public Road PreviousDown
        {
            get { return _previousdown; }
            set { _previousdown = value; }
        }

        public Direction DirectionJoin
        {
            get { return _directionJoin; }
            set { _directionJoin = value; }
        }

        public String ToChar()
        {
            if (Currentcart != null)
            {
                return Currentcart.ToChar() + "";
            }

            if (DirectionJoin == Direction.Down)
            {
                return "╔";
            }
            else if (DirectionJoin == Direction.Up)
            {
                return "╚";
            }
            else
            {
                return "=";
            }


        }
    }
}
