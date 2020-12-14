using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    public abstract class Effect : Drawable
    {
        public Effect()
        {
            clock.Restart();
        }
        public float Timeout { get; set; }
        public bool hasElapsed()
        {
            return (clock.ElapsedTime.AsSeconds() > Timeout);
        }
        public abstract void Update(Entity e, float deltaTime);
        public abstract void OnApply(Entity e);
        public abstract void OnTimeoutElapsed(Entity e);
        public abstract void Draw(RenderTarget target, RenderStates states);
        
        protected Clock clock = new Clock();
    }
}
