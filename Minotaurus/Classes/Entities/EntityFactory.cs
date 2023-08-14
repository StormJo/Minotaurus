using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Entities
{
    internal class EntityFactory
    {
        private Texture2D heroTexture;
        private Texture2D enemyTexture;

        public EntityFactory(Texture2D heroTexture, Texture2D enemyTexture)
        {
            this.heroTexture = heroTexture;
            this.enemyTexture = enemyTexture;
        }

        //public Hero CreateHero()
        //{
            //return new Hero();
        //}

        public Enemy CreateEnemy()
        {
            return new Enemy(enemyTexture);
        }
    }
}
