using Microsoft.Xna.Framework;
using System;

namespace Minotaurus.Classes.Interfaces
{
    internal interface IDealDamage
    {
        public Rectangle HitBox { get; }
        public int Damage { get; }
        void Action(IPlayer self) { }
    }
}
