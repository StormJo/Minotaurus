using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Entities.Characters
{
    public class PointManager
    {
        private int _points;
        private int _pointsToWin;
        public bool hasWon = false;
        public int Points
        {
            get { return _points; }
        }

        public PointManager(int pointsToWin)
        {
            _points = 0;
            this._pointsToWin = pointsToWin;
        }

        public void AddPoints(int amount)
        {
            if (amount > 0)
            {
                if(_points == _pointsToWin - 1)
                {
                    MinoMaze.SoundEffects["Victory"].Play();
                    hasWon = true;
                }
                else
                {
                    MinoMaze.SoundEffects["PickUpCoin"].Play();
                    _points += amount;
                }
                
            }
        }

        public void SubtractPoints(int amount)
        {
            if (amount > 0)
            {
                _points = Math.Max(0, _points - amount);
            }
        }

        public void ResetPoints()
        {
            _points = 0;
        }
    }

}
