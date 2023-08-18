using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Interfaces;

namespace Minotaurus.Classes.Entities.Static
{
    internal class TransitionGroundTile: Tile, ICollide
    {
        public Rectangle HitBox { get; }
        public TransitionGroundTile(int X, int Y, Texture2D texture, int groundType) : base(X, Y, texture)
        {
            if (groundType == 10) //Left side stone, right is ground
            {
                currentFrame = new Rectangle(16, 48, 16, 16);
            }
            else if (groundType == 11) //Right upper corner is stone
            {
                currentFrame = new Rectangle(320, 32, 16, 16);
            }
            else if (groundType == 12) //Right side stone, left is ground
            {
                currentFrame = new Rectangle(80,48, 16, 16);
            }
            else if (groundType == 13) //Bottom is Stone
            {
                currentFrame = new Rectangle(48, 80, 16, 16);
            }

            HitBox = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width, currentFrame.Height);
        }
    }
}
