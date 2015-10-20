using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Ship
    {
        private int cargo;
        private Road _dock;


        public Road Dock
        {
            get { return _dock; }
            set { _dock = value; }
        }


        public String ToChar()
        {
            String cargostring = "";

            for (int i = 0; i < cargo; i++)
            {
                cargostring = cargostring + "¦";


            }
            for (int i = 0; i < 8-cargo; i++)
            {
                cargostring = cargostring + " ";


            }

            return cargostring;


        }



    }
}
