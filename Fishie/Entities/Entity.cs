using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public abstract class Entity : Drawable
    {
        public Character Character { set;  get; }
        public abstract void HandleInput();
        public abstract void RegisterEventHandlers(RenderWindow target);
        public abstract void Update(float deltaTime);
        public abstract void Draw(RenderTarget target, RenderStates states);
        public abstract void OnCollide(Entity entity);

    }
}
