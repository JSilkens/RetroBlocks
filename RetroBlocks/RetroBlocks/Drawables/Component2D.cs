using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RetroBlocks.Drawables
{
    class Component2D : DrawableGameComponent
    {
        protected Texture2D texture;
        protected Vector2 position = new Vector2();

        protected Rectangle screenBounds;
        protected bool isAlive;

        public Component2D(Game game)
            : base(game)
        {
            screenBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            isAlive = true;
        }

        public Component2D(Game game, Texture2D texture)
            : base(game)
        {
            this.texture = texture;
            screenBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            isAlive = true;
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
            base.Draw(gameTime);
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
