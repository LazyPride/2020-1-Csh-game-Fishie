using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class ControlStrategyFollowMouse : IControlStrategy
    {
        private RenderWindow window;
        public ControlStrategyFollowMouse(RenderWindow window)
        {
            this.window = window;
        }
        public void HandleInput(Entity entity)
        {
            Character character = entity.Character;
            Vector2f direction = (Vector2f)Mouse.GetPosition(window) - character.Position;
            double angle = Math.Atan2(direction.Y, direction.X) * 180.0 / Math.PI + 180.0;
            if (!Double.IsNaN(angle))
            {
                character.Rotation = (float)angle;
            }

            character.Velocity = direction * 2.0f;
        }
    }
}
