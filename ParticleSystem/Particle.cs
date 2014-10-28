using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ParticleSystem
{
    public class Particle
    {
        Vector2 _position;
        Vector2 _velocity;
        Vector2 _acceleration;

        float _rotation;
        float _rotationSpeed;

        float _lifeTime;
        float _timeSinceStart;

        float _scale;

        public bool IsAlive
        {
            get { return _timeSinceStart < _lifeTime; }
        }

        public Particle(Vector2 position, Vector2 velocity, Vector2 acceleration, float lifeTime, float scale, float rotationSpeed)
        {
            _position = position;
            _velocity = velocity;
            _acceleration = acceleration;
            _lifeTime = lifeTime;
            _scale = scale;
            _rotationSpeed = rotationSpeed;
            _timeSinceStart = 0;
            _rotation = 0;
        }

        public void Update(float dt)
        {
            _velocity += _acceleration * dt;
            _position += _velocity * dt;
            _rotation += _rotationSpeed * dt;
            _timeSinceStart += dt;
        }
    }
}
