using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Minotaurus.Classes.Interfaces;


namespace Minotaurus.Classes.States
{
    internal class VictoryState: IState
    {
        private float _elapsedTime = 0f;
        private const float _TimeToChangeState = 3f;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MinoMaze.Textures["Victory"], new Vector2(175, 105), new Rectangle(0, 0, 430, 430), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_elapsedTime >= _TimeToChangeState)
            {
                MinoMaze.ChangeState(new MenuState());
            }
        }
    }
}
