using Fishie.Behaviour;
using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    class EffectColors : Effect
    {
        public EffectColors(float seconds) : base()
        {
            Timeout = seconds;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        public override void OnApply(Entity e)
        {
            Log.Info("Effect: Colors");
            save = e.Character.FillColor;
            clock.Restart();
            switchClock.Restart();
        }

        public override void OnTimeoutElapsed(Entity e)
        {
            e.Character.FillColor = save;
            Log.Warn("Effect end: Colors");
        }

        public override void Update(Entity e, float deltaTime)
        {
            if (switchClock.ElapsedTime.AsSeconds() > 0.2f)
            {
                Random random = new Random();
                e.Character.FillColor = new Color((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
                switchClock.Restart();
            }
        }
        Color save;
        Clock switchClock = new Clock();
    }
}
