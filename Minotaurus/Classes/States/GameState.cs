using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.States
{
    public class GameState : IState
    {
        public static ILevel LoadedLevel { get; set; }

        public GameState(int level) 
        {
            LoadedLevel = new Level(level);
            
        }
        public void Update(GameTime gameTime)
        {
            LoadedLevel.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            LoadedLevel.Draw(spriteBatch);
        }

    }
}
