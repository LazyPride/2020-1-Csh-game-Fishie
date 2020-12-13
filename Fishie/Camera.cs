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
        public Camera(Vector2f Size, RenderWindow window, Entity entityToFollow)
        {
            this.window = window;
            this.view = new View(entityToFollow.Character.Position, Size);
            this.Follow(entityToFollow);
        }

        public void Follow(Entity entityToFollow)
        {
            this.entity = entityToFollow;
            this.view.Center = this.entity.Character.Position;
        }

        public void Update()
        {
            // TODO: Fancy camera movement
            view.Center = entity.Character.Position;
            window.SetView(view);
        }

        public View GetView()
        {
            return view;
        }

        private View view;
        private Entity entity;
        private RenderWindow window;
    }
}
