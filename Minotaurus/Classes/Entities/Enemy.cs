using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Interfaces;
using System;
using System.Diagnostics;

namespace Minotaurus.Classes.Entities
{
    internal class Enemy : IGameObject, IDamageable
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(8 * 16, 8 * 16);
        private Rectangle spriteFrame = new Rectangle(0, 0, 48, 48);

        private int movementCounter = 0;
        private int movementDirection = 1;
        private int maxMovement = 120; // Hier kun je de bewegingslimiet aanpassen

        public Rectangle HitBox { get; set; }
        public DateTime LastTriggerTime { get; set; } = DateTime.MinValue;

        public Enemy(Texture2D texture)
        {
            this.texture = texture;
            this.HitBox = new Rectangle(8 * 16, 8 * 16, 48, 48);
        }

        public float Cooldown => 2;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, spriteFrame.Width, spriteFrame.Height), Color.White);
        }

        public void Update(GameTime gameTime)
        {
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
    }
}
