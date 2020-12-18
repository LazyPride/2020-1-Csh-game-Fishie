using Fishie.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Spawners
{
    public interface Spawner
    {
        public Entity Spawn();
        public uint GetQuantity();
    }
}