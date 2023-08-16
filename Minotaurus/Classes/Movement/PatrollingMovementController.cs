using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Movement
{
    internal class PatrollingMovementController
    {
        private int movementCounter = 0;
        private int movementDirection = 1;
        private int maxMovement = 120;
        public PatrollingMovementController(int patrollingDistance) { }
        public Vector2 updatePosition(Vector2 currentPosition)
        {
            movementCounter += movementDirection;
            currentPosition.X += movementDirection;

            Debug.WriteLine(movementCounter);

            if (movementCounter == 0)
            {
                movementDirection = 1;
            }
            else if (movementCounter == maxMovement)
            {
                movementDirection = -1;
            }

            return currentPosition;
        }
    }
}
