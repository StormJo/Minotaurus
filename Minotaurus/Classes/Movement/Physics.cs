﻿using Microsoft.Xna.Framework;
using Minotaurus.Classes.Entities.Characters;
using Minotaurus.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Movement
{
    public class Physics
    {
        public Vector2 velocity = new Vector2(0, -1);

        private float _gravity = 981f;
        private float _maxSpeed = 175f;
        private float _floorFriction = 600f;

        public void RunSpeed(float acceleration, int direction, float airMovement, GameTime gametime)
        {
            velocity.X += airMovement * direction * acceleration * (float)gametime.ElapsedGameTime.TotalSeconds; //Accel is versnelling
        }

        public void MaxRunSpeed()
        {
            velocity.X = Math.Clamp(velocity.X, -_maxSpeed, _maxSpeed);
        }
        public void Friction(GameTime gametime)
        {
            float velocityXSign = MathF.Sign(velocity.X);
            velocity.X -= MathF.Sign(velocity.X) * _floorFriction * (float)gametime.ElapsedGameTime.TotalSeconds;

            if (MathF.Abs(velocityXSign - MathF.Sign(velocity.X)) > 0f)
            {
                velocity.X = 0f;
            }
        }
        public void ImpulseY(float jumpForce)
        {
            velocity.Y = jumpForce;
        }
        public void ApplyGravity(GameTime gametime)
        {
            velocity.Y += _gravity * (float)gametime.ElapsedGameTime.TotalSeconds;
        }
        public void checkWalled(EDirection direction, MovementController movementController)
        {
            if (direction == EDirection.HORIZONTAL)
            {
                if (velocity.X != 0)
                    velocity.X = 0;
            }
        }
        public void checkCeiling(EDirection direction, MovementController movementController)
        {
           if( direction == EDirection.VERTICAL) 
            {
                if (velocity.Y > 0)
                {
                    movementController.isFloored = true;
                }
                if (velocity.Y != 0)
                    velocity.Y = 0;
            }
        }
        public Vector2 Update(Vector2 position, GameTime gametime)
        { 
            return position += velocity * (float)gametime.ElapsedGameTime.TotalSeconds;
        }
    }
}
