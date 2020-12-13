using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class ControlStrategyVoid : IControlStrategy
    {
        public void HandleInput(Character character)
        {
            // Do nothing
        }
    }
}
