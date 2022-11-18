using Microsoft.Xna.Framework;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Collision
{
    internal class CollisionDetector
    {
        List<IGameObject> gameObjects;
        private ICollide self;
        public CollisionDetector(ICollide self) 
        {
            gameObjects = World.LoadedLevel.GetGameObjects();
            this.self = self;
        }

        public bool Update()
        {
            foreach (var gameObject in gameObjects)
            {
                if (gameObject == null)
                    continue;

                if (gameObject == self)
                    continue;

                if (gameObject is ICollide collide)
                {
                    if (self.HitBox.Intersects(collide.HitBox))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
