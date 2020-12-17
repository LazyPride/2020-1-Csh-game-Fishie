using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class World : Drawable
    {
        public World(FloatRect gameArea)
        {
            // TODO: Decide whether we need gravity
            this.gravity = new Vector2f(0.0f, 9.8f);
            this.gameArea = gameArea;
        }

        public void AddEnity(Entity entity)
        {
            entities.Add(entity);
        }

        public void Update(float deltaTime, float scalar = 1.0f)
        {
            ClearDeadEntities();
            deltaTime = deltaTime * scalar;
            foreach (Entity e in entities)
            {
                // Apply gravity ?
                e.Update(deltaTime);
                Vector2f pos = e.Character.Position;
                float radius = e.Character.Radius;
                if (pos.X - radius < gameArea.Left)
                {
                    e.Character.Position = new Vector2f(gameArea.Left + radius, e.Character.Position.Y);
                }
                else if (pos.X + radius > (gameArea.Left + gameArea.Width))
                {
                    e.Character.Position = new Vector2f(gameArea.Left + gameArea.Width - radius, e.Character.Position.Y);
                }
                
                if (pos.Y - radius < gameArea.Top)
                {
                    e.Character.Position = new Vector2f(e.Character.Position.X, gameArea.Top + radius);
                }
                else if (pos.Y + radius > (gameArea.Top + gameArea.Height))
                {
                    e.Character.Position = new Vector2f(e.Character.Position.X, gameArea.Top + gameArea.Height - radius);
                }
                
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
                        entities[i].Character.OnCollide(entities[j]);
                        entities[j].Character.OnCollide(entities[i]);
                    }
                    if (Touch(entities[i], entities[j]))
                    {
                        if (!entities[i].HasContact(entities[j]))
                        {
                            entities[i].OnTouch(entities[j]);
                            entities[j].OnTouch(entities[i]);
                        }
                    }
                    else
                    {
                        if (entities[i].HasContact(entities[j]))
                        {
                            entities[i].OnDetach(entities[j]);
                            entities[j].OnDetach(entities[i]);
                        }
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
            return (DistanceLen < RadiusSum * RadiusSum);
        }
        private bool Touch(Entity lhs, Entity rhs)
        {
            Character A = lhs.Character;
            Character B = rhs.Character;

            Vector2f Distance = B.Position - A.Position;
            float RadiusSum = A.Radius + B.Radius;
            float DistanceLen = (float)Math.Sqrt((double)(Distance.X * Distance.X + Distance.Y * Distance.Y));
            return (Math.Abs(DistanceLen - RadiusSum) < TOUCH_GAP);
        }

        private void ClearDeadEntities()
        {
            List<Entity> entitiesDead = new List<Entity>();
            foreach (Entity e in entities)
            {
                if (!e.IsAlive)
                {
                    entitiesDead.Add(e);
                }
            }
            foreach (Entity e in entitiesDead)
            {
                entities.Remove(e);
            }
            entitiesDead.Clear();
        }

        private Vector2f gravity;
        private FloatRect gameArea = new FloatRect();
        private List<Entity> entities = new List<Entity>();
        private const float TOUCH_GAP = 5.0f;
    }
}
