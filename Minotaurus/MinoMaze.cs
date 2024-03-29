﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Minotaurus.Classes.Entities;
using Minotaurus.Classes.Interfaces;
using Minotaurus.Classes.Levels;
using Minotaurus.Classes.Music;
using Minotaurus.Classes.States;
using System.Collections.Generic;
using System.ComponentModel;

namespace Minotaurus
{
    public class MinoMaze : Game
    {
        public static Dictionary<string, Texture2D> Textures;
        public static Dictionary<string, SoundEffect> SoundEffects;

        public static SpriteFont Arial;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private static IState _currentState;
        private static Game self;

        private static RenderTarget2D _renderTarget;
        private const int _screenHeight = 1440;
        private const int _screenWidth = 1920;

        public MinoMaze()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            self = this;
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            PresentationParameters pp = _graphics.GraphicsDevice.PresentationParameters;
            _renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, 800, 608, false, SurfaceFormat.Color, DepthFormat.None, pp.MultiSampleCount, RenderTargetUsage.DiscardContents);
            _currentState = new MenuState();
        }

        protected override void LoadContent()
        {
            Textures = new Dictionary<string, Texture2D>
            {
                { "back", Content.Load<Texture2D>("back") },
                { "tileset", Content.Load<Texture2D>("tileset") },
                { "props", Content.Load<Texture2D>("props") },
                { "spritesheetMinotaur", Content.Load<Texture2D>("spritesheetMinotaur") },
                { "HeartIcon", Content.Load<Texture2D>("HeartIcon") },
                { "GameOver", Content.Load<Texture2D>("GameOver") },
                { "Coin", Content.Load<Texture2D>("Coin") },
                { "GhostSprite", Content.Load<Texture2D>("GhostSprite") },
                { "Victory", Content.Load<Texture2D>("Victory") },
                { "slime_jump", Content.Load<Texture2D>("slime_jump") }
            };

            SoundEffects = new Dictionary<string, SoundEffect>
            {
                { "Dead", Content.Load<SoundEffect>("Dead") },
                { "PickUpCoin", Content.Load<SoundEffect>("PickUpCoin") },
                { "PickUpHP", Content.Load<SoundEffect>("PickUpHP") },
                { "Victory", Content.Load<SoundEffect>("VictorySound") },
                { "Damage", Content.Load<SoundEffect>("Damage") },
            };

            Arial = Content.Load<SpriteFont>("Arial16");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SongManager.Instance.Initialize(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            // TODO: Add your update logic here
            _currentState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            _graphics.GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.White);
            Window.AllowUserResizing = true;

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, null, null, null, null);
            _spriteBatch.Draw(Textures["back"], new Vector2(0, 0), new Rectangle(0, 0, 384, 240), Color.White, 0f, Vector2.Zero, 2.6f, SpriteEffects.None, 0f);
            _currentState.Draw(_spriteBatch);
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

        public static void ChangeState(IState nextState)
        {
            _currentState = nextState;
        }
        public static void Quit()
        {
            self.Exit();
        }
    }
}