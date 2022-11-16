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
        public Vector2 velocity = new Vector2(0, -1f);
        private GameTime gametime;

        public float jumpForce = -400f;
        private float gravity = 981f;
        public float maxSpeed = 175f;
        private float floorFriction = 600f;

        public Physics() 
        {
           
        }

        public void runSpeed(float acceleration, int direction, float airMovement, GameTime gametime)
        {
            velocity.X += airMovement * direction * acceleration * (float)gametime.ElapsedGameTime.TotalSeconds; //Accel is versnelling
        }

        public void maxRunSpeed()
        {
            velocity.X = Math.Clamp(velocity.X, -maxSpeed, maxSpeed);
        }
        public void friction(GameTime gametime)
        {
            float velocityXSign = MathF.Sign(velocity.X);
            velocity.X -= MathF.Sign(velocity.X) * floorFriction * (float)gametime.ElapsedGameTime.TotalSeconds;

            if (MathF.Abs(velocityXSign - MathF.Sign(velocity.X)) > 0f)
            {
                velocity.X = 0f;
            }
        }

        public void setJumpForce(float jumpForce)
        {
            velocity.Y = jumpForce;
        }

        public float getVelocityY()
        {
            return velocity.Y;
        }
        public void setVelocityY(float velocityY)
        {
            this.velocity.Y = velocityY;
        }
        public float getVelocityX()
        {
            return velocity.X;
        }
        public void setVelocityX(float velocityX)
        {
            this.velocity.X = velocityX;
        }
        public Vector2 getVelocity()
        {
            return velocity;
        }

        public void update(GameTime gametime)
        {
            velocity.Y += gravity * (float)gametime.ElapsedGameTime.TotalSeconds;
        }
    }
}
