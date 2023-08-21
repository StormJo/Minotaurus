using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Animations;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Movement;
using Microsoft.Xna.Framework;
using Minotaurus.Classes.Collision;

namespace Minotaurus.Classes.Entities.Characters
{
    public enum EDirection { VERTICAL, HORIZONTAL };
    public class Hero : IPlayer
    {
        private Texture2D texture = MinoMaze.Textures["spritesheetMinotaur"];
        public Rectangle currentFrame;
        public Vector2 position;
        private Color _spriteColor;


        public Rectangle HitBox { get; set; }
        public HealthManager healthManager { get; }
        public PointManager pointManager { get; }
        public Physics physics { get; }

        MovementController moveController;
        CollisionManager collisionDetector;
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
        int attackFPS = 22;
        int jumpFPS = 1;



        #endregion

        public Hero(Vector2 startPosition)
        {
            position = startPosition;
            _spriteColor = Color.White;

            physics = new Physics();
            moveController = new MovementController(physics);
            collisionDetector = new CollisionManager(this, physics, moveController);
            healthManager = new HealthManager(3);
            pointManager = new PointManager(3);
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
            moveController.update(gameTime);
            healthManager.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            #region-AnimationRegulator
            Animation animation = null;
            if (moveController.State == State.Idle)
            {
                if (physics.velocity.X > 0)
                {
                    moveController.IsRight = true;
                    animation = idleAnimationRight;
                }
                else if (physics.velocity.X < 0)
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
                if (physics.velocity.X > 0)
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
                if (moveController.IsRight)
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
            #endregion
            physics.ApplyGravity(gameTime);
            UpdateCollision(gameTime);

            position = physics.Update(position, gameTime);

            if(position.Y > 608)
                healthManager.isDead = true;

            HitBox = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width, currentFrame.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (healthManager.invurnerable)
            {
                if(_spriteColor == Color.Red) 
                { 
                    _spriteColor = Color.White;
                }
                else
                {
                    _spriteColor = Color.Red;
                }
            }

            spriteBatch.Draw(texture, position, currentFrame, _spriteColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        private void UpdateCollision(GameTime gameTime)
        {
            var newPosition = physics.Update(position, gameTime);

            collisionDetector.CheckCollision(new Rectangle((int)newPosition.X, (int)position.Y, currentFrame.Width, currentFrame.Height), EDirection.HORIZONTAL); //Check horizontal
            collisionDetector.CheckCollision(new Rectangle((int)position.X, (int)newPosition.Y, currentFrame.Width, currentFrame.Height), EDirection.VERTICAL); //Check vertical
        }

        public Vector2 getLocation()
        {
            return position;
        }
    }
}
