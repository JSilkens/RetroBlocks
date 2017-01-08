using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RetroBlocks.Model;

namespace RetroBlocks.Drawables
{
    public class BoardTexture : Component2D
    {

       
        protected Vector2 position = new Vector2();

        protected const int WIDTH = 45;
        protected const int HEIGHT = 45;

        protected Rectangle screenBounds;

        protected ArrayList blockTextures;
        protected double posLeft;
        protected Texture2D[,] blockTextureArray;


        public BoardTexture(Game game)
            : base(game)
        {
           
            screenBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            posLeft = (GraphicsDevice.Viewport.Width/4) + 5;
            blockTextures = new ArrayList();
            blockTextureArray = new Texture2D[16,10];
            
            LoadContent();

        }

        protected override void LoadContent()
        {
            blockTextures.Add(Game.Content.Load<Texture2D>("red"));
            blockTextures.Add(Game.Content.Load<Texture2D>("pink"));
            blockTextures.Add(Game.Content.Load<Texture2D>("blue"));
            blockTextures.Add(Game.Content.Load<Texture2D>("lblue"));
            blockTextures.Add(Game.Content.Load<Texture2D>("green"));
            blockTextures.Add(Game.Content.Load<Texture2D>("lgreen"));
            blockTextures.Add(Game.Content.Load<Texture2D>("yellow"));

        }

        public BlockArray BoardArray { get; set; }

        public override void Initialize()
        {
            base.Initialize();


        }


        //Update board texture similar whith 
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            UpdateBoard();

            base.Update(gameTime);
        }

        private void UpdateBoard()
        {
            if (BoardArray != null)
            {
                for (int i = 0; i < blockTextureArray.GetLength(0); i++)
                {
                    for (int j = 0; j < blockTextureArray.GetLength(1); j++)
                    {
                        if (BoardArray.Get(i,j).Type != BlockType.EMPTY)
                        {
                            blockTextureArray[i, j] = (Texture2D) blockTextures[0];
                        }
                    }
                }
            }
        }


        // Draw gameboard texture;
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sBatch =
                (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            position.Y = (float) posLeft;

            for (int i = 0; i < blockTextureArray.GetLength(0); i++)
            {
                for (int j = 0; j < blockTextureArray.GetLength(1); j++)
                {
                    if (blockTextureArray[i,j] != null && BoardArray.Get(i,j).Type != BlockType.EMPTY)
                    {
                        sBatch.Draw(blockTextureArray[i, j], new Vector2(position.Y + (j * 45), position.X + (i * 45)));
                    }

                    
                }
            }

            sBatch.Draw((Texture2D) blockTextures[2],new Vector2(100,300), Color.White);
            base.Draw(gameTime);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y,
                            WIDTH, HEIGHT);
        }




    }
}
