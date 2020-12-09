using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    // Facade + strategy
    public class Character : PhysicalObject
    {
        public IControlStrategy ControlStrategy { get; set; }
        public IUpdateStrategy UpdateStrategy { get; set; }
        
        // TODO: Effect system

        public Character(IControlStrategy controlStrategy, IUpdateStrategy updateStrategy)
        {
            ControlStrategy = controlStrategy;
            UpdateStrategy = updateStrategy;
        }

        public void HandleInput()
        {
            ControlStrategy.HandleInput(this);
        }

        public void Update(float deltaTime)
        {
            UpdateStrategy.Update(this, deltaTime);
        }
    }
}
