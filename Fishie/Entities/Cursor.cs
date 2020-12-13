using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class Cursor : Entity, Drawable
    {
        private Character character;
        public Cursor(RenderWindow window)
        {
            character = new Character();
            character.ControlStrategy = new ControlStrategyMouse(window);
            character.UpdateStrategy = new UpdateStrategyVelocity();
            character.CollideStrategy = new CollideStrategyStatic();
            character.Radius = 6.0f;
            character.PointCount = 3;
            character.FillColor = Color.Red;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(character, states);
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
        }
    }
}
