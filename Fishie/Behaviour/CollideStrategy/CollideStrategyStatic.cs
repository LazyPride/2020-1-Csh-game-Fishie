using Fishie.Entities;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class CollideStrategyStatic : ICollideStrategy
    {
        public void OnCollide(Entity A, Entity B)
        {
            Character cA = A.Character;
            Character cB = B.Character;
            Vector2f Distance = cA.Position - cB.Position;
            float DistanceLen = (float) Math.Sqrt( (double) (Distance.X * Distance.X + Distance.Y * Distance.Y));
            float RadiusSum = cA.Radius + cB.Radius;
            float Overlap = DistanceLen - RadiusSum;

            // TODO: cAdd type(Dynamic, Static) physical object check
            // If object Static than its position is imutable
            Vector2f normal = Distance / DistanceLen;
            cA.Position -= Overlap * 0.5f * normal;
            cB.Position += Overlap * 0.5f * normal;
        }
    }
}
