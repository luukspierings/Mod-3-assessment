using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Ship
    {
        private int _cargo;
        private Road _dock;


        public Road Dock
        {
            get { return _dock; }
            set { _dock = value; }
        }

        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }


        public String ToChar()
        {
            String cargostring = "";

            for (int i = 0; i < _cargo; i++)
            {
                cargostring = cargostring + "¦";


            }
            for (int i = 0; i < 8-_cargo; i++)
            {
                cargostring = cargostring + " ";


            }

            return cargostring;


        }


        public int unload()
        {
            if (_dock.Currentcart != null)
            {
                _dock.Currentcart.Isempty = true;
                
                Cargo = Cargo + 1;
                if (Cargo == 8)
                {
                    Cargo = 0;
                    return 11;
                }
                return 1;
            }


            return 0;

        }




    }
}
