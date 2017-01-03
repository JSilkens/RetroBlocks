using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using RetroBlocks.Drawables;

namespace RetroBlocks.Factories
{
    class MenuFactory
    {
        private static TextMenu _textMenu;
       
        public MenuFactory()
        {

        }

        public TextMenu CreateMenu(String type , Game game , SpriteFont font , SoundEffect selectEffect,Vector2 position)
        {
            if (type.Equals("main menu",StringComparison.InvariantCultureIgnoreCase))
            {
                _textMenu = new TextMenu(game,font,selectEffect);
                _textMenu.AddMenuItem("Single Player");
                _textMenu.AddMenuItem("Multi Player");
                _textMenu.AddMenuItem("Credits");
                _textMenu.AddMenuItem("Quit");

                _textMenu.Position = position;
                

                return _textMenu;
            }
            if (type.Equals("single player", StringComparison.InvariantCultureIgnoreCase))
            {
                _textMenu = new TextMenu(game, font, selectEffect);
                _textMenu.AddMenuItem("Staandard");
                _textMenu.AddMenuItem("Line Clear");
                _textMenu.AddMenuItem("Back to main menu");
                _textMenu.AddMenuItem("Quit");

                _textMenu.Position = position;


                return _textMenu;
            }
            return null;
        }


    }
}
