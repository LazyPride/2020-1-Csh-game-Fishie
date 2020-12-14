using Fishie.Behaviour;
using Fishie.Effects;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class Fish : Entity
    {
        public Fish(RenderWindow window) : base()
        {
            this.window = window;
            Character = new Character(this);
            Character.ControlStrategy = new ControlStrategyFollowMouse(window);
            Character.UpdateStrategy = new UpdateStrategyVelocity();
            Character.CollideStrategy = new CollideStrategyStatic();
            Character.Radius = 12.0f;
            Character.Mass = 12.0f;
            Character.PointCount = 8;
            Character.FillColor = Color.Magenta;
            Character.Position = new Vector2f(100.0f, 100.0f);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            Character.Draw(target, states);
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

        private RenderWindow window;
    }
}
