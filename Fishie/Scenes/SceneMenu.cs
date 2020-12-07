using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Scenes
{
    public class SceneMenu : IScene
    {
        public SceneMenu()
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(circle, states);
        }

        public void HandleInput()
        {
        }

        public void OnPop()
        {
        }

        public void OnPush()
        {
            circle = new CircleShape(10.0f);
            circle.Position = new Vector2f(100, 100);
        }

        public void RegisterEventHandlers(RenderWindow target)
        {
        }

        public void UnregisterEventHandlers(RenderWindow target)
        {
        }

        public void Update(float deltaTime)
        {
        }

        private CircleShape circle;
    }
}
