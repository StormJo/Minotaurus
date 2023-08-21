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
    public class EnvirnmontProp : Tile, ICollide
    {
        public Rectangle HitBox { get; }
        public EnvirnmontProp(int X, int Y, Texture2D texture, int sortProp) : base(X, Y, texture)
        {
            if (sortProp == 14) //Little BOX
            {
                currentFrame = new Rectangle(80, 192, 16, 16);
            }
            if(sortProp == 15) //Left side rock
            {
                currentFrame = new Rectangle(16,112,16, 16);
            }
            if(sortProp == 16) //right side of rock
            {
                currentFrame = new Rectangle(32,112,10,16);
            }
            if(sortProp== 17) //Little 'G' Block
            {
                currentFrame = new Rectangle(16, 320, 16, 16);
            }
            if(sortProp == 18) // Big 'G' Block Left up
            {
                currentFrame = new Rectangle(48,320, 16,16);
            }
            if (sortProp == 19) // Big 'G' Block Right up
            {
                currentFrame = new Rectangle(64, 320, 16, 16);
            }
            if (sortProp == 20) // Big 'G' Block Right Down
            {
                currentFrame = new Rectangle(64, 336, 16, 16);
            }
            if (sortProp == 21) // Big 'G' Block Left Down
            {
                currentFrame = new Rectangle(48, 336, 16, 16);
            }

            HitBox = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width, currentFrame.Height); 
        }
    }
}
