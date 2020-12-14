using Fishie.Entities;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    public class CollideStrategyDynamic : ICollideStrategy
    {
        public void OnCollide(Entity A, Entity B)
        {
            Character cA = A.Character;
            Character cB = B.Character;
            Vector2f Distance = cA.Position - cB.Position;
            float DistanceLen = (float) Math.Sqrt( (double) (Distance.X * Distance.X + Distance.Y * Distance.Y));

            Log.Debug("collide dynamic");
            Vector2f normal = Distance / DistanceLen;
            Vector2f tangent = new Vector2f(-normal.Y, normal.X);

            float dpTan1 = cA.Velocity.X * tangent.X + cA.Velocity.Y * tangent.Y;
            float dpTan2 = cB.Velocity.X * tangent.X + cB.Velocity.Y * tangent.Y;

            float dpNorm1 = cA.Velocity.X * normal.X + cA.Velocity.Y * normal.Y;
            float dpNorm2 = cB.Velocity.X * normal.X + cB.Velocity.Y * normal.Y;

            // Conservation of momentum in 1D
            float m1 = (dpNorm1 * (cA.Mass - cB.Mass) + 2.0f * cB.Mass * dpNorm2) / (cA.Mass + cB.Mass);
            float m2 = (dpNorm2 * (cB.Mass - cA.Mass) + 2.0f * cA.Mass * dpNorm1) / (cA.Mass + cB.Mass);

            cA.Velocity = tangent * dpTan1 + normal * m1;
            cB.Velocity = tangent * dpTan2 + normal * m2;
            
        }
    }
}
