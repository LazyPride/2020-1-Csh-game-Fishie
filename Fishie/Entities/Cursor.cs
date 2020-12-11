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
        private CircleShape shape = new CircleShape(6.0f, 3);
        private RenderWindow window;
        public Cursor(RenderWindow window)
        {
            this.window = window;
            character = new Character(new ControlStrategyMouse(window), new UpdateStrategyVelocity());
            shape.Origin = new Vector2f(3.0f, 3.0f);
            shape.FillColor = Color.Red;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(shape, states);
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
            shape.Position = character.Position;
        }

        public Character GetCharacter()
        {
            return character;
        }

    }
}
