using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using RetroBlocks.Drawables;
using RetroBlocks.Factories;

namespace RetroBlocks.Scenes
{
    class StartScene : Scene2D
    {

        TextMenu menu;
        private MenuFactory menuFactory;
        Texture2D _backgroundTexture;

        SoundEffect startSceneEffect;

        public StartScene(Game game, SpriteFont menuFont , Texture2D backgroundTexture2D , SoundEffect selectEffect) : base(game)
        {
            StartSceneEffect = startSceneEffect;
            menuFactory = new MenuFactory();
            menu = menuFactory.CreateMenu("main menu", game, menuFont, selectEffect, new Vector2(game.GraphicsDevice.Viewport.Width/2-300,game.GraphicsDevice.Viewport.Height/2-300));
            components.Add(menu);

            _backgroundTexture = backgroundTexture2D;


        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sBatch.Draw(_backgroundTexture,
                new Rectangle(0, 0, screenBounds.Width, screenBounds.Height), Color.White);
            base.Draw(gameTime);
        }

        public SoundEffect StartSceneEffect
        {
            get { return startSceneEffect; }
            set { startSceneEffect = value; }
        }

        public override void Show()
        {
            //play some music

            base.Show();
        }
    }
}
