using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OpenTK.Graphics.OpenGL;
using RetroBlocks.Drawables;
using RetroBlocks.Factories;
using RetroBlocks.Services;
using Keys = Microsoft.Xna.Framework.Input.Keys;


namespace RetroBlocks.Scenes
{
    public class GameScene : Scene2D
    {
        private Texture2D t;
        

        public GameScene(Game game,Texture2D bacgroundTexture , List<SpriteFont> fontList ) : base(game)
        {
            
            BackgroundTexture = bacgroundTexture;
            t = new Texture2D(GraphicsDevice, 1, 1);
            t.SetData<Color>(
                new Color[] { Color.White });// fill the texture with white

            Fontlist = fontList;
           

        }

        public GameService GameService { get; set; }

        private StandardGameService GetStandardGameService()
        {
            return (StandardGameService) GameService;
        }


        private Texture2D BackgroundTexture { get; set; }

        public List<SpriteFont> Fontlist { get; set; }

        public override void Initialize()
        {
            base.Initialize();
        }


        //Moves blocks
        public override void Update(GameTime gameTime)
        {
            InitBoard();
            HandleScenesInput();
            GetStandardGameService().Play(gameTime);
           // RefreshBoard();
            base.Update(gameTime);
        }

        private void RefreshBoard()
        {
            Debug.WriteLine(GetStandardGameService().Board.ToString());
            Debug.WriteLine(" == End of board ==");
        }

        private void PlayGame()
        {
          GetStandardGameService().Board.DropBlock();
        }

        private void InitBoard()
        {
            
            if (GetStandardGameService().Board == null)
            {
                GameService.InitializeGame();
                
            }
           
        }

        private void HandleScenesInput()
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sBatch.Draw(BackgroundTexture,
                new Rectangle(0, 0, screenBounds.Width, screenBounds.Height), Color.White);

            DrawLine(sBatch, //draw left line
            new Vector2(Game.GraphicsDevice.Viewport.Width/4, 0), //start of line
            new Vector2(Game.GraphicsDevice.Viewport.Width / 4, Game.GraphicsDevice.Viewport.Height) //end of line
        );

            DrawLine(sBatch, //draw right line
           new Vector2(Game.GraphicsDevice.Viewport.Width - (Game.GraphicsDevice.Viewport.Width / 4), 0), //start of line
           new Vector2(Game.GraphicsDevice.Viewport.Width - (Game.GraphicsDevice.Viewport.Width / 4), Game.GraphicsDevice.Viewport.Height) //end of line
       );

            sBatch.DrawString(Fontlist[2], "Player: " + GameService.PlayerOne.Name, new Vector2(30, 30), Color.White);
            sBatch.DrawString(Fontlist[2], "Score: " + GameService.PlayerOne.Score, new Vector2(30, 60), Color.White);
            sBatch.DrawString(Fontlist[2], "High score: " + GameService.PlayerOne.HighScore, new Vector2(30, 80), Color.White);

            base.Draw(gameTime);
        }

        void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);


            sb.Draw(t,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    5), //width of line, change this to make thicker line
                null,
                Color.Green, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }

        public override void Show()
        {
            //play some music

            base.Show();
        }

    }
}