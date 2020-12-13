using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class FishLittle : Entity
    {
        private CircleShape shape = new CircleShape(8.0f, 12);
        public FishLittle()
        {
            Character = new Character(this);
            Character.ControlStrategy = new ControlStrategyVoid();
            Character.UpdateStrategy = new UpdateStrategyVelocity();
            Character.CollideStrategy = new CollideStrategyStatic();
            Character.Radius = 8.0f;
            Character.FillColor = Color.Green;
            Character.Position = new Vector2f(-100.0f, 100.0f);
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

        public override void OnCollide(Entity entity)
        {
            Character.OnCollide(entity);
        }

        protected override void DoTouch(Entity entity)
        {
        }

        protected override void DoDetach(Entity entity)
        {
        }
    }
}
