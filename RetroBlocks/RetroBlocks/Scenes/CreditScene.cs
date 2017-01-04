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
    public class CreditScene : Scene2D
    {
        private Texture2D _backgroundTexture;
        private SpriteFont _textFont;
        private String creditText;
        private bool escEntered = false;
        public CreditScene(Game game, SpriteFont textFont ,Texture2D backgroundTexture) : base(game)
        {
            TextFont = textFont;
            BackgroundTexture = backgroundTexture;
            InitCreditText();
        }

        private void InitCreditText()
        {
            creditText = "Game developped by Johan Silkens \n GPLv3 \n\n CONTROLS \n\n\n\n Press ESC to go back to the main menu. ";
        }

        public Texture2D BackgroundTexture
        {
            get { return _backgroundTexture; }
            set { _backgroundTexture = value; }
        }

        public SpriteFont TextFont
        {
            get { return _textFont; }
            set { _textFont = value; }
        }

        public bool EscEntered
        {
            get { return escEntered; }
            set { escEntered = value; }
        }

        public override void Update(GameTime gametime)
        {
            EscPressed();
            base.Update(gametime);
        }

        private void EscPressed()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                EscEntered = true;
            }
            else
            {
                EscEntered = false;
            }
                
                
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 textSize = _textFont.MeasureString(creditText);

            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sBatch.Draw(_backgroundTexture,
                new Rectangle(0, 0, screenBounds.Width, screenBounds.Height), Color.White);
            sBatch.DrawString(_textFont, creditText, new Vector2(30,  30), Color.White);
            base.Draw(gameTime);
        }


        public override void Show()
        {
            //play some music

            base.Show();
        }
    }
}