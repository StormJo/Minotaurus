using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minotaurus.Classes.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Minotaurus.Classes.Entities
{
    public class DebugRectangle : IGameObject, ICollide
    {
        private Rectangle rectangle;
        private Texture2D texture;

        public Rectangle HitBox { get; private set; }

        public DebugRectangle(Rectangle rect) 
        {
            rectangle = rect;
            HitBox = rect;
        }

        private void MakeTexture(SpriteBatch spriteBatch)
        {
            if (texture == null)
            {
                texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                texture.SetData(new Color[] { Color.White });
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            MakeTexture(spriteBatch);

            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            // empty
        }
    }
}
