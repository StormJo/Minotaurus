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
            if (sortProp == 22)//Grass
            {
                position = new Vector2((int)position.X, (int)position.Y - 6);
                currentFrame = new Rectangle(16, 112, 16, 16);
            }
            if (sortProp == 23)//Other Type of Grass
            {
                position = new Vector2((int)position.X, (int)position.Y);
                currentFrame = new Rectangle(48, 112, 16, 16);
            }
            if (sortProp == 24)// Cave backgroundStone
            {
                position = new Vector2((int)position.X, (int)position.Y);
                currentFrame = new Rectangle(304, 288, 16, 16);
            }

        }
    }
}
