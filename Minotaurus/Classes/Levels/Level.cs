using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Entities.Characters;
using Minotaurus.Classes.Entities.Static;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.States;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Minotaurus.Classes.Levels
{
    internal class Level : ILevel
    {
        private int _tileSize = 16;
        private int[,] _map;

        private Hero _heroMino;

        public static List<IGameObject> gameObjects;
        public static List<IPlayer> Entities;
        public Level(int level)
        {
            _map = LevelData.levelData[level - 1];

            //Initializing Lists
            gameObjects = new List<IGameObject>();
            Entities = new List<IPlayer>();

            //Adding Entities
            _heroMino = new Hero(new Vector2(0, 0));
            Entities.Add(_heroMino);

            //Loading Textures + Adding GameObjects
            gameObjects.Add(new Slime(MinoMaze.Textures["slime_jump"]));
            gameObjects.Add(new GhostEnemy(_heroMino, MinoMaze.Textures["GhostSprite"]));
            LoadLevel(MinoMaze.Textures["tileset"]);
            LoadLevel(MinoMaze.Textures["props"]);
            LoadLevel(MinoMaze.Textures["Coin"]);
            LoadLevel(MinoMaze.Textures["HeartIcon"]);

        }

        public List<IGameObject> GetGameObjects()
        {
            return gameObjects;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }
            foreach (var entity in Entities)
            {
                entity.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (_heroMino.healthManager.isDead)
            {
                MinoMaze.ChangeState(new GameOverState());
            }
            else if (_heroMino.pointManager.hasWon)
            {
                MinoMaze.ChangeState(new VictoryState());
            }
            else
            {
                //Drawing All gameObjects
                foreach (var gameObject in gameObjects)
                {
                    gameObject.Draw(spriteBatch);
                }
                //Drawing All Entities
                foreach (var entity in Entities)
                {
                    entity.Draw(spriteBatch);
                }
                //Drawing HP
                for (int i = 1; i < _heroMino.healthManager.CurrentHealth + 1; i++)
                {
                    spriteBatch.Draw(MinoMaze.Textures["HeartIcon"], new Vector2(10 + (i - 1) * 45, 10), new Rectangle(0, 0, 90, 90), Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
                }
                //Drawing Points
                spriteBatch.Draw(MinoMaze.Textures["Coin"], new Vector2(10, 50), new Rectangle(72, 72, 215, 215), Color.White, 0f, Vector2.Zero, .2f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(MinoMaze.Arial, _heroMino.pointManager.Points.ToString(), new Vector2(70, 50), Color.Black, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
            }
        }


        public void LoadLevel(Texture2D texture)
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (texture.Name == "tileset")
                    {
                        if (_map[i, j] > 0 && _map[i, j] <= 3)
                        {
                            gameObjects.Add(new GrassTile(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                        if (_map[i, j] > 3 && _map[i, j] <= 6)
                        {
                            gameObjects.Add(new GroundTile(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                        if (_map[i, j] > 6 && _map[i, j] <= 9)
                        {
                            gameObjects.Add(new FloatingIslandGrass(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                        if (_map[i, j] > 9 && _map[i, j] <= 13)
                        {
                            gameObjects.Add(new TransitionGroundTile(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                        if (_map[i, j] >= 14 && _map[i, j] <= 21)
                        {
                            gameObjects.Add(new EnvirnmontProp(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                    }
                    if (texture.Name == "props")
                    {
                        if (_map[i, j] >= 22 && _map[i, j] <= 22)
                        {
                            gameObjects.Add(new NoCollidingProp(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                        if (_map[i, j] >= 23 && _map[i, j] <= 23)
                        {
                            gameObjects.Add(new DamgeAbleProp(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                    }
                    if (texture.Name == "Coin")
                    {
                        if (_map[i, j] >= 24 && _map[i, j] <= 24)
                        {
                            gameObjects.Add(new Coin(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                    }
                    if (texture.Name == "HeartIcon")
                    {
                        if (_map[i, j] >= 25 && _map[i, j] <= 25)
                        {
                            gameObjects.Add(new Heart(j * _tileSize, i * _tileSize, texture, _map[i, j]));
                        }
                    }
                }
            }


        }
    }
}
