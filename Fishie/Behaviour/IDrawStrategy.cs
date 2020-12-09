using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    interface IDrawStrategy
    {
        public void Draw(RenderTarget target, RenderStates states);
    }
}
