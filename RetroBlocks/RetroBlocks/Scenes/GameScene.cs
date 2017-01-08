using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
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
        private BoardTexture boardTexture;
        private bool boardInit = false;
        

        public GameScene(Game game,Texture2D bacgroundTexture , List<SpriteFont> fontList ) : base(game)
        {
            
            BackgroundTexture = bacgroundTexture;
            t = new Texture2D(GraphicsDevice, 1, 1);
            t.SetData<Color>(
                new Color[] { Color.White });// fill the texture with white

            Fontlist = fontList;
            boardTexture = new BoardTexture(game);
            
           
           

        }

        public GameService GameService { get; set; }

        private StandardGameService GetStandardGameService()
        {
            return (StandardGameService) GameService;
        }


        private Texture2D BackgroundTexture { get; set; }

        public List<SpriteFont> Fontlist { get; set; }
        public KeyboardState oldKeyboardState { get; private set; }

        public override void Initialize()
        {
            
            base.Initialize();
        }


        //Moves blocks
        public override void Update(GameTime gameTime)
        {
            if (boardInit == false)
            {
                Game.Components.Add(boardTexture);
                boardInit = true;
            }
            if (GameService.InGame)
            {
                
                InitBoard();
                if (GetStandardGameService().CheckGameOver() == false)
                {
                    HandleScenesInput();
                    GetStandardGameService().Play(gameTime);
                    boardTexture.BoardArray = GetStandardGameService().Board.GameBoardArray;
                }
                else
                {
                    MessageBox.Show("Game Over");
                    GameService.InGame = false;
                }
            }

           
           
           
            base.Update(gameTime);
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
            bool goLeft, goRight, rotateLeft, rotateRight;
            Vector2 oldDropLocation = GetStandardGameService().Board.Droplocation;
            KeyboardState keyBoardState = Keyboard.GetState();

            goLeft = oldKeyboardState.IsKeyUp(Keys.Left) && keyBoardState.IsKeyDown(Keys.Left);
            goRight = oldKeyboardState.IsKeyUp(Keys.Right) && keyBoardState.IsKeyDown(Keys.Right);
            rotateLeft = oldKeyboardState.IsKeyUp(Keys.Z) && keyBoardState.IsKeyDown(Keys.Z);
            rotateRight = oldKeyboardState.IsKeyUp(Keys.C) && keyBoardState.IsKeyDown(Keys.C);



            if (goLeft)
            {
             GetStandardGameService().Board.Droplocation = new Vector2(oldDropLocation.X , oldDropLocation.Y -1);
            }

            if (goRight)
            {
             GetStandardGameService().Board.Droplocation = new Vector2(oldDropLocation.X, oldDropLocation.Y + 1);
            }

            if (rotateLeft)
            {
                GetStandardGameService().Board.CurrentPiece.RotateLeft();
            }

            if (rotateRight)
            {
                GetStandardGameService().Board.CurrentPiece.RotateRight();
            }

            oldKeyboardState = keyBoardState;
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