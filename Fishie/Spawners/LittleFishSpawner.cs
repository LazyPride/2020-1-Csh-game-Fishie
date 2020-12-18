using Fishie.Behaviour;
using Fishie.Effects;
using Fishie.Entities;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Spawners
{
    public class LittleFishSpawner : Spawner
    {
        public LittleFishSpawner(FloatRect spawnArea, uint MaxN)
        {
            this.spawnArea = spawnArea;
            this.maxEntities = MaxN;
            this.currentEntityCounter = 0;
            colors.Add(Color.Black);
            colors.Add(Color.Blue);
            colors.Add(Color.Cyan);
            colors.Add(Color.Green);
            colors.Add(Color.Red);
            colors.Add(Color.White);
            colors.Add(Color.Yellow);
        }
        public Entity Spawn()
        {
            if (currentEntityCounter < maxEntities)
            {
                currentEntityCounter += 1;
                Random random = new Random();
                Color color = colors[random.Next(colors.Count)];

                LittleFish fish = new LittleFish();
                fish.Character.Position = GetPositionInside(spawnArea);
                fish.Character.Radius = random.Next(6, 9);
                fish.Character.PointCount = (uint)random.Next(4, 8);
                fish.Character.Mass = fish.Character.Radius;
                fish.Character.FillColor = color;
                return fish;
            }
            return null;
        }

        private Vector2f GetPositionInside(FloatRect area)
        {
            Random random = new Random();
            float x = (float)random.NextDouble() * area.Width + area.Left;
            float y = (float)random.NextDouble() * area.Height + area.Top;
            return new Vector2f(x, y);
        }

        public uint GetQuantity()
        {
            return maxEntities;
        }

        private FloatRect spawnArea;
        private uint maxEntities;
        private uint currentEntityCounter;
        private List<Color> colors = new List<Color>();
    }
}
