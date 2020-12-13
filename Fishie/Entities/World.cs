using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class World : Drawable
    {
        public World()
        {
            // TODO: Decide whether we need gravity
            this.gravity = new Vector2f(0.0f, 9.8f);
        }

        public void AddEnity(Entity entity)
        {
            entities.Add(entity);
        }

        public void Update(float deltaTime, float scalar = 1.0f)
        {
            deltaTime = deltaTime * scalar;
            foreach (Entity e in entities)
            {
                // Apply gravity ?
                e.Update(deltaTime);
            }
            ResolveCollisions();
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (Entity e in entities)
            {
                e.Draw(target, states);
            }
        }
        private void ResolveCollisions()
        {
            for (Int32 i = 0; i < entities.Count; ++i)
            {
                for (Int32 j = i + 1; j < entities.Count; ++j)
                {
                    if (Intersects(entities[i], entities[j]))
                    {
                        // TODO: Generate manifold
                        entities[i].OnCollide(entities[j]);
                        entities[j].OnCollide(entities[i]);
                    }
                }
            }
        }

        private bool Intersects(Entity lhs, Entity rhs)
        {
            Character A = lhs.Character;
            Character B = rhs.Character;

            Vector2f Distance = B.Position - A.Position;
            float RadiusSum = A.Radius + B.Radius;
            float DistanceLen = Distance.X * Distance.X + Distance.Y * Distance.Y;
            if (DistanceLen > RadiusSum * RadiusSum)
            {
                return false;
            }

            // TODO: Add manifold generation
            return true;
        }

        private Vector2f gravity;
        private List<Entity> entities = new List<Entity>();
    }
}
