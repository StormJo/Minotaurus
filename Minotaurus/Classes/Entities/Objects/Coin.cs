using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Entities.Static
{
    internal class Coin : Tile, IPickUp
    {
        public Rectangle HitBox { get; }

        public Coin(int X, int Y, Texture2D texture, int sortProp) : base(X, Y, texture)
        {
            if (sortProp == 26)// Coin
            {
                position = new Vector2((int)position.X, (int)position.Y + 7);
                currentFrame = new Rectangle(72, 72, 215, 215);
            }

            HitBox = new Rectangle((int)position.X, (int)position.Y, (int)(currentFrame.Width * .1f), (int)(currentFrame.Height * .1f));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0f, Vector2.Zero, .1f, SpriteEffects.None, 0f);
        }
        public void Action(IPlayer self)
        {
            self.pointManager.AddPoints(1);
        }
    }
}
