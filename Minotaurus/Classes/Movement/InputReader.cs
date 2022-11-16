using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Minotaurus.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Movement
{
    public class InputReader
    {
        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            var direction = Vector2.Zero;

            if (state.IsKeyDown(Keys.Q))
            {
                direction.X = -1;
            }
            if (state.IsKeyDown(Keys.D))
            {
                direction.X = 1;
            }
            if(state.IsKeyDown(Keys.Space))
            {
                direction.Y = -1;
            }
        }
    }
}
