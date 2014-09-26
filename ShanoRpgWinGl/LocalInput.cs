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
    /// Connects to an InputDevice and directly modifies a hero's MovementState
    /// </summary>
    public class LocalInput : InputDevice
    {
        public event Action<string> OnSpecialAction;

        readonly MovementState _state = new MovementState();

        public MovementState State { get { return _state; } }

        private MouseState oldMouseState = Mouse.GetState();

        public void UpdateKeys()
        {
            //converts a bool to an int
            Func<bool, int> b2i = (b) => (b ? 1 : 0);

            //keyboard handlers
            var kbd = Keyboard.GetState();

            _state.XDirection = b2i(kbd.IsKeyDown(Keys.D)) - b2i(kbd.IsKeyDown(Keys.A));
            _state.YDirection = b2i(kbd.IsKeyDown(Keys.S)) - b2i(kbd.IsKeyDown(Keys.W));


        }

        public void RegisterAction(string actionId)
        {
            if (OnSpecialAction != null)
                OnSpecialAction(actionId);
        }
    }
}
