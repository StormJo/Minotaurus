using Microsoft.Xna.Framework;
using Minotaurus.Classes.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Movement
{
    internal class ChasingMovementController
    {
        private Vector2 _locationPlayer;
        public ChasingMovementController() { }
        public Vector2 updatePosition(Vector2 currentPosition, Hero hero)
        {
            _locationPlayer = hero.getLocation();

            Vector2 direction = Vector2.Normalize(_locationPlayer - currentPosition);

            currentPosition += direction;

            return currentPosition;
        }
    }
}
