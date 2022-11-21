using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Entities;
using Minotaurus.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Levels
{
    internal class LevelOne: ILevel
    {
        private Texture2D _minotaurTexture;

        private List<IGameObject> gameObjects;
        public LevelOne() 
        {
            gameObjects = new List<IGameObject>();
        }

        public List<IGameObject> GetGameObjects()
        {
            return gameObjects;
        }
        public void Initialize()
        {
            gameObjects.Add(new DebugRectangle(new Rectangle(0, 200, 1000, 300)));
            gameObjects.Add(new DebugRectangle(new Rectangle(250, 150, 50, 50)));
            gameObjects.Add(new DebugRectangle(new Rectangle(300, 100, 50, 100)));
            gameObjects.Add(new DebugRectangle(new Rectangle(430, 70, 50, 50)));
            gameObjects.Add(new DebugRectangle(new Rectangle(560, 150, 50, 50)));
            gameObjects.Add(new Hero(_minotaurTexture));
            
        }

        public void LoadContent(ContentManager content)
        {
            _minotaurTexture = content.Load<Texture2D>("spritesheetMinotaur");
        }

        public void Update(GameTime gameTime)
        {
            foreach (var gameObject in gameObjects) 
            {
                gameObject.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }
    }
}
