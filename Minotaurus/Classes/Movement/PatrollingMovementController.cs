using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Movement
{
    internal class PatrollingMovementController
    {
        private int _movementCounter = 0;
        private int _movementDirection = 1;
        private int _maxMovement = 120;
        public PatrollingMovementController(int patrollingDistance) { }
        public Vector2 updatePosition(Vector2 currentPosition)
        {
            _movementCounter += _movementDirection;
            currentPosition.X += _movementDirection;

            Debug.WriteLine(_movementCounter);

            if (_movementCounter == 0)
            {
                _movementDirection = 1;
            }
            else if (_movementCounter == _maxMovement)
            {
                _movementDirection = -1;
            }

            return currentPosition;
        }
    }
}
