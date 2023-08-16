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
    public class FloatingIslandGrass: Tile, ICollide
    {
        public Rectangle HitBox { get; }
        public FloatingIslandGrass(int X, int Y, Texture2D texture, int grassType) : base(X, Y, texture)
        {
            if (grassType == 7) //Left side of island
            {
                currentFrame = new Rectangle(240, 224, 16, 16);
            }
            else if (grassType == 8) //Middle tile of the island
            {
                currentFrame = new Rectangle(272, 224, 16, 16);
            }
            else if (grassType == 9) //Right side of island
            {
                currentFrame = new Rectangle(304, 224, 16, 16);
            }

            HitBox = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width, currentFrame.Height);
        }
    }
}
