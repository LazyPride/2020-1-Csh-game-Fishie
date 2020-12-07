using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Scenes
{
    public interface IScene : Drawable
    {
        public void OnPush();
        public void OnPop();
        public void HandleInput();
        public void RegisterEventHandlers(RenderWindow target);
        public void UnregisterEventHandlers(RenderWindow target);
        public void Update(float deltaTime);
    }
}
