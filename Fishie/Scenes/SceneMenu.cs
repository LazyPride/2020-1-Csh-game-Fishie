using Fishie.Behaviour;
using Fishie.Entities;
using Fishie.Spawners;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
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
            target.Draw(aqvarium, states);
            target.Draw(world, states);
            target.Draw(cursor, states);
        }

        public void HandleInput()
        {
            fish.HandleInput();
            cursor.HandleInput();
            Mouse.SetPosition(game.GetWindow().Position + (Vector2i)game.GetWindow().Size / 2);
        }

        public void OnPop()
        {
            //game.GetWindow().SetMouseCursorVisible(true);
        }

        public void OnPush(Game game)
        {
            this.game = game;
            world = new World();

            cursor = new MyCursor(game.GetWindow());
            fish = new Fish(cursor);
            fish.Character.Position = new Vector2f(960.0f, 540.0f);
            camera = new Camera(new Vector2f(800, 600), game.GetWindow(), fish);
            foodSpawner = new FoodSpawner(new FloatRect(100.0f, 100.0f, 1700.0f, 300.0f), 100, 0.10f);

            world.AddEnity(fish);
            Entity little = new FishLittle();
            world.AddEnity(little);
            aqvariumTexture = new Texture("res/aqvarium.jpg");
            aqvarium = new Sprite(aqvariumTexture);
            //game.GetWindow().SetMouseCursorVisible(false);
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
        private MyCursor cursor;
        private FoodSpawner foodSpawner;
        private Texture aqvariumTexture;
        private Sprite aqvarium;
    }
}
