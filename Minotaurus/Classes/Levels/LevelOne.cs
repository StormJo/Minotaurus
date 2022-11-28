using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Entities;
using Minotaurus.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Minotaurus.Classes.Levels
{
    internal class LevelOne : ILevel
    {
        private int[,] levelOneMap = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,2, 3, 1, 2, 3, 0, 0, 0, 0 },
            {0,0, 0, 0, 0, 0, 0, 1, 2, 3, 1, 1, 1, 1, 1, 1, 1, 2, 3, 1},
            {1, 2, 3, 1, 2, 3, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };

        private Texture2D _minotaurTexture, _LevelOneTile;
        private WorldManager _worldWorldManager;
        private List<IGameObject> gameObjects;
        public LevelOne() 
        {
            _worldWorldManager = new WorldManager(levelOneMap);
            gameObjects = new List<IGameObject>();
        }

        public List<IGameObject> GetGameObjects()
        {
            return gameObjects;
        }
        public void Initialize()
        {
            _worldWorldManager.CheckTiles(_LevelOneTile);
            gameObjects.Add(new Hero(_minotaurTexture));
            
        }

        public void LoadContent(ContentManager content)
        {
            _LevelOneTile = content.Load<Texture2D>("tileset");
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

        public void AddGameObject(IGameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
    }
}
