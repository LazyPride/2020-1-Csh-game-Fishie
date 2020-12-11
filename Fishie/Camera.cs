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
        private View view;
        private Character character;
        private RenderWindow window;
        public Camera(Vector2f Size, RenderWindow window, Character characterToFollow)
        {
            this.window = window;
            this.view = new View(characterToFollow.Position, Size);
            this.Follow(characterToFollow);
        }

        public void Follow(Character characterToFollow)
        {
            this.character = characterToFollow;
            this.view.Center = this.character.Position;
        }

        public void Update()
        {
            // TODO: Fancy camera movement
            view.Center = character.Position;
            window.SetView(view);
        }

        public View GetView()
        {
            return view;
        }
    }
}
