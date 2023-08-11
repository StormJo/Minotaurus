using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.States
{
    internal class GameOverState : IState
    {
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.Textures["icons8-delete-48"], new Rectangle(200 + 200, 10, 90, 90), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            // Implementeer hier logica voor het afhandelen van invoer of andere updates voor het gameover-scherm
        }
    }

}
