using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    class EffectVoid : Effect
    {
        public EffectVoid() : base()
        {
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
        }

    }
}
