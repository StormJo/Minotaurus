﻿using Microsoft.Xna.Framework;
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
            spriteBatch.DrawString(MinoMaze.Arial, "MinoMaze", new Vector2(260, 150), Color.DarkBlue, 0, Vector2.Zero, 3f, SpriteEffects.None, 0);
            spriteBatch.DrawString(MinoMaze.Arial, "Press 1: Level 1", new Vector2(250, 370), Color.Black, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.DrawString(MinoMaze.Arial, "Press 2: Level 2", new Vector2(250, 450), Color.Black, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.DrawString(MinoMaze.Arial, "Press esc to exit", new Vector2(250, 530), Color.Red, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                MinoMaze.ChangeState(new GameState(1));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad2))
            {
                MinoMaze.ChangeState(new GameState(2));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                MinoMaze.Quit();
            }
        }
    }
}
