using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public interface IControlStrategy
    {
        public void HandleInput(Character character);
    }
}
