using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class LittleFish : Entity
    {
        public LittleFish()
        {
            Character = new Character(this);
            Character.ControlStrategy = new ControlStrategyVoid();
            Character.UpdateStrategy = new UpdateStrategyDynamic();
            Character.CollideStrategy = new CollideStrategyDynamic();
            Character.Mass = 8.0f;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Character, states);
        }

        public override void HandleInput()
        {
        }

        public override void RegisterEventHandlers(RenderWindow target)
        {

        }

        public override void Update(float deltaTime)
        {
            Character.Update(deltaTime);
        }

        protected override void DoTouch(Entity entity)
        {
        }

        protected override void DoDetach(Entity entity)
        {
        }
    }
}
