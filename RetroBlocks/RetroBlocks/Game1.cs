using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OpenTK.Graphics.OpenGL;
using RetroBlocks.Scenes;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace RetroBlocks
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Title fonts
        private String _titleText;
        private SpriteFont _titleFont;

        //Title text
        private String _subtitleText;
        private SpriteFont _subTitleFont;

        //Message text
        private String _messageText;
        private SpriteFont _messageTextFont;

        // Scenes
        private Scene2D activeScene; //keep track of which scene is active
        private StartScene startScene;
        private GameScene _gameScene;
        private CreditScene _creditScene;

        //Menu
        private SpriteFont _menuFont;
        private SoundEffect _selectEffect;

        float currentTime = 0f;
        float duration = 4f; // 4 seconds


        //Backgrounds
        private Texture2D _backgroundTexture;

        //Misc
        private bool firstStart = true;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";

            // Title screen
            _titleText = "R E T R O  B L O C K S";
            _subtitleText = "B Y  J O H A N   S I L K E N S";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            // TODO: use this.Content to load your game content here
            _titleFont = Content.Load<SpriteFont>("VT-323_50");
            _subTitleFont = Content.Load<SpriteFont>("VT-323_36");
            _menuFont = Content.Load<SpriteFont>("VT-323_36");
            _selectEffect = Content.Load<SoundEffect>("select");
            _backgroundTexture = Content.Load<Texture2D>("background");

            // Main menu scene
            startScene = new StartScene(this,_menuFont,_backgroundTexture, _selectEffect);
            Components.Add(startScene);

            //Credit scene 
            _creditScene = new CreditScene(this,_menuFont,_backgroundTexture);
            Components.Add(_creditScene);




        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
//                Exit();

            // TODO: Add your update logic here
            TitleScreenTimer(gameTime);
            HandleInput(gameTime);

            base.Update(gameTime);
        }

        private void HandleInput(GameTime gameTime)
        {
            if (_creditScene.EscEntered)
            {
                _creditScene.Hide();
                //activeScene = null;
                LoadStartScene(gameTime);
            }
            if ( startScene.SelectedMenuIndex == 2)
            {
                startScene.SelectedMenuIndex = -1;
                LoadCreditScene(gameTime);
            }

            if (startScene.SelectedMenuIndex == 1)
            {
                LoadSinglePlayerScene(gameTime);
            }
        }

        private void LoadSinglePlayerScene(GameTime gameTime)
        {
            //todo create SinglePlayerGameScene

        }

        private void TitleScreenTimer(GameTime gameTime)
        {
            
            currentTime += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= duration && firstStart)
            {
                firstStart = false;
               //load startscene
                LoadStartScene(gameTime);
               
            }
            
           


        }

        private void LoadStartScene(GameTime gameTime)
        {
            startScene.SelectedMenuIndex = -1;
            startScene.Show();
            activeScene = startScene;
            
        }

        private void LoadCreditScene(GameTime gameTime)
        {
            activeScene?.Hide();
            activeScene = _creditScene;
            _creditScene.Show();
            if (_creditScene.EscEntered)
            {
                _creditScene.Hide();
                //activeScene = null;
                LoadStartScene(gameTime);
            }

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

//            //Draw title screen 
            Vector2 textSize = _titleFont.MeasureString(_titleText);
            Vector2 subtextSize = _titleFont.MeasureString(_subtitleText);

            spriteBatch.DrawString(_titleFont,_titleText,new Vector2((GraphicsDevice.Viewport.Width/2) - textSize.X + 320, GraphicsDevice.Viewport.Height / 2 - textSize.Y), Color.White );
            spriteBatch.DrawString(_subTitleFont, _subtitleText, new Vector2(GraphicsDevice.Viewport.Width/2 - subtextSize.X + 560 , GraphicsDevice.Viewport.Height/2 - textSize.Y + 125) , Color.White);
          
            
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
