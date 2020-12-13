using Fishie.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public interface ICollideStrategy
    {
        public void OnCollide(Entity A, Entity B);
    }
}
