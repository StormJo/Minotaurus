using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Minotaurus.Classes.Entities.Static
{
    public class NoCollidingProp : Tile
    {
        public NoCollidingProp(int X, int Y, Texture2D texture, int sortProp) : base(X, Y, texture)
        {
            if(sortProp == 22)//Mushrooms
            {
                position = new Vector2((int)position.X, (int)position.Y + 6);
                currentFrame = new Rectangle(96,118,16, 10);
            }

        }
    }
}
