using Microsoft.Xna.Framework;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Levels;
using Minotaurus.Classes.Movement;
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
        Physics Physics = new Physics();
        MovementController movementController = new MovementController();
        public CollisionDetector(ICollide self, Physics physics, MovementController movementController) 
        {
            gameObjects = World.LoadedLevel.GetGameObjects();

            this.Physics = physics;
            this.movementController = movementController;

            this.self = self;
        }

        public bool CheckCollision(Rectangle hitBox, int checkNumber)
        {
            foreach (var gameObject in gameObjects)
            {
                if (gameObject == null)
                    continue;

                if (gameObject == self)
                    continue;

                if (gameObject is ICollide collide)
                {
                    if (hitBox.Intersects(collide.HitBox))
                    {
                        if (checkNumber == 0)
                        {
                            if (Physics.velocity.X != 0)
                                Physics.velocity.X = 0;
                        }
                        else
                        {
                            if (Physics.velocity.Y != 0)
                                Physics.velocity.Y = 0;
                        }
                    }
                }
            }
            return false;
        }
    }
}
