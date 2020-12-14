using Fishie.Effects;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Spawners
{
    public class FoodSpawner : Spawner
    {
        FoodSpawner(FloatRect spawnArea, uint MaxN, float delayBetweenSpawn)
        {

        }
        public void Spawn()
        {
        }

        private Effect createEffect(Color color)
        {
            return null;
        }

        private Clock clock;
        private uint maxEntities;
    }
}
