using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class ControlStrategyFollowEntityShifted : IControlStrategy
    {
        public ControlStrategyFollowEntityShifted(Entity entityToFollow)
        {
            this.entityToFollow = entityToFollow;
        }
        public void HandleInput(Entity entity)
        {
            Character character = entity.Character;
            Vector2f direction = entityToFollow.Character.Position - character.Position + new Vector2f(135.0f, -57.0f);
            double angle = Math.Atan2(direction.Y, direction.X) * 180.0 / Math.PI + 180.0;
            if (!Double.IsNaN(angle))
            {
                character.Rotation = (float)angle;
            }

            character.Velocity = direction * 2.0f;
        }

        private Entity entityToFollow;
    }
}
