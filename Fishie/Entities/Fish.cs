using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class Fish : Transformable, Entity, Drawable
    {
        private IControlStrategy controlStrategy;
        private IDrawStrategy drawStrategy;
        private IUpdateStrategy updateStrategy;

        /* Put into Physical object */
        public Vector2f Acceleration { get; set; }
        public Vector2f Velocity { get; set; }
        public float VelocityAngular { get; set; }
        public float Mass { get; set; }
        public float MassInverted { get; set; }
        public float Interia { get; set; }

        CircleShape shape;
        RenderWindow window;
        public Fish(RenderWindow window)
        {
            shape = new CircleShape(12.0f, 5);
            shape.Origin = new Vector2f(12.0f, 12.0f);
            shape.Position = new Vector2f(300.0f, 300.0f);
            Position = new Vector2f(300.0f, 300.0f);
            this.window = window;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(shape, states);
        }

        public void HandleInput()
        {
            Vector2f direction = (Vector2f)Mouse.GetPosition(window) - Position;

            double angle = Math.Atan2(direction.Y, direction.X) * 180.0 / Math.PI + 180.0;
            if (!Double.IsNaN(angle))
            {
                Rotation = (float)angle;
            }

            Velocity = direction * 2.0f;
           
        }

        public void Init()
        {

        }

        public void RegisterEventHandlers(RenderWindow target)
        {

        }

        public void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;

            shape.Position = Position;
            shape.Rotation = Rotation;
        }
    }
}
