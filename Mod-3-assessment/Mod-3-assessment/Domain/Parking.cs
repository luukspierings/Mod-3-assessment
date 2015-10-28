using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Parking: Road
    {

        public String ToChar()
        {
            if (Currentcart != null)
            {
                return Currentcart.ToChar() + "";
            }

            return ".";

        }







    }
}
