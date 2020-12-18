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
    public class FoodSpawner : Spawner
    {
        public FoodSpawner(FloatRect spawnArea, uint MaxN)
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
                    List<Effect> touchEffects = new List<Effect>();
                    touchEffects.Add(createEffect(color));
                    Food food = new Food(touchEffects);
                    food.Character.UpdateStrategy = new UpdateStrategyDynamic();
                    food.Character.Position = GetPositionInside(spawnArea);
                    food.Character.Radius = random.Next(5, 10);
                    food.Character.Mass = food.Character.Radius;
                    food.Character.FillColor = color;
                    return food;
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

        private Effect createEffect(Color color)
        {
            if (color == Color.Black)
            {
                return new EffectBlindess(220, 5);
            }
            else if (color == Color.Blue)
            {
                return new EffectColors(6);
            }
            else if (color == Color.Green)
            {
                return new EffectIncreaseSize(1.0f);
            }
            else if (color == Color.Cyan)
            {
                return new EffectSlowness(6.0f);
            }
            else if (color == Color.Red)
            {
                return new EffectIncreaseSizeFake(30.0f, 5.0f);
            }
            else if (color == Color.White)
            {
                return new EffectIncreaseSpeed(3.0f, 5.0f);
            }
            else if (color == Color.Yellow)
            {
                return new EffectTaser(5.0f);
            }
            return new EffectVoid();
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
