using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_3_assessment.Domain
{
    class Cart
    {

        private Boolean _isempty;
        private Boolean _moved;



        public Boolean Isempty
        {
            get { return _isempty; }
            set { _isempty = value; }
        }
        public Boolean Moved
        {
            get { return _moved; }
            set { _moved = value; }
        }


        public Cart()
        {
            _isempty = false;
        }




        public char ToChar()
        {

            if (_isempty)
            {
                return 'O';
            }
            else
            {
                return 'Ø';
            }
            

        }



    }
}
