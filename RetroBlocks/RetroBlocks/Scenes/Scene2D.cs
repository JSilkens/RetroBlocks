using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RetroBlocks.Scenes
{
    class Scene2D : DrawableGameComponent
    {
        protected List<GameComponent> components;
        protected Rectangle screenBounds;

        public Scene2D(Game game)
            : base(game)
        {
            components = new List<GameComponent>();
            screenBounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            Visible = false;
            Enabled = false;
        }

        public virtual void Show()
        {
            Visible = true;
            Enabled = true;
        }

        public virtual void Hide()
        {
            Visible = false;
            Enabled = false;
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
            // update all actors

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
            // draw actors if DrawableGameComponent

            for (int i = 0; i < components.Count; i++)
            {
                if ((components[i] is DrawableGameComponent)
                    && ((DrawableGameComponent)components[i]).Visible)
                {
                    ((DrawableGameComponent)
                        components[i]).Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }
    }
}
