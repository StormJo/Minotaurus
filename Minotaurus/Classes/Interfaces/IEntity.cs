using Microsoft.Xna.Framework;


namespace Minotaurus.Classes.Interfaces
{
    internal interface IEntity
    {
        public Rectangle HitBox { get; }
        public int Health { get; set; }
    }
}
