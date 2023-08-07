using Microsoft.Xna.Framework;
using System;

namespace Minotaurus.Classes.Interfaces
{
    internal interface ITrigger
    {
        public Rectangle HitBox { get; }
        // This assumes that only 1 player may exist at one time
        public DateTime LastTriggerTime { get; set; }
        public float Cooldown { get; }
    }
}
