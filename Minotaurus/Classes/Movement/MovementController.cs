using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Minotaurus.Classes.Movement
{
    public enum State { Idle, Walking, Jumping }
    public class MovementController
    {
        public State State { get; set; }
        public Vector2 NextFramePosition { get; set; }

        public bool Grounded { get; set; }
        public bool IsLeft { get; set; } = false;
        public bool IsRight { get; set; } = true;

        public void update(Physics _physics, GameTime gameTime)
        {
            if (!Grounded)
            {
                if (_physics.velocity.Y == 0)
                {
                    Grounded = true;
                    _physics.velocity.Y = 0;
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        IsLeft = false;
                        IsRight = true;
                        _physics.RunSpeed(1100f, 1, 0.25f, gameTime);
                        State = State.Jumping;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    {
                        IsLeft = true;
                        IsRight = false;
                        _physics.RunSpeed(1100f, -1, 0.25f, gameTime);
                        State = State.Jumping;
                    }
                }
            }
            else
            {
                _physics.Friction(gameTime);
                State = State.Idle;

                //JUMPING
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    _physics.ImpulseY(-400f);
                    Grounded = false;
                    State = State.Jumping;
                }
                //MOVING RIGHT
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    IsLeft = false;
                    IsRight = true;
                    State = State.Walking;
                    _physics.RunSpeed(1100f, 1, 1f,gameTime);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Q))
                {
                    IsLeft = true;
                    IsRight = false;
                    State = State.Walking;
                    _physics.RunSpeed(1100f, -1,1f, gameTime);
                }

                _physics.MaxRunSpeed();
            }

            //NextFramePosition = position + _physics.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
