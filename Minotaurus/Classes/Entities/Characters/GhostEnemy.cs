using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Animations;
using Minotaurus.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Entities.Characters
{
    internal class GhostEnemy : IGameObject, IDealDamage
    {
        private Hero hero;
        public Rectangle currentFrame;

        private Texture2D _texture;
        private Vector2 _position = new Vector2(500, 300); //StartingtPosition
        private Vector2 _locationPlayer;

        public Rectangle HitBox { get; set; }
        public DateTime LastTriggerTime { get; set; } = DateTime.MinValue;

        public float Cooldown => 2;
        Animation idleAnimation;

        public GhostEnemy(Hero hero, Texture2D texture)
        {
            this.hero = hero;
            _texture = texture;
            #region-Animations
            idleAnimation = new Animation(10);
            //IdleAnimationRight
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(28, 4, 102, 126)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(186, 23, 102, 126)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(344, 4, 102, 126)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(503, 24, 102, 126)));
            idleAnimation.AddFrame(new AnimationFrame(new Rectangle(660, 5, 102, 126)));
            #endregion
        }


        public void Update(GameTime gameTime)
        {
            //Animations

            idleAnimation.FrameCheck(gameTime);
            currentFrame = idleAnimation.CurrentFrame.SourceRectangle;

            //Movement

            _locationPlayer = hero.getLocation();

            Vector2 direction = Vector2.Normalize(_locationPlayer - _position);

            _position += direction;

            HitBox = new Rectangle((int)_position.X, (int)_position.Y, (int)(currentFrame.Width * .3f), (int)(currentFrame.Height * .3f));

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2((int)_position.X, (int)_position.Y), currentFrame, Color.White, 0f, Vector2.Zero, .3f, SpriteEffects.None, 0f);
        }
    }
}
