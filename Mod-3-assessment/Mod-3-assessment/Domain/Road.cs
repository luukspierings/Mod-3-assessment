using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Road: BaseField
    {


        private Road _next;

        public Road Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public void ToChar()
        {

            Console.WriteLine("_");


        }


        


    }
}
