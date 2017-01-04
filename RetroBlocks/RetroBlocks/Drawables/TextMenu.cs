using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RetroBlocks.Drawables
{
    class TextMenu : Component2D
    {
        SpriteFont font;

        int selectedIndex = 0;
        readonly List<String> menuItems;

        KeyboardState oldKeyboardState;
        SoundEffect selectEffect;
        public TextMenu(Game game , SpriteFont font , SoundEffect selectEffect) : base(game)
        {
            Font = font;
            SelectEffect = selectEffect;
            menuItems = new List<string>();
            oldKeyboardState = Keyboard.GetState();

        }

        public override void Update(GameTime gameTime)
        {
            bool down, up;

            KeyboardState keyBoardState = Keyboard.GetState();

             down = oldKeyboardState.IsKeyUp(Keys.Down) && keyBoardState.IsKeyDown(Keys.Down);
             up = oldKeyboardState.IsKeyUp(Keys.Up) && keyBoardState.IsKeyDown(Keys.Up);

            

            if (down)
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
                selectEffect.Play();
            }

            if (up)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Count - 1;
                }
                selectEffect.Play();
            }

            oldKeyboardState = keyBoardState;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Color theColor;
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            float y = position.Y; // set y equal to menu position

            for (int i = 0; i < menuItems.Count; i++) 
            {
                if (i == selectedIndex)
                {
                    theColor = Color.Green;
                }
                else
                {
                    theColor = Color.White;
                }
                sBatch.DrawString(font, menuItems[i], new Vector2(position.X + 2, y + 2), Color.Gray);
                sBatch.DrawString(font, menuItems[i], new Vector2(position.X, y), theColor);
                y += 45; // Todo problem when a lager font is used.
            }

            base.Draw(gameTime);
        }
        public void AddMenuItem(string item)
        {
            menuItems.Add(item);
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        public SoundEffect SelectEffect
        {
            get { return selectEffect; }
            set { selectEffect = value; }
        }

        public KeyboardState OldKeyboardState
        {
            get { return oldKeyboardState; }
            set { oldKeyboardState = value; }
        }

        
    }
}
