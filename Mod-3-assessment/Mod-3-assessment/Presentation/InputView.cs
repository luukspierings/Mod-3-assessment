using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mod_3_assessment.Presentation
{
    class InputView
    {
        private Thread updateThread;
        private Queue<int> messages = new Queue<int>();

        public InputView()
        {
            updateThread = new Thread(new ThreadStart(this.input));
            updateThread.Start();
        }
        public void input()
        {
            int switchnr = -1;

            
                ConsoleKeyInfo input;
                ConsoleKey key = ConsoleKey.Escape;

                while (true)
                {
                input = Console.ReadKey();
                key = input.Key;


                switch (key)
                {
                    case ConsoleKey.D1:
                        switchnr = 1;
                        break;
                    case ConsoleKey.D2:
                        switchnr = 2;
                        break;
                    case ConsoleKey.D3:
                        switchnr = 3;
                        break;
                    case ConsoleKey.D4:
                        switchnr = 4;
                        break;
                    case ConsoleKey.D5:
                        switchnr = 5;
                        break;
                    default:
                        switchnr = -1;
                        break;
                }
            
            if (switchnr != -1) this.messages.Enqueue(switchnr);
            
            }
        }

        public int GetInput()
        {
            int returnnumber = 0;

            if(messages.Count != 0)
            {
                returnnumber = messages.Peek();
                messages.Dequeue();
            }
            
            return returnnumber;
        }

    }
}
