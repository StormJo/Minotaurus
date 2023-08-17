using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
    internal class GameOverState : IState
    {
        private float elapsedTime = 0f;
        private const float TimeToChangeState = 3f;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MinoMaze.Textures["GameOver"], new Vector2(215,200) , new Rectangle(80,128,351,207), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= TimeToChangeState)
            {
                MinoMaze.ChangeState(new MenuState());
            }
        }
    }

}
