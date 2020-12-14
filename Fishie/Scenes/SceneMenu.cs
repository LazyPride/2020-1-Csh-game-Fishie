using Fishie.Entities;
using Fishie.Spawners;
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
            target.Draw(world, states);
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
            world = new World();

            fish = new Fish(game.GetWindow());
            camera = new Camera(new Vector2f(800, 600), game.GetWindow(), fish);
            cursor = new Cursor(game.GetWindow());
            foodSpawner = new FoodSpawner(new FloatRect(0.0f, 0.0f, 300.0f, 100.0f), 100, 0.10f);

            world.AddEnity(fish);

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
            Entity e = foodSpawner.Spawn();
            if (e != null)
            {
                world.AddEnity(e);
            }
            world.Update(deltaTime);
            cursor.Update(deltaTime);
            camera.Update();

        }

        private Game game;
        private World world;
        private Fish fish;
        private Camera camera;
        private Cursor cursor;
        private FoodSpawner foodSpawner;
    }
}
