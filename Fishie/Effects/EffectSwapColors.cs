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
        }
        public override void Update(float deltaTime)
        {
        }

        public override void OnApply()
        {
            Color color = A.Character.FillColor;
            A.Character.FillColor = B.Character.FillColor;
            B.Character.FillColor = color;
        }

        public override void OnTimeoutElapsed()
        {
            
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        private Entity A;
        private Entity B;
    }
}
