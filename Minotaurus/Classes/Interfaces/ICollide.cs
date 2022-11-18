using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Interfaces
{
    internal interface ICollide
    {
        public Rectangle HitBox { get; }
    }
}
