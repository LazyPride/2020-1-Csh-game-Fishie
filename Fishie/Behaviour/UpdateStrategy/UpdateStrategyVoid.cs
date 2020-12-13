using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class UpdateStrategyVoid : IUpdateStrategy
    {
        public void Update(Entity entity, float deltaTime)
        {
            // Do nothing
        }
    }
}
