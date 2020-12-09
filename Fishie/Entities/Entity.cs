using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public interface Entity
    {
        public void HandleInput();
        public void RegisterEventHandlers(RenderWindow target);
        public void Update(float deltaTime);
        public void Draw(RenderTarget target, RenderStates states);
    }
}
