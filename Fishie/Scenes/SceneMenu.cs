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
            target.Draw(background);
            target.Draw(play);
            target.Draw(exit);
        }

        public void HandleInput()
        {
            
        }

        public void OnPop()
        {
        }

        public void OnPush(Game game)
        {
            this.game = game;
            game.GetWindow().SetMouseCursorVisible(true);
            view = new View(new FloatRect(0.0f, 0.0f, 800.0f, 600.0f));
            background = new RectangleShape(new Vector2f(800.0f, 600.0f));
            background.FillColor = new Color(0, 171, 217);
            play = new Button(new Vector2f(100.0f, 100.0f),
                                  new Vector2f(256.0f, 128.0f),
                                  "Play",
                                  () =>
                                  {
                                      game.PushScene(new ScenePlay());
                                      play.UnregisterEventHandlers(game.GetWindow());
                                      exit.UnregisterEventHandlers(game.GetWindow());
                                      isCallbackRegistered = false;
                                  });
            exit = new Button(new Vector2f(100.0f, 300.0f),
                                  new Vector2f(256.0f, 128.0f),
                                  "Exit",
                                  () =>
                                  {
                                      game.GetWindow().Close();
                                  });
            game.GetWindow().SetView(view);
        }

        public void RegisterEventHandlers(RenderWindow target)
        {
            play.RegisterEventHandlers(target);
            exit.RegisterEventHandlers(target);
            isCallbackRegistered = true;
        }

        public void UnregisterEventHandlers(RenderWindow target)
        {
            play.UnregisterEventHandlers(target);
            exit.UnregisterEventHandlers(target);
            isCallbackRegistered = false;
        }

        public void Update(float deltaTime)
        { 
            if (!isCallbackRegistered)
            {
                play.RegisterEventHandlers(game.GetWindow());
                exit.RegisterEventHandlers(game.GetWindow());
                isCallbackRegistered = true;
            }
        }

        private Game game;
        private View view;
        private RectangleShape background;
        private Button play;
        private Button exit;
        private Boolean isCallbackRegistered = false;
    }
}
