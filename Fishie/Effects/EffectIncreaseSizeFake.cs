using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    public class EffectIncreaseSizeFake : Effect
    {
        public EffectIncreaseSizeFake(float multiplier, float timeout) : base()
        {
            this.multiplier = multiplier;
            Timeout = timeout;
            scale = new Vector2f(0.1f, 0.1f);
        }
        public override void Update(Entity e, float deltaTime)
        {
            float time = clock.ElapsedTime.AsSeconds();
            if (time < Timeout * 0.33f)
            {
                scale.X = multiplier * time / Timeout * 0.33f;
            }
            else if (time > Timeout * 0.33f && time < Timeout * 0.66f)
            {
                scale.Y = multiplier * (time - Timeout * 0.33f) / Timeout * 0.33f;
            }
            else
            {
                scale *= 0.8f;
            }

            e.Character.Scale = scale;
        }

        public override void OnApply(Entity e)
        {
            Log.Info("Effect: Increase size [FAKE]");
            clock.Restart();
            e.Character.Scale = scale;
        }

        public override void OnTimeoutElapsed(Entity e)
        {
            e.Character.Scale = new Vector2f(1.0f, 1.0f);
            Log.Warn("Effect end: Increase size [FAKE]");
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        private float multiplier;
        private Vector2f scale;
    }
}
