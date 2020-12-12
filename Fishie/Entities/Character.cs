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
        public ICollideStrategy CollideStrategy { get; set; }

        // TODO: Effect system

        public Character(IControlStrategy controlStrategy, IUpdateStrategy updateStrategy, ICollideStrategy collideStrategy)
        {
            ControlStrategy = controlStrategy;
            UpdateStrategy = updateStrategy;
            CollideStrategy = collideStrategy;
        }

        public void HandleInput()
        {
            ControlStrategy.HandleInput(this);
        }

        public void Update(float deltaTime)
        {
            UpdateStrategy.Update(this, deltaTime);
        }

        public void RegisterEventHandlers(RenderWindow target)
        {
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
        }

        public void OnCollide(Entity Lhs, Entity Rhs)
        {
            CollideStrategy.OnCollide(Lhs, Rhs);
        }
    }
}
