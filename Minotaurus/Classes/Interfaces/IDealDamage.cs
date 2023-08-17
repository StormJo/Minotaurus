using Microsoft.Xna.Framework;
using System;

namespace Minotaurus.Classes.Interfaces
{
    internal interface IDealDamage
    {
        public Rectangle HitBox { get; }
        // This assumes that only 1 player may exist at one time
        void Action(IPlayer self) { }
    }
}
