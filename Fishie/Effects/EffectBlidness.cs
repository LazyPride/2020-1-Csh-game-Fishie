using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    class EffectBlindess : Effect
    {
        public EffectBlindess(byte alpha, float seconds) : base()
        {
            Timeout = seconds;
            blind = new RectangleShape(new Vector2f(5000.0f, 5000.0f));
            blind.Origin = new Vector2f(5000.0f, 5000.0f) / 2;
            blind.FillColor = new Color(0, 0, 0, alpha);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(blind);
        }

        public override void OnApply(Entity e)
        {
            Log.Info("Effect: Blindness");
            clock.Restart();
        }

        public override void OnTimeoutElapsed(Entity e)
        {
            Log.Warn("Effect end: Blindness");
        }

        public override void Update(Entity e, float deltaTime)
        {
        }
        private RectangleShape blind;

    }
}
