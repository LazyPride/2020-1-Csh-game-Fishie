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
        private CircleShape shape = new CircleShape(12.0f, 5);
        private RenderWindow window;
        public Fish(RenderWindow window)
        {
            this.window = window;
            character = new Character(new ControlStrategyFollowMouse(window),
                                        new UpdateStrategyVelocity(),
                                        new CollideStrategyStatic());
            shape.Origin = new Vector2f(12.0f, 12.0f);
            character.Radius = 12.0f;
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
            shape.Rotation = character.Rotation;
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
