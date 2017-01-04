using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OpenTK.Graphics.OpenGL;
using RetroBlocks.Drawables;
using RetroBlocks.Factories;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace RetroBlocks.Scenes
{
    class StartScene : Scene2D
    {

        TextMenu menu;
        private MenuFactory menuFactory;
        Texture2D _backgroundTexture;
        private int _selectedMenuIndex = -1;
        SoundEffect startSceneEffect;

        private GameScene _gameScene;
        private CreditScene _creditScene;


        public StartScene(Game game, SpriteFont menuFont , Texture2D backgroundTexture2D , SoundEffect selectEffect) : base(game)
        {
            StartSceneEffect = startSceneEffect;
            menuFactory = new MenuFactory();
            menu = menuFactory.CreateMenu("main menu", game, menuFont, selectEffect, new Vector2(game.GraphicsDevice.Viewport.Width/2-300,game.GraphicsDevice.Viewport.Height/2-300));
            components.Add(menu);

            _backgroundTexture = backgroundTexture2D;

            //Scenes
            _creditScene = new CreditScene(game,menuFont,backgroundTexture2D);
            components.Add(_creditScene);


        }

       

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            HandleScenesInput();
            base.Update(gameTime);
        }

        public int SelectedMenuIndex
        {
            get { return _selectedMenuIndex; }
            set { _selectedMenuIndex = value; }
        }

        private void HandleScenesInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            bool entered = (menu.OldKeyboardState.IsKeyDown(Keys.Enter) &&
                           (keyboardState.IsKeyUp(Keys.Enter)));
           // menu.OldKeyboardState = keyboardState;
            if (entered)
            {
                switch (menu.SelectedIndex)
                {
                    case 0:
                       // Open a single player game
                        SelectedMenuIndex = menu.SelectedIndex;
                        break;
                    case 1:
                        // Open multi player game
                        SelectedMenuIndex = menu.SelectedIndex;
                        break;
                    case 2:
                        // Open credits scene
                        SelectedMenuIndex = menu.SelectedIndex;
                        break;
                    case 3:  //quit game
                        Game.Exit();
                        break;
                }
            }

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
