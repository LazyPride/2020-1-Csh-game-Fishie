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
        public EffectIncreaseSize(Entity A, float percent) : base()
        {
            this.A = A;
            this.percent = 1.0f + percent;
            Timeout = 0.0f;
        }
        public override void Update(float deltaTime)
        {
        }

        public override void OnApply()
        {
            A.Character.Radius *= percent;
        }

        public override void OnTimeoutElapsed()
        {
            
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        private Entity A;
        private float percent;
    }
}
