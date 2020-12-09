using Fishie.Behaviour;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    class CharacterFacade
    {
        private IControlStrategy controlStrategy;
        private IDrawStrategy drawStrategy;
        private IUpdateStrategy updateStrategy;

        public void Draw(RenderTarget target, RenderStates states)
        {
            //drawStrategy.Draw(target, states);
        }

        public void HandleInput()
        {
            //controlStrategy.HandleInput()
        }

        public void Update(float deltaTime)
        {
            updateStrategy.Update(deltaTime);
        }
    }
}
