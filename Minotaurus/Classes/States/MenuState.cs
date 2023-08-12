using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Minotaurus.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.States
{
    internal class MenuState : IState
    {

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Game1.Arial, "MinoMaze", new Vector2(260, 150), Color.DarkBlue, 0, Vector2.Zero, 3f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Game1.Arial, "Press 1: Level 1", new Vector2(250, 370), Color.Black, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Game1.Arial, "Press 2: Level 2", new Vector2(250, 450), Color.Black, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.GetPressedKeys().Length > 0)
            {
                Game1.changeState(new GameState());
            }
        }
    }
}
