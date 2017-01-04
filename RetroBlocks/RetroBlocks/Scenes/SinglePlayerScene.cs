using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using RetroBlocks.Drawables;
using RetroBlocks.Factories;

namespace RetroBlocks.Scenes
{
    public class SinglePlayerScene : Scene2D
    {
        private TextMenu menu;
        private MenuFactory menuFactory;

        public SinglePlayerScene(Game game) : base(game)
        {
        }
    }
}