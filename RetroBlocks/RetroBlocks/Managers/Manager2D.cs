using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RetroBlocks.Drawables;

namespace RetroBlocks.Managers
{
    class Manager2D : DrawableGameComponent
    {
        protected List<Component2D> components;
        protected Texture2D texture;
        protected Rectangle screenBounds;

        public Manager2D(Game game, Texture2D texture)
            : base(game)
        {
            this.texture = texture;
            screenBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            components = new List<Component2D>();
        }

        public override void Initialize()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Initialize();
            }

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].Enabled)
                {
                    components[i].Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].Visible)
                {
                    components[i].Draw(gameTime);
                }
            }
            base.Draw(gameTime);
        }

        public void RemoveNotAlive()
        {
            for (int i = components.Count - 1; i >= 0; i--)
            {
                if (!components[i].IsAlive)
                {
                    components.RemoveAt(i);
                }
            }
        }
    }
}
