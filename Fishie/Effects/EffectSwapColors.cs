using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    public class EffectSwapColors : Effect
    {
        public EffectSwapColors(Entity A, Entity B) : base()
        {
            this.A = A;
            this.B = B;
            Timeout = 0.1f;
        }
        public override void Update(float deltaTime)
        {
        }

        public override void OnApply()
        {
            
        }

        public override void OnTimeoutElapsed()
        {
            Color color = A.Character.FillColor;
            A.Character.FillColor = B.Character.FillColor;
            B.Character.FillColor = color;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        private Entity A;
        private Entity B;
    }
}
