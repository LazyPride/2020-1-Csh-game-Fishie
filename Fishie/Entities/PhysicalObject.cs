using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Entities
{
    abstract public class PhysicalObject : Transformable
    {
        public Vector2f Acceleration { get; set; }
        public Vector2f Velocity { get; set; }
        public Vector2f AccelerationAngular { get; set; }
        public Vector2f VelocityAngular { get; set; }
        public float Mass { get; set; }
        public float MassInverted { get; set; }
        public float Inertia { get; set; }
        public float InertiaInverted { get; set; }
    }
}
