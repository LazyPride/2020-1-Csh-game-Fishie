using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fishie.Scenes;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Fishie
{
    public class Game
    {
        public RenderWindow GetWindow()
        {
            return window;
        }
        public void PushScene(IScene scene)
        {
            scenes.Push(scene);
            scene.OnPush(this);
            scene.RegisterEventHandlers(window);
        }
        public void PopScene(int quantity = 1)
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

                IScene currentScene = scenes.Peek();

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
            window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Fishie", Styles.None);
            
            window.SetVerticalSyncEnabled(true);
            window.Closed += OnClose;

            scenes = new Stack<IScene>(5);
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

