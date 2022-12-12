﻿using Microsoft.Xna.Framework;
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
        private IEntity self;
        Physics Physics = new Physics();
        MovementController movementController = new MovementController();
        public CollisionDetector(IEntity self, Physics physics, MovementController movementController) 
        {
            gameObjects = World.LoadedLevel.GetGameObjects();

            this.Physics = physics;
            this.movementController = movementController;

            this.self = self;
        }

        public bool CheckCollision(Rectangle hitBox, int direction)
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
                        if (direction == 1)
                        {
                            if (Physics.velocity.X != 0)
                                Physics.velocity.X = 0;
                        }
                        else
                        {
                            if(Physics.velocity.Y > 0)
                            {
                                movementController.Floor = gameObject;
                            }
                            if (Physics.velocity.Y != 0)
                                Physics.velocity.Y = 0;
                        }
                    }
                }

                if(gameObject is ITrigger trigger)
                {
                    if(hitBox.Intersects(trigger.HitBox))
                    {
                        self.Health -= 50;
                    }
                }
            }
            return false;
        }
    }
}
