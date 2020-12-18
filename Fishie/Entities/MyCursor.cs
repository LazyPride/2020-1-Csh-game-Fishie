using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class MyCursor : Entity
    {
        public MyCursor(RenderWindow window, FloatRect gameArea) : base()
        {
            Character = new Character(this);
            Character.ControlStrategy = new ControlStrategyMouse(window);
            Character.UpdateStrategy = new UpdateStrategyVelocity();
            Character.Radius = 6.0f;
            Character.PointCount = 3;
            Character.FillColor = Color.Magenta;
            this.gameArea = gameArea;
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
            Vector2f pos = Character.Position;
            float radius = Character.Radius;
            if (pos.X - radius < gameArea.Left)
            {
                Character.Position = new Vector2f(gameArea.Left + radius, Character.Position.Y);
            }
            else if (pos.X + radius > (gameArea.Left + gameArea.Width))
            {
                Character.Position = new Vector2f(gameArea.Left + gameArea.Width - radius, Character.Position.Y);
            }

            if (pos.Y - radius < gameArea.Top)
            {
                Character.Position = new Vector2f(Character.Position.X, gameArea.Top + radius);
            }
            else if (pos.Y + radius > (gameArea.Top + gameArea.Height))
            {
                Character.Position = new Vector2f(Character.Position.X, gameArea.Top + gameArea.Height - radius);
            }
        }
       
        protected override void DoTouch(Entity entity)
        {
        }

        protected override void DoDetach(Entity entity)
        {
        }

        private FloatRect gameArea;
    }
}
