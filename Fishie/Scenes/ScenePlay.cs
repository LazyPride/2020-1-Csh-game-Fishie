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
    public class ScenePlay : IScene
    {
        public ScenePlay()
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
            world.HandleInput();
            cursor.HandleInput();
            Mouse.SetPosition(game.GetWindow().Position + (Vector2i)game.GetWindow().Size / 2);
        }

        public void OnPop()
        {
            game.GetWindow().SetMouseCursorVisible(true);
        }

        public void OnPush(Game game)
        {
            aqvariumTexture = new Texture("res/aqvarium.jpg");
            aqvarium = new Sprite(aqvariumTexture);
            FloatRect gameArea = new FloatRect(0.0f, 0.0f, 1920.0f, 1200.0f);
            this.game = game;
            game.GetWindow().SetMouseCursorVisible(false);

            world = new World(gameArea);

            cursor = new MyCursor(game.GetWindow(), gameArea);
            cursor.Character.Position = new Vector2f(960.0f, 600.0f);

            Entity fish = new Fish(cursor);
            fish.Character.Position = new Vector2f(960.0f, 600.0f);
            world.AddEnity(fish);
            
            camera = new Camera(new Vector2f(800, 600), gameArea, game.GetWindow(), fish);

            spawners.Add(new FoodSpawner(new FloatRect(100.0f, 100.0f, 1700.0f, 400.0f), 100));
            spawners.Add(new LittleFishSpawner(new FloatRect(100.0f, 800.0f, 100.0f, 200.0f), 50));
            spawners.Add(new LittleFishSpawner(new FloatRect(1600.0f, 800.0f, 200.0f, 200.0f), 200));

            foreach (Spawner spawner in spawners)
            {
                for (int i = 0; i < spawner.GetQuantity(); i++)
                {
                    world.AddEnity(spawner.Spawn());
                }
            }
        }

        public void RegisterEventHandlers(RenderWindow target)
        {
            target.KeyPressed += OnKeyPressed;
        }

        public void UnregisterEventHandlers(RenderWindow target)
        {
            target.KeyPressed -= OnKeyPressed;
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                Log.Warn("Escape pressed");
                game.PushScene(new ScenePause());
            }
        }

        public void Update(float deltaTime)
        {
            world.Update(deltaTime);
            cursor.Update(deltaTime);
            camera.Update();

        }

        private Game game;
        private World world;
        private Camera camera;
        private MyCursor cursor;
        private List<Spawner> spawners = new List<Spawner>();
        private Texture aqvariumTexture;
        private Sprite aqvarium;
    }
}
