using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public interface IUpdateStrategy
    {
        public void Update(Character character, float deltaTime);
    }
}
