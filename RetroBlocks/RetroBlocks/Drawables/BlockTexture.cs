using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RetroBlocks.Drawables
{
    public class BlockTexture : Microsoft.Xna.Framework.DrawableGameComponent
    {

        protected Texture2D texture;
        protected Vector2 position = new Vector2();

        protected const int WIDTH = 45 ;
        protected const int HEIGHT = 45 ;

        protected Rectangle screenBounds;

        

        public BlockTexture(Game game, Texture2D texture)
            : base(game)
        {
            this.texture = texture;
            screenBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
           
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sBatch =
                (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sBatch.Draw(texture, position, Color.White);
            base.Draw(gameTime);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y,
                            WIDTH, HEIGHT);
        }

       


    }
}
