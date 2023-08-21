using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Animations;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Movement;
using System;
using System.Diagnostics;

namespace Minotaurus.Classes.Entities.Characters
{
    internal class Slime : IGameObject, IDealDamage
    {
        private Texture2D texture;
        public Rectangle currentFrame;
        private Vector2 _position; //Starting Position
        public Rectangle HitBox { get; set; }
        public int Damage { get; } = 1;

        public PatrollingMovementController patrollingMovementController;

        Animation idleAnimation;
        public Slime(Texture2D texture, Vector2 startPosition)
        {
            this.texture = texture;
            _position = startPosition;
            patrollingMovementController = new PatrollingMovementController(100);
            #region-Animations
            idleAnimation = new Animation(10);
            //IdleAnimationRight
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(23, 177, 21, 16)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(101, 180, 25, 12)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(186, 154, 22, 38)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(265, 148, 17, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(343, 148, 21, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(422, 147, 23, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(503, 149, 21, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(585, 148, 17, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(666, 155, 22, 38)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(741, 5, 25, 13)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(824, 177, 21, 17)));
            #endregion
        }

        public void Update(GameTime gameTime)
        {
            //Animation
            idleAnimation.FrameCheck(gameTime);
            currentFrame = idleAnimation.CurrentFrame.SourceRectangle;
            HitBox = new Rectangle((int)_position.X, (int)_position.Y, (int)(currentFrame.Width * .3f), (int)(currentFrame.Height * .3f));
            
            //Logica
            _position = patrollingMovementController.updatePosition(_position);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2((int)_position.X, (int)_position.Y), currentFrame, Color.White);
        }
        public void Action(IPlayer self)
        {
            self.healthManager.InflictDamage(Damage);
        }
    }
}
