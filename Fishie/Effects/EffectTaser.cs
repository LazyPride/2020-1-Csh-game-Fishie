using Fishie.Behaviour;
using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    class EffectTaser : Effect
    {
        public EffectTaser(float seconds) : base()
        {
            Timeout = seconds;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        public override void OnApply(Entity e)
        {
            Log.Info("Effect: Taser");
            clock.Restart();
        }

        public override void OnTimeoutElapsed(Entity e)
        {
            Log.Warn("Effect end: Taser");
        }

        public override void Update(Entity e, float deltaTime)
        {
            Random random = new Random();
            e.Character.Position += new Vector2f((float)random.NextDouble() * 20.0f - 10.0f,
                (float)random.NextDouble() * 20.0f - 10.0f);
            e.Character.Velocity += new Vector2f((float)random.NextDouble() * 20.0f - 10.0f,
                (float)random.NextDouble() * 20.0f - 10.0f);
            e.Character.Velocity -= e.Character.Velocity * 0.6f;
        }
    }
}
