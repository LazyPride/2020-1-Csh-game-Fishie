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
            target.Draw(cursor, states);
        }

        public void HandleInput()
        {
            fish.HandleInput();
            cursor.HandleInput();
        }

        public void OnPop()
        {
            game.GetWindow().SetMouseCursorVisible(true);
        }

        public void OnPush(Game game)
        {
            this.game = game;
            circle = new CircleShape(10.0f);
            circle.Position = new Vector2f(100, 100);
            fish = new Fish(game.GetWindow());
            camera = new Camera(new Vector2f(800, 600), game.GetWindow(), fish.GetCharacter());
            cursor = new Cursor(game.GetWindow());
            game.GetWindow().SetMouseCursorVisible(false);
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
            cursor.Update(deltaTime);
            camera.Update();

        }

        private Game game;
        private CircleShape circle;
        private Fish fish;
        private Camera camera;
        private Cursor cursor;
    }
}
