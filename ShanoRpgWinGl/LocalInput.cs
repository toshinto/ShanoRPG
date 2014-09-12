using Engine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Input;
using Microsoft.Xna.Framework.Input;

namespace ShanoRpgWinGl
{
    /// <summary>
    /// Connects to an InputDevice and directly modifies a hero's 
    /// </summary>
    public class LocalInput : InputDevice
    {
        public event Action<int> OnSpecialAction;

        readonly MovementState _state = new MovementState();

        public MovementState State { get { return _state; } }

        public void UpdateKeys()
        {
            //converts a bool to an int
            Func<bool, int> b2i = (b) => (b ? 1 : 0);

            var kbd = Keyboard.GetState();

            //Local movement
            _state.XDirection = b2i(kbd.IsKeyDown(Keys.Right)) - b2i(kbd.IsKeyDown(Keys.Left));
            _state.YDirection = b2i(kbd.IsKeyDown(Keys.Down)) - b2i(kbd.IsKeyDown(Keys.Up));

            //TODO: add ability handlers
        }
    }
}
