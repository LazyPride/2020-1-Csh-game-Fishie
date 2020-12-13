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
        public Fish(RenderWindow window)
        {
            this.window = window;
            Character = new Character(this);
            Character.ControlStrategy = new ControlStrategyFollowMouse(window);
            Character.UpdateStrategy = new UpdateStrategyVelocity();
            Character.CollideStrategy = new CollideStrategyStatic();
            Character.Radius = 120.0f;
            Character.PointCount = 4;
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
        public override void OnCollide(Entity entity)
        {
            Character.OnCollide(entity);
            Character.ApplyEffect(new EffectSwapColors(this, entity));
        }

        private RenderWindow window;
    }
}
