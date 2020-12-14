using Fishie.Effects;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    public class Food : Entity
    {
        public Food(List<Effect> touchEffects) : base()
        {
            Character = new Character(this);
            this.touchEffects.AddRange(touchEffects);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            Character.Draw(target, states);
        }
        public override void HandleInput()
        {
            Character.HandleInput();
        }
        public override void RegisterEventHandlers(RenderWindow target)
        {

        }
        public override void Update(float deltaTime)
        {
            Character.Update(deltaTime);
        }
        public override void OnCollide(Entity entity)
        {
            Character.OnCollide(entity);
        }

        protected override void DoTouch(Entity entity)
        {
            if (entity.GetType().Name.Equals("Fish"))
            {
                foreach (Effect e in touchEffects)
                {
                    entity.Character.ApplyEffect(e);
                }
                IsAlive = false;
            }
        }

        protected override void DoDetach(Entity entity)
        {
            
        }
        private List<Effect> touchEffects = new List<Effect>();
    }
}
