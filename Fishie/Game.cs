using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fishie.Scenes;
using SFML;
using SFML.Graphics;
using SFML.System;

namespace Fishie
{
    public class Game
    {
        public void PushScene(IScene scene)
        {
            scenes.Push(scene);
            scene.OnPush();
            scene.RegisterEventHandlers(window);
        }
        public void PopScene(int quantity)
        {
            IsShouldPop = true;
            PopQuantity = quantity;
        }
        public void Run()
        {
            Init();
            Clock clock = new Clock();
            while (window.IsOpen)
            {
                float deltaTime = clock.Restart().AsSeconds();
                window.DispatchEvents();

                IScene currentScene = scenes.Last();

                currentScene.HandleInput();
                currentScene.Update(deltaTime);

                window.Clear(Color.Black);
                window.Draw(currentScene);
                window.Display();

                TryPop();
            }
        }
        private void Init()
        {
            window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Fishie");
            window.SetVerticalSyncEnabled(true);
            window.Closed += OnClose;

            scenes = new Stack<IScene>();
            PushScene(new SceneMenu());
        }

        private RenderWindow window;
        private Stack<IScene> scenes;
        private bool IsShouldPop = false;
        private int PopQuantity = 0;

        private void TryPop()
        {
            if (IsShouldPop)
            {
                while (PopQuantity > 0)
                {
                    IScene scene = scenes.Pop();
                    scene.OnPop();
                    scene.UnregisterEventHandlers(window);
                    PopQuantity--;
                }
                IsShouldPop = false;
            }
        }
        private static void OnClose(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(RenderWindow))
            {
                RenderWindow window = (RenderWindow)sender;
                window.Close();
            }
            
        }
    }
}

