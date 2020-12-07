using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML;
using SFML.Graphics;

namespace Fishie
{
    class Game
    {
        public void Run()
        {
            Init();
            RegisterEventHandlers();
            while(true)
            {
                // Dispatch events
                HandleInput();
                Update();
                Draw();
            }
        }

        private RenderWindow window;

        private void Init()
        {

        }
        private void RegisterEventHandlers()
        {

        }
        private void HandleInput()
        {

        }
        private void Update()
        {

        }
        private void Draw()
        {

        }
    }
}
