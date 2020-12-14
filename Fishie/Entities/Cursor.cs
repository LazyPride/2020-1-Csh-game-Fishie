using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class Cursor : Entity
    {
        public Cursor(RenderWindow window) : base()
        {
            Character = new Character(this);
            Character.ControlStrategy = new ControlStrategyMouse(window);
            Character.UpdateStrategy = new UpdateStrategyVelocity();
            Character.Radius = 6.0f;
            Character.PointCount = 3;
            Character.FillColor = Color.Red;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Character, states);
        }

        public override void HandleInput()
        {
            Character.HandleInput();
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
