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
        public ChasingMovementController() { }
        public Vector2 updatePosition(Vector2 currentPosition, Vector2 location)
        {

            Vector2 direction = Vector2.Normalize(location - currentPosition);

            currentPosition += direction;

            return currentPosition;
        }
    }
}
