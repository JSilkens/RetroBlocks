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
            blockTextureArray = new Texture2D[24,10]; // board is normally 16 rows high
            
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
                            blockTextureArray[i, j] = GetBlockColor(BoardArray.Get(i, j));
                        }
                    }
                }
            }
        }

        private Texture2D GetBlockColor(Block block)
        {
            switch (block.Type)
            {
                case BlockType.RED:
                    return (Texture2D) blockTextures[0];
                    break;
                case BlockType.PINK:
                    return (Texture2D)blockTextures[1];
                    break;
                case BlockType.BLUE:
                    return (Texture2D)blockTextures[2];
                    break;
                case BlockType.LBLUE:
                    return (Texture2D)blockTextures[3];
                    break;
                case BlockType.GREEN:
                    return (Texture2D)blockTextures[4];
                    break;
                case BlockType.LGREEN:
                    return (Texture2D)blockTextures[5];
                    break;
                case BlockType.YELLOW:
                    return (Texture2D)blockTextures[6];
                    break;
            }

            return null;
        }


        // Draw gameboard texture;
        public override void Draw(GameTime gameTime)
        {
            float scale = .5f;
            SpriteBatch sBatch =
                (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            position.Y = (float) posLeft;

            for (int i = 0; i < blockTextureArray.GetLength(0); i++)
            {
                for (int j = 0; j < blockTextureArray.GetLength(1); j++)
                {
                    if (blockTextureArray[i,j] != null && BoardArray.Get(i,j).Type != BlockType.EMPTY)
                    {
                        //sBatch.Draw(blockTextureArray[i, j], new Vector2(position.Y + (j * 45), position.X + (i * 45)));
                        sBatch.Draw(blockTextureArray[i, j], new Vector2((float) (position.Y + (j * 22.5)), (float) (position.X + (i * 22.5))), null,
                            Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                    }

                    
                }
            }

            //sBatch.Draw((Texture2D) blockTextures[2],new Vector2(100,300), Color.White);
            base.Draw(gameTime);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y,
                            WIDTH, HEIGHT);
        }




    }
}
