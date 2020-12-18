using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    class EffectSlowness : Effect
    {
        public EffectSlowness(float seconds) : base()
        {
            Timeout = seconds;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        public override void OnApply(Entity e)
        {
            Log.Info("Effect: Slowness");
            clock.Restart();
        }

        public override void OnTimeoutElapsed(Entity e)
        {
            Log.Warn("Effect end: Slowness");
        }

        public override void Update(Entity e, float deltaTime)
        {
            e.Character.Velocity *= 0.1f;
        }
    }
}
