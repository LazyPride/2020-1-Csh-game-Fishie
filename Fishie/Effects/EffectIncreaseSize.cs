using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    public class EffectIncreaseSize : Effect
    {
        public EffectIncreaseSize(float radius) : base()
        {
            this.radius = radius;
            Timeout = 0.0f;
        }
        public override void Update(Entity e, float deltaTime)
        {
        }

        public override void OnApply(Entity e)
        {
            Log.Info("Effect once: Increase size");
            e.Character.Radius += radius;
        }

        public override void OnTimeoutElapsed(Entity e)
        {
            
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        private float radius;
    }
}
