using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    class EffectIncreaseSpeed : Effect
    {
        public EffectIncreaseSpeed(Entity A, float percent, float seconds) : base()
        {
            this.A = A;
            this.percent = 1.0f + percent;
            Timeout = seconds;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        public override void OnApply()
        {
            Log.Info("Started speed");
        }

        public override void OnTimeoutElapsed()
        {
            Log.Info("Speed over!");
        }

        public override void Update(float deltaTime)
        {
            A.Character.Velocity *= percent;
        }
        private Entity A;
        private float percent;
    }
}
