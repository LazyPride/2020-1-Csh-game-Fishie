using Fishie.Entities;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class CollideStrategyStatic : ICollideStrategy
    {
        public void OnCollide(Entity Lhs, Entity Rhs)
        {
            Character A = Lhs.GetCharacter();
            Character B = Rhs.GetCharacter();
            Vector2f Distance = A.Position - B.Position;
            float DistanceLen = (float) Math.Sqrt( (double) (Distance.X * Distance.X + Distance.Y * Distance.Y));
            float RadiusSum = A.Radius + B.Radius;
            float Overlap = DistanceLen - RadiusSum;

            // TODO: Add type(Dynamic, Static) physical object check
            // If object Static than its position is imutable
            Vector2f normal = Distance / DistanceLen;
            A.Position -= Overlap * 0.5f * normal;
            B.Position += Overlap * 0.5f * normal;
        }
    }
}
