using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Movement
{
    public enum State { Idle, Walking, Jumping }
    public class MovementController
    {
        public State state { get; set; }
        public Vector2 nextFramePosition { get; set; }

        public bool grounded;
        public bool isLeft = false;
        public bool isRight = true;

        public Vector2 update(Vector2 position, Physics _physics, GameTime gameTime)
        {
            if (!grounded)
            {
                if (_physics.getVelocityY() == 0)
                {
                    grounded = true;
                    _physics.setVelocityY(0);
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        isLeft = false;
                        isRight = true;
                        _physics.runSpeed(1100f, 1, 0.25f, gameTime);
                        state = State.Jumping;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    {
                        isLeft = true;
                        isRight = false;
                        _physics.runSpeed(1100f, -1, 0.25f, gameTime);
                        state = State.Jumping;
                    }
                }
            }
            else
            {
                _physics.friction(gameTime);
                state = State.Idle;
                //JUMPING
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    _physics.setJumpForce(-400f);
                    grounded = false;
                    state = State.Jumping;
                }
                //MOVING RIGHT
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    isLeft = false;
                    isRight = true;
                    state = State.Walking;
                    _physics.runSpeed(1100f, 1, 1,gameTime);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Q))
                {
                    isLeft = true;
                    isRight = false;
                    state = State.Walking;
                    _physics.runSpeed(1100f, -1,1, gameTime);
                }

                _physics.maxRunSpeed();
            }

            position += _physics.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            nextFramePosition = position + _physics.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            return position;
        }
    }
}
