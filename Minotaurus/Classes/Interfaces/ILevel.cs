﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Interfaces
{
    internal interface ILevel
    {
        public void Initialize();
        public void LoadContent(ContentManager content);
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);

        public List<IGameObject> GetGameObjects();

    }
}