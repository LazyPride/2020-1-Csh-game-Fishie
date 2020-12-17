using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie
{
    public class Camera
    {
        public Camera(Vector2f Size, FloatRect gameArea, RenderWindow window, Entity entityToFollow)
        {
            this.window = window;
            this.view = new View(entityToFollow.Character.Position, Size);
            this.Follow(entityToFollow);
            ObservableGameArea = new FloatRect(gameArea.Left + Size.X / 2,
                                                gameArea.Top + Size.Y / 2,
                                                (gameArea.Left + gameArea.Width) - Size.X,
                                                (gameArea.Top + gameArea.Height) - Size.Y);
            cameraPos = new Vector2f(entity.Character.Position.X, entity.Character.Position.Y);
        }

        public void Follow(Entity entityToFollow)
        {
            this.entity = entityToFollow;
            cameraPos = this.entity.Character.Position;
        }

        public void Update()
        {
            // TODO: Fancy camera movement
            Vector2f pos = entity.Character.Position;
            if (pos.X > ObservableGameArea.Left && pos.X < (ObservableGameArea.Left + ObservableGameArea.Width))
            {
                cameraPos.X = entity.Character.Position.X;
            }
            if (pos.Y > ObservableGameArea.Top && pos.Y < (ObservableGameArea.Top + ObservableGameArea.Height))
            {
                cameraPos.Y = entity.Character.Position.Y;
            }
            this.view.Center = cameraPos;
            window.SetView(view);
        }

        public View GetView()
        {
            return view;
        }

       
        private View view;
        private Entity entity;
        private RenderWindow window;
        private FloatRect ObservableGameArea;
        private Vector2f cameraPos;
    }
}
