using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PoweredXNA.Backend;
using PoweredXNA.Entities;
using PoweredXNA.Display;

namespace PoweredXNA
{
    /// <summary>
    /// Classe Game mère
    /// C'est elle qui switch entre tous les éléments de la pile de jeu
    /// </summary>
    internal class Game : Microsoft.Xna.Framework.Game
    {
        internal Game()
        {
            Globals.GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = Options.ContentRootDirectory;
        }

        protected override void Initialize()
        {
            Globals.GraphicsDeviceManager.IsFullScreen = Options.Preset.Fullscreen;
            if (Options.Preset.ScreenResolution != null)
            {
                Globals.GraphicsDeviceManager.PreferredBackBufferWidth = Options.Preset.ScreenResolution.Width;
                Globals.GraphicsDeviceManager.PreferredBackBufferHeight = Options.Preset.ScreenResolution.Height;
            }
            Globals.GraphicsDeviceManager.ApplyChanges();
            this.Window.Title = Options.Preset.WindowTitle;
            this.Window.AllowUserResizing = Options.Preset.AllowScreenResizing;

            base.Initialize();

            Cursor.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);

            if (Options.Preset.LoadAllResourcesAtStart)
                Resources.Load(Content);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || GameState.CountInstances() == 0)
            {
                this.Exit();
                return;
            }

            Events.Update();

            GameState.UpdateLast(gameTime);

            this.IsMouseVisible = Cursor.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Globals.SpriteBatch.Begin();

            GameState.DrawAll(gameTime);
            Cursor.Draw(gameTime);
            BrightnessLevel.ApplyOnScreen(gameTime);

            Globals.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
