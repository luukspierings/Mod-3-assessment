using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod_3_assessment.Presentation;
using Mod_3_assessment.Domain;

namespace Mod_3_assessment.Process
{
    
    class Controller
    {
        private InputView _inputview;
        private OutputView _outputview;
        private Map _map;

        public Controller()
        {
            _inputview = new InputView();
            _outputview = new OutputView();


            _map = new Map();





        }





    }
}
