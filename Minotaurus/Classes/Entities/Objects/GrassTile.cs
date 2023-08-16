using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Minotaurus.Classes.Interfaces;

namespace Minotaurus.Classes.Entities.Static
{
    public class GrassTile : Tile, ICollide
    {
        public Rectangle HitBox { get; }
        public GrassTile(int X, int Y, Texture2D texture, int grassType) : base(X, Y, texture)
        {
            if (grassType == 1) //First type in spritesheet
            {
                currentFrame = new Rectangle(16, 16, 16, 16);
            }
            else if (grassType == 2) //Second type in sprite
            {
                currentFrame = new Rectangle(48, 16, 16, 16);
            }
            else if (grassType == 3) //Third type in sprite
            {
                currentFrame = new Rectangle(80, 16, 16, 16);
            }

            HitBox = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width, currentFrame.Height);
        }
    }
}
