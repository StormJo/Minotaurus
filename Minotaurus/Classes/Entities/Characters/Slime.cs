using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Animations;
using Minotaurus.Classes.Interfaces;
using System;
using System.Diagnostics;

namespace Minotaurus.Classes.Entities.Characters
{
    internal class Slime : IGameObject, IDealDamage
    {
        private Texture2D texture;
        public Rectangle currentFrame;
        private Vector2 position = new Vector2(28 * 16, 34 * 16);
        private Rectangle spriteFrame = new Rectangle(0, 0, 48, 48);

        private int movementCounter = 0;
        private int movementDirection = 1;
        private int maxMovement = 120; // Hier kun je de bewegingslimiet aanpassen

        public Rectangle HitBox { get; set; }
        public DateTime LastTriggerTime { get; set; } = DateTime.MinValue;

        public float Cooldown => 2;
        Animation idleAnimation;
        public Slime(Texture2D texture)
        {
            this.texture = texture;
            HitBox = new Rectangle(8 * 16, 8 * 16, 48, 48);

            #region-Animations
            idleAnimation = new Animation(10);
            //IdleAnimationRight
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(23, 177, 21, 16)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(101, 180, 25, 12)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(186, 154, 15, 38)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(265, 148, 17, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(343, 148, 21, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(422, 147, 23, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(503, 149, 21, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(585, 148, 17, 45)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(666, 155, 15, 38)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(741, 181, 25, 13)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(824, 177, 21, 17)));
            #endregion
        }

        public void Update(GameTime gameTime)
        {

            //Animations

            idleAnimation.FrameCheck(gameTime);
            currentFrame = idleAnimation.CurrentFrame.SourceRectangle;

            movementCounter += movementDirection;
            position.X += movementDirection;

            Debug.WriteLine(movementCounter);

            if (movementCounter == 0)
            {
                movementDirection = 1;
            }
            else if (movementCounter == maxMovement)
            {
                movementDirection = -1;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2((int)position.X, (int)position.Y), currentFrame, Color.White);
        }
    }
}
