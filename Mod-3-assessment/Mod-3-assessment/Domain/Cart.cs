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

        public Boolean Isempty
        {
            get { return _isempty; }
            set { _isempty = value; }
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
