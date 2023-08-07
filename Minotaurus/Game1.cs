﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Minotaurus.Classes.Entities;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Levels;
using System.ComponentModel;

namespace Minotaurus
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _background;

        private static RenderTarget2D _renderTarget;
        private const int _screenHeight = 1440;
        private const int _screenWidth = 1920;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            World.LoadedLevel = new LevelOne();
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            World.LoadedLevel.Initialize();
            PresentationParameters pp = _graphics.GraphicsDevice.PresentationParameters;
            _renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, 800, 608, false, SurfaceFormat.Color, DepthFormat.None, pp.MultiSampleCount, RenderTargetUsage.DiscardContents);
        }

        protected override void LoadContent()
        {
            World.LoadedLevel.LoadContent(Content);
            _background = Content.Load<Texture2D>("back");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            World.LoadedLevel.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            _graphics.GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.White);
            Window.AllowUserResizing = true;

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, null, null, null, null);
            _spriteBatch.Draw(_background, new Vector2(0, 0), new Rectangle(0, 0, 384, 240), Color.White, 0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0f);
            World.LoadedLevel.Draw(_spriteBatch);
            _spriteBatch.End();

            _graphics.GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            _spriteBatch.Draw(_renderTarget, createMargins() , Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private Rectangle createMargins()
        {

            float outputAspect = Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
            float preferredAspect = _screenWidth / (float)_screenHeight;

            Rectangle dst;

            if (outputAspect <= preferredAspect)
            {
                // output is taller than it is wider, bars on top/bottom
                int presentHeight = (int)((Window.ClientBounds.Width / preferredAspect) + 0.5f);
                int barHeight = (Window.ClientBounds.Height - presentHeight) / 2;

                return dst = new Rectangle(0, barHeight, Window.ClientBounds.Width, presentHeight);
            }
            else
            {
                int presentWidth = (int)((Window.ClientBounds.Height * preferredAspect) + 0.5f);
                int barWidth = (Window.ClientBounds.Width - presentWidth) / 2;

                return dst = new Rectangle(barWidth, 0, presentWidth, Window.ClientBounds.Height);
            }
        }
    }
}