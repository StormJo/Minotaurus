using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Entities.Characters;
using Minotaurus.Classes.Movement;

namespace Minotaurus.Classes.Interfaces
{
    internal interface IPlayer : IGameObject
    {
        public Rectangle HitBox { get; }
        public HealthManager healthManager { get; }
        public PointManager pointManager { get; }

        public Physics physics { get; }

    }
}
