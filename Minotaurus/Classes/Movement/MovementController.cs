using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Minotaurus.Classes.Interfaces;

namespace Minotaurus.Classes.Movement
{
    public enum State { Idle, Walking, Jumping }
    public class MovementController
    {
        public State State { get; set; }
        public Vector2 NextFramePosition { get; set; }

        public bool isFloored { get; set; }
        public bool IsLeft { get; set; } = false;
        public bool IsRight { get; set; } = true;

        public void update(Physics _physics, GameTime gameTime)
        {
            if (!isFloored)
            {
                    if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        IsLeft = false;
                        IsRight = true;
                        _physics.RunSpeed(1100f, 1, 0.25f, gameTime);
                        State = State.Jumping;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Q) || Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        IsLeft = true;
                        IsRight = false;
                        _physics.RunSpeed(1100f, -1, 0.25f, gameTime);
                        State = State.Jumping;
                    }
            }
            else
            {
                _physics.Friction(gameTime);
                State = State.Idle;

                //JUMPING
                if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Up) && isFloored)
                {
                    _physics.ImpulseY(-400f);
                    isFloored = false;
                    State = State.Jumping;
                }
                //MOVING RIGHT
                if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    IsLeft = false;
                    IsRight = true;
                    State = State.Walking;
                    _physics.RunSpeed(1100f, 1, 1f,gameTime);
                }
                //MOVING LEFT
                if (Keyboard.GetState().IsKeyDown(Keys.Q) || Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    IsLeft = true;
                    IsRight = false;
                    State = State.Walking;
                    _physics.RunSpeed(1100f, -1,1f, gameTime);
                }

                _physics.MaxRunSpeed();
            }
        }
    }
}
