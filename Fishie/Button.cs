using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie
{
    public class Button : Drawable
    {
        public delegate void OnMousePressed();
        public Button(Vector2f Position, Vector2f Size, string str, OnMousePressed action)
        {
            button = new RectangleShape();
            button.Size = Size;
            button.Position = Position;
            button.FillColor = Color.Cyan;
            this.action = action;
            font = new Font("res/arial.ttf");
            text = new Text(str, font);
            // Centering text
            text.Position = button.Position + (button.Size -
                new Vector2f(text.GetLocalBounds().Width, text.GetLocalBounds().Height));
        }

        public void RegisterEventHandlers(RenderWindow target)
        {
            target.MouseButtonPressed += OnMousePressedFunction;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(button);
            target.Draw(text);
        }
        private void OnMousePressedFunction(object sender, MouseButtonEventArgs e)
        {
            if (button.GetGlobalBounds().Contains(e.X, e.Y) && e.Button == Mouse.Button.Left)
            {
                action();
            }
        }

        private RectangleShape button;
        private Text text;
        private Font font;
        private OnMousePressed action;
    }
}
