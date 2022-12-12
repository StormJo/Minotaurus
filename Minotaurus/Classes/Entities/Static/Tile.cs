using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Interfaces;
using System;

namespace Minotaurus.Classes.Entities.Static
{
    public class Tile : IGameObject
    {
        private Texture2D texture;

        public Vector2 position;
        public Rectangle currentFrame;

        public Tile(int X, int Y, Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(X, Y);
        }
        public void Update(GameTime gameTime)
        {
            //empty
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
        }


    }
}
