using Microsoft.Xna.Framework;
using Minotaurus.Classes.Entities;

namespace Minotaurus.Classes.Interfaces
{
    internal interface IEntity
    {
        public Rectangle HitBox { get; }
        public HealthManager healthManager { get; }
    }
}
