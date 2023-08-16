﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Minotaurus.Classes.Interfaces;
using System;

namespace Minotaurus.Classes.Entities.Static
{
    internal class DamgeAbleProp : Tile, IDealDamage
    {
        public Rectangle HitBox { get; }

        public DamgeAbleProp(int X, int Y, Texture2D texture, int sortProp) : base(X, Y, texture)
        {
            if (sortProp == 23)// Spikes
            {
                position = new Vector2((int)position.X, (int)position.Y + 7);
                currentFrame = new Rectangle(144, 199, 16, 9);
            }

            HitBox = new Rectangle((int)position.X, (int)position.Y, currentFrame.Width, currentFrame.Height);
        }
    }
}
