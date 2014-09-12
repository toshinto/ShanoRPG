using Engine.Objects;
using Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class Player
    {
        public readonly Hero Hero;

        public readonly InputDevice InputDevice;

        public Player(Hero hero, InputDevice inputDevice)
        {
            this.Hero = hero;
            this.InputDevice = inputDevice;
            this.Hero.MovementState = InputDevice.State;
        }
    }
}
