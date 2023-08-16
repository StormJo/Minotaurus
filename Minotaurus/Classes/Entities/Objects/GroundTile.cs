using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Entities.Static
{
    public class GroundTile : Tile
    {
        public GroundTile(int X, int Y, Texture2D texture, int groundType) : base(X, Y, texture)
        {
            if (groundType == 4) //Purple groundTile (1 color)
            {
                currentFrame = new Rectangle(48, 48, 16, 16);
            }
            else if (groundType == 5) //groundTile with 1 stone in the middle
            {
                currentFrame = new Rectangle(80,112, 16, 16);
            }
            else if (groundType == 6) // groundTile with more stones in the middle
            {
                currentFrame = new Rectangle(112, 112, 16, 16);
            }
        }
    }
}
