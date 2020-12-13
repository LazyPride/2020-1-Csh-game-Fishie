using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class Fish : Entity, Drawable
    {
        private Character character;
        private RenderWindow window;
        public Fish(RenderWindow window)
        {
            this.window = window;
            character = new Character();
            character.ControlStrategy = new ControlStrategyFollowMouse(window);
            character.UpdateStrategy = new UpdateStrategyVelocity();
            character.CollideStrategy = new CollideStrategyStatic();
            character.Radius = 12.0f;
            character.PointCount = 4;
            character.FillColor = Color.Magenta;
            character.Position = new Vector2f(100.0f, 100.0f);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            character.Draw(target, states);
        }

        public void HandleInput()
        {
            character.HandleInput();
        }

        public void RegisterEventHandlers(RenderWindow target)
        {

        }

        public void Update(float deltaTime)
        {
            character.Update(deltaTime);
        }


        public Character GetCharacter()
        {
            return character;
        }

        public void OnCollide(Entity entity)
        {
            character.OnCollide(this, entity);
        }
    }
}
