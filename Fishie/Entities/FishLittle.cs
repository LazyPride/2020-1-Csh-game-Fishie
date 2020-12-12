using Fishie.Behaviour;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class FishLittle : Entity, Drawable
    {
        private Character character;
        private CircleShape shape = new CircleShape(8.0f, 12);
        public FishLittle()
        {
            character = new Character(new ControlStrategyStatic(),
                                        new UpdateStrategyVelocity(),
                                        new CollideStrategyStatic());
            shape.Origin = new Vector2f(8.0f, 8.0f);
            shape.FillColor = Color.Green;
            character.Position = new Vector2f(-100.0f, 100.0f);
            character.Radius = 8.0f;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(shape, states);
        }

        public void HandleInput()
        {
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
