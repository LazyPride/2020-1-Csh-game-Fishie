using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class UpdateStrategyDynamic : IUpdateStrategy
    {
        public void Update(Entity entity, float deltaTime)
        {
			// Add Drag to emulate rolling friction
			entity.Character.Acceleration = -entity.Character.Velocity * 0.8f;

			entity.Character.Velocity += entity.Character.Acceleration * deltaTime;
			entity.Character.Position += entity.Character.Velocity * deltaTime;

			float velLen = entity.Character.Velocity.X * entity.Character.Velocity.X + entity.Character.Velocity.Y * entity.Character.Velocity.Y;
			// Clamp velocity near zero
			if (Math.Abs((double)(velLen)) < 0.01)
			{
				entity.Character.Velocity *= 0.0f;
			}
		}
    }
}
