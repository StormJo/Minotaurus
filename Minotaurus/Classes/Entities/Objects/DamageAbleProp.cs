using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Interfaces;
using System;

namespace Minotaurus.Classes.Entities.Static
{
    internal class DamageAbleProp : Tile, IDealDamage
    {
        public Rectangle HitBox { get; }

        public int Damage { get; set; } = 1;

        public DamageAbleProp(int X, int Y, Texture2D texture, int sortProp) : base(X, Y, texture)
        {
            if (sortProp == 25)// Spikes
            {
                position = new Vector2((int)position.X, (int)position.Y + 7);
                currentFrame = new Rectangle(144, 199, 16, 9);
            }

            HitBox = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width, currentFrame.Height);
        }
        public void Action(IPlayer self)
        {
            self.healthManager.InflictDamage(Damage);
        }
    }
}
