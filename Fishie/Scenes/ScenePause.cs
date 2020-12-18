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
    public class ScenePause : IScene
    {
        public ScenePause()
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(background);
            target.Draw(resume);
            target.Draw(menu);
        }

        public void HandleInput()
        {
            
        }

        public void OnPop()
        {
            game.GetWindow().SetMouseCursorVisible(false);
        }

        public void OnPush(Game game)
        {
            this.game = game;
            game.GetWindow().SetMouseCursorVisible(true);
            view = new View(new FloatRect(0.0f, 0.0f, 800.0f, 600.0f));
            background = new RectangleShape(new Vector2f(800.0f, 600.0f));
            background.FillColor = new Color(0, 171, 217);
            resume = new Button(new Vector2f(100.0f, 100.0f),
                                  new Vector2f(256.0f, 128.0f),
                                  "Resume",
                                  () =>
                                  {
                                      game.PopScene();
                                  });
            menu = new Button(new Vector2f(100.0f, 300.0f),
                                  new Vector2f(256.0f, 128.0f),
                                  "Menu",
                                  () =>
                                  {
                                      game.PopScene(2);
                                  });
            game.GetWindow().SetView(view);
        }

        public void RegisterEventHandlers(RenderWindow target)
        {
            resume.RegisterEventHandlers(target);
            menu.RegisterEventHandlers(target);
        }

        public void UnregisterEventHandlers(RenderWindow target)
        {
            resume.UnregisterEventHandlers(target);
            menu.UnregisterEventHandlers(target);
        }

        public void Update(float deltaTime)
        { 
        }

        private Game game;
        private View view;
        private RectangleShape background;
        private Button resume;
        private Button menu;
    }
}
