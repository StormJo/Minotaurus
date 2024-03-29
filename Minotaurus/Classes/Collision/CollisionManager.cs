﻿using Microsoft.Xna.Framework;
using Minotaurus.Classes.Entities.Characters;
using Minotaurus.Classes.Entities.Static;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Movement;
using Minotaurus.Classes.States;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Collision
{
    internal class CollisionManager
    {
        List<IGameObject> gameObjects;
        private IPlayer _self;
        Physics Physics;
        MovementController movementController;
        public CollisionManager(IPlayer self, Physics physics, MovementController movementController) 
        {
            this.Physics = physics;
            this.movementController = movementController;
            this._self = self;
        }

        public void CheckCollision(Rectangle hitBox, EDirection direction)
        {

            gameObjects = GameState.LoadedLevel.GetGameObjects();
            List<IGameObject> objectsToRemove = new List<IGameObject>();

            //Als we hier de vloer niet op null zetten, zal het karakter tijdens het vallen van een 'ledge' een extra jump krijgen.
            //Omdat ik dit een leuek feature vind heb ik het erin gelaten.

            //movementController.isFloored = false;

            foreach (var gameObject in gameObjects)
            {
                if (gameObject == null)
                    continue;

                if (gameObject == _self)
                    continue;

                if (gameObject is ICollide collide)
                {
                    if (hitBox.Intersects(collide.HitBox))
                    {
                        Physics.checkWalled(direction, movementController);
                        Physics.checkCeiling(direction, movementController); 
                    }
                }

                if(gameObject is IDealDamage damageAble)
                {
                    if(hitBox.Intersects(damageAble.HitBox))
                    {
                        damageAble.Action(_self);
                    }
                }

                if (gameObject is IPickUp pickup)
                {
                    if (hitBox.Intersects(pickup.HitBox))
                    {
                        pickup.Action(_self);
                        objectsToRemove.Add(gameObject);
                    }
                }
            }

            foreach (var objToRemove in objectsToRemove)
            {
                gameObjects.Remove(objToRemove);
            }
        }
    }
}
