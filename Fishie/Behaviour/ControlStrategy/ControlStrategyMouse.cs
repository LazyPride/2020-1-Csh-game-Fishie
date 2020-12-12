using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class ControlStrategyMouse : IControlStrategy
    {
        private RenderWindow window;
        public ControlStrategyMouse(RenderWindow window)
        {
            this.window = window;
        }
        public void HandleInput(Character character)
        {
            character.Position = (Vector2f)Mouse.GetPosition(window);
        }
    }
}
