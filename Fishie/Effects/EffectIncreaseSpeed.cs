using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    class EffectIncreaseSpeed : Effect
    {
        public EffectIncreaseSpeed(float percent, float seconds) : base()
        {
            this.percent = 1.0f + percent;
            Timeout = seconds;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        public override void OnApply(Entity e)
        {
        }

        public override void OnTimeoutElapsed(Entity e)
        {
        }

        public override void Update(Entity e, float deltaTime)
        {
            e.Character.Velocity *= percent;
        }
        private float percent;
    }
}
