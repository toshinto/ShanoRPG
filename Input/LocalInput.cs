using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    class LocalInput : InputDevice
    {
        public int YDirection { get; private set; }

        /// <summary>
        /// Gets the direction a hero is going 
        /// </summary>
        public int XDirection { get; private set; }

        public event Func<int> OnAbilityCast;

        public event Func<InputCommand, int> OnInput;



        public void RegisterInput(InputCommand cmd, int p)
        {
            throw new NotImplementedException();
        }
    }
}
