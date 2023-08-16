using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Entities.Characters
{
    public class PointManager
    {
        private int points;

        public int Points
        {
            get { return points; }
        }

        public PointManager()
        {
            points = 0;
        }

        public void AddPoints(int amount)
        {
            if (amount > 0)
            {
                points += amount;
            }
        }

        public void SubtractPoints(int amount)
        {
            if (amount > 0)
            {
                points = Math.Max(0, points - amount);
            }
        }

        public void ResetPoints()
        {
            points = 0;
        }
    }

}
