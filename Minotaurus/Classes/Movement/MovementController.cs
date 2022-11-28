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

        public IGameObject Floor { get; set; }
        public bool IsLeft { get; set; } = false;
        public bool IsRight { get; set; } = true;

        public void update(Physics _physics, GameTime gameTime)
        {
            if (Floor == null)
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
            else
            {
                _physics.Friction(gameTime);
                State = State.Idle;

                //JUMPING
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && Floor != null)
                {
                    _physics.ImpulseY(-400f);
                    Floor = null;
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
