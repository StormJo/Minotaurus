using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Entities.Static;

namespace Minotaurus.Classes.Levels
{
    public class WorldManager
    {
        private int[,] Map;
        private int tileSize = 16;
        public WorldManager(int[,] map) 
        {
            this.Map = map;
        }
        public void CheckTiles( Texture2D texture)
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] > 0 && Map[i,j] <= 3)
                    {
                        World.LoadedLevel.AddGameObject(new GrassTile(j * tileSize, i * tileSize, texture, Map[i,j]));
                    }
                    if (Map[i, j] > 3 && Map[i, j] <= 6)
                    {
                        World.LoadedLevel.AddGameObject(new GroundTile(j * tileSize, i * tileSize, texture, Map[i, j]));
                    }
                    if (Map[i, j] > 6 && Map[i, j] <= 9)
                    {
                        World.LoadedLevel.AddGameObject(new FloatingIslandGrass(j * tileSize, i * tileSize, texture, Map[i, j]));
                    }
                    if (Map[i, j] > 9 && Map[i, j] <= 13)
                    {
                        World.LoadedLevel.AddGameObject(new TransitionGroundTile(j * tileSize, i * tileSize, texture, Map[i, j]));
                    }
                    if (Map[i, j] >= 14 && Map[i,j] <= 21)
                    {
                        World.LoadedLevel.AddGameObject(new CollidingProp(j * tileSize, i * tileSize, texture, Map[i,j]));
                    }
                    if (Map[i,j] >= 22 && Map[i,j] <= 22)
                    {
                        World.LoadedLevel.AddGameObject(new NoCollidingProp(j * tileSize, i * tileSize, texture, Map[i, j]));
                    }
                    if (Map[i, j] >= 23 && Map[i, j] <= 23)
                    {
                        World.LoadedLevel.AddGameObject(new Triggers(j * tileSize, i * tileSize, texture, Map[i, j]));
                    }
                }
            }

            
        }
    }
}
