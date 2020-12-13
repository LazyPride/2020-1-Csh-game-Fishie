using Fishie.Behaviour;
using Fishie.Effects;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    // Facade + strategy
    public class Character : PhysicalObject, Drawable
    {
        public float Radius
        {
            get
            {
                return circle.Radius;
            }
            set
            {
                circle.Radius = value;
                circle.Origin = new Vector2f(value, value);
            }

        }
        public uint PointCount
        {
            get
            {
                return circle.GetPointCount();
            }
            set
            {
                circle.SetPointCount(value);
            }
        }

        public Color FillColor
        {
            get
            {
                return circle.FillColor;
            }
            set
            {
                circle.FillColor = value;
            }
        }

        public IControlStrategy ControlStrategy { get; set; }
        public IUpdateStrategy UpdateStrategy { get; set; }
        public ICollideStrategy CollideStrategy { get; set; }

        // TODO: Effect system
        public Character(Entity entity)
        {
            this.entity = entity;
        }
        public void HandleInput()
        {
            if (ControlStrategy != null) ControlStrategy.HandleInput(entity);
        }

        public void Update(float deltaTime)
        {
            if (UpdateStrategy != null) UpdateStrategy.Update(entity, deltaTime);
            circle.Position = Position;
            circle.Rotation = Rotation;

            List<Effect> effectsEllapced = new List<Effect>();
            foreach (Effect e in effects)
            {
                if (e.hasElapsed())
                {
                    e.OnTimeoutElapsed();
                    effectsEllapced.Add(e);
                }
                else
                {
                    e.Update(deltaTime);
                }
            }
            foreach (Effect e in effectsEllapced)
            {
                effects.Remove(e);
            }
            effectsEllapced.Clear();

        }

        public void RegisterEventHandlers(RenderWindow target)
        {
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(circle, states);
        }

        public void OnCollide(Entity entity)
        {
            if (CollideStrategy != null) CollideStrategy.OnCollide(this.entity, entity);
        }

        public void ApplyEffect(Effect effect)
        {
            if (effect.Timeout == 0.0f)
            {
                effect.OnApply();
                effect.OnTimeoutElapsed();
            }
            else if (!IsPresent(effect))
            {
                effects.Add(effect);
                effect.OnApply();
            }
        }

        private bool IsPresent(Effect effect)
        {
            foreach (Effect e in effects)
            {
                if (e.GetType().Name.Equals(effect.GetType().Name))
                {
                    return true;
                }
            }
            return false;
        }

        private CircleShape circle = new CircleShape();
        private Entity entity;
        private List<Effect> effects = new List<Effect>();
    }
}
