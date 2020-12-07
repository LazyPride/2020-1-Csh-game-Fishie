﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    interface Entity
    {
        public void Init();
        public void HandleInput();
        public void RegisterEventHandlers(RenderWindow target);
        public void Update(Double deltaTime);
        public void Draw(RenderTarget target, RenderStates states);
    }
}
