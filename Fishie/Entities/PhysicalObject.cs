using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    abstract public class PhysicalObject : Transformable
    {
        public float Radius { get; set; }
        public Vector2f Acceleration { get; set; }
        public Vector2f Velocity { get; set; }
        public Vector2f AccelerationAngular { get; set; }
        public Vector2f VelocityAngular { get; set; }
        public Vector2f Mass { get; set; }
        public Vector2f MassInverted { get; set; }
        public Vector2f Inertia { get; set; }
        public Vector2f InertiaInverted { get; set; }
    }
}
