using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Animations;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Movement;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Minotaurus.Classes.Collision;

namespace Minotaurus.Classes.Entities
{
    public class Hero : IGameObject, ICollide
    {
        private Texture2D texture;
        public Rectangle currentFrame;

        public Vector2 position;
        public Rectangle HitBox { get; set; }

        public Physics _physics; 

        MovementController moveController;

        CollisionDetector collisionDetector;
        #region-Animations
        Animation idleAnimationRight;
        Animation idleAnimationLeft;
        Animation walkRightAnimation;
        Animation walkLeftAnimation;
        Animation AttackRotateRight;
        Animation jumpLeft;
        Animation jumpRight;

        int walkFPS = 14;
        int idleFPS = 7;
        int attackFPS = 15;
        int jumpFPS = 1;

       

        #endregion
        public Hero(Texture2D texture)
        {
            moveController = new MovementController();
            collisionDetector = new CollisionDetector(this);
            _physics = new Physics();
            this.texture = texture;
            #region-Animations
            idleAnimationRight = new Animation(idleFPS);
            idleAnimationLeft = new Animation(idleFPS);
            walkRightAnimation = new Animation(walkFPS);
            walkLeftAnimation = new Animation(walkFPS);
            AttackRotateRight = new Animation(attackFPS);
            jumpLeft = new Animation(jumpFPS);
            jumpRight = new Animation(jumpFPS);
            //IdleAnimationRight
            idleAnimationRight.AddFrame(new AnimationFrame(new Rectangle(0, 0, 53, 42)));
            idleAnimationRight.AddFrame(new AnimationFrame(new Rectangle(53, 0, 53, 42)));
            idleAnimationRight.AddFrame(new AnimationFrame(new Rectangle(106, 0, 53, 42)));
            idleAnimationRight.AddFrame(new AnimationFrame(new Rectangle(159, 0, 53, 42)));
            idleAnimationRight.AddFrame(new AnimationFrame(new Rectangle(212, 0, 53, 42)));
            //IdleAnimationLeft
            idleAnimationLeft.AddFrame(new AnimationFrame(new Rectangle(0, 126, 53, 42)));
            idleAnimationLeft.AddFrame(new AnimationFrame(new Rectangle(53, 126, 53, 42)));
            idleAnimationLeft.AddFrame(new AnimationFrame(new Rectangle(106, 126, 53, 42)));
            idleAnimationLeft.AddFrame(new AnimationFrame(new Rectangle(159, 126, 53, 42)));
            idleAnimationLeft.AddFrame(new AnimationFrame(new Rectangle(212, 126, 53, 42)));
            //walkRightAnimation
            walkRightAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 43, 53, 42)));
            walkRightAnimation.AddFrame(new AnimationFrame(new Rectangle(53, 43, 53, 42)));
            walkRightAnimation.AddFrame(new AnimationFrame(new Rectangle(106, 43, 53, 42)));
            walkRightAnimation.AddFrame(new AnimationFrame(new Rectangle(159, 43, 53, 42)));
            walkRightAnimation.AddFrame(new AnimationFrame(new Rectangle(212, 43, 53, 42)));
            walkRightAnimation.AddFrame(new AnimationFrame(new Rectangle(265, 43, 53, 42)));
            walkRightAnimation.AddFrame(new AnimationFrame(new Rectangle(318, 43, 53, 42)));
            walkRightAnimation.AddFrame(new AnimationFrame(new Rectangle(371, 43, 53, 42)));
            //walkLeftAnimation
            walkLeftAnimation.AddFrame(new AnimationFrame(new Rectangle(0, 84, 53, 42)));
            walkLeftAnimation.AddFrame(new AnimationFrame(new Rectangle(53, 84, 53, 42)));
            walkLeftAnimation.AddFrame(new AnimationFrame(new Rectangle(106, 84, 53, 42)));
            walkLeftAnimation.AddFrame(new AnimationFrame(new Rectangle(159, 84, 53, 42)));
            walkLeftAnimation.AddFrame(new AnimationFrame(new Rectangle(212, 84, 53, 42)));
            walkLeftAnimation.AddFrame(new AnimationFrame(new Rectangle(265, 84, 53, 42)));
            walkLeftAnimation.AddFrame(new AnimationFrame(new Rectangle(318, 84, 53, 42)));
            walkLeftAnimation.AddFrame(new AnimationFrame(new Rectangle(371, 84, 53, 42)));
            //AttackRotateRight
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(0, 168, 53, 42)));
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(53, 168, 54, 42)));
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(107, 168, 55, 42)));
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(162, 168, 68, 42)));
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(232, 168, 53, 42)));
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(281, 168, 74, 47)));
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(355, 168, 56, 47)));
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(411, 168, 47, 47)));
            AttackRotateRight.AddFrame(new AnimationFrame(new Rectangle(458, 168, 47, 47)));
            //jumpRight
            jumpRight.AddFrame(new AnimationFrame(new Rectangle(53, 43, 53, 42)));
            //jumpLeft
            jumpLeft.AddFrame(new AnimationFrame(new Rectangle(53, 84, 53, 42)));
            #endregion
        }
        public void Update(GameTime gameTime)
        {
            moveController.update(_physics, gameTime);
            Animation animation = null;

            if (moveController.State == State.Idle)
            {
                if (_physics.velocity.X > 0)
                {
                    moveController.IsRight = true;
                    animation = idleAnimationRight;
                }
                else if (_physics.velocity.X < 0)
                {
                    animation = idleAnimationLeft;
                    moveController.IsRight = false;
                }
                else
                {
                    if (moveController.IsRight)
                    {
                        animation = idleAnimationRight;
                    }
                    else
                    {
                        animation = idleAnimationLeft;
                    }
                }
            }

            if (moveController.State == State.Walking)
            {
                if (_physics.velocity.X > 0)
                {
                    animation = walkRightAnimation;
                }
                else
                {
                    animation = walkLeftAnimation;
                }
            }

            if (moveController.State == State.Jumping)
            {
                if (_physics.velocity.X > 0)
                {
                    animation = jumpRight;
                }
                else
                {
                    animation = jumpLeft;
                }
            }

            if (animation != null)
            {
                animation.FrameCheck(gameTime);
                currentFrame = animation.CurrentFrame.SourceRectangle;
            }

            _physics.ApplyGravity(gameTime);
            var newPosition = _physics.Update(position, gameTime);
            
            HitBox = new Rectangle((int)newPosition.X, (int)newPosition.Y, currentFrame.Width, currentFrame.Height);
            if (collisionDetector.Update())
            {
                if (moveController.IsRight && _physics.velocity.X > 0)
                {
                    _physics.velocity.X = 0;
                }
                if (moveController.IsLeft && _physics.velocity.X < 0)
                {
                    _physics.velocity.X = 0;
                }

                position = _physics.Update(position, gameTime);
            }
            else
            {
                position = newPosition;
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }


    }
}
