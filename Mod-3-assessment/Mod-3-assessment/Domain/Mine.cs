using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Mine
    {


        private Road _origin;
        private char _minename;

        public Mine(Road origin, char minename)
        {

            _origin = origin;
            _minename = minename;
        }


        public String ToChar()
        {
            return "[" + _minename + "]";

        }

        public Road Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public void placeCart()
        {

            Origin.Currentcart = new Cart();


        }

    }
}
