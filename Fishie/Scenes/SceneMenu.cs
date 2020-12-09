using Fishie.Entities;
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
            target.Draw(fish, states);
        }

        public void HandleInput()
        {
            fish.HandleInput();
        }

        public void OnPop()
        {
        }

        public void OnPush(Game game)
        {
            circle = new CircleShape(10.0f);
            circle.Position = new Vector2f(100, 100);
            fish = new Fish(game.GetWindow());
        }

        public void RegisterEventHandlers(RenderWindow target)
        {
        }

        public void UnregisterEventHandlers(RenderWindow target)
        {
        }

        public void Update(float deltaTime)
        {
            fish.Update(deltaTime);
        }

        private CircleShape circle;
        private Fish fish;
    }
}
