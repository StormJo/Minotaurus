using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Entities.Static;
using Minotaurus.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Levels
{
    public class WorldManager
    {

        private int tile;
        private int[,] Map;
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
                   if (Map[i, j] > 0 && Map[i, j] <= 3)
                    {
                        World.LoadedLevel.AddGameObject(new GrassTile(j * 32, i * 32 + 200, texture, Map[i,j]));
                    }
                }
            }

            
        }
    }
}
