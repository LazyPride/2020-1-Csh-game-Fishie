using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class UpdateStrategyVelocity : IUpdateStrategy
    {
        public void Update(Character character, float deltaTime)
        {
            character.Position += character.Velocity * deltaTime;
        }
    }
}
