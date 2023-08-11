using Microsoft.Xna.Framework;
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

        private float gravity = 981f;
        private float maxSpeed = 175f;
        private float floorFriction = 600f;

        public void RunSpeed(float acceleration, int direction, float airMovement, GameTime gametime)
        {
            velocity.X += airMovement * direction * acceleration * (float)gametime.ElapsedGameTime.TotalSeconds; //Accel is versnelling
        }

        public void MaxRunSpeed()
        {
            velocity.X = Math.Clamp(velocity.X, -maxSpeed, maxSpeed);
        }
        public void Friction(GameTime gametime)
        {
            float velocityXSign = MathF.Sign(velocity.X);
            velocity.X -= MathF.Sign(velocity.X) * floorFriction * (float)gametime.ElapsedGameTime.TotalSeconds;

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
            velocity.Y += gravity * (float)gametime.ElapsedGameTime.TotalSeconds;
        }
        public Vector2 Update(Vector2 position, GameTime gametime)
        { 
            return position += velocity * (float)gametime.ElapsedGameTime.TotalSeconds;
        }
    }
}
