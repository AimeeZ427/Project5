using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    internal class MM
    {
        public static MouseState MouseState { get; private set; }

        public static MouseState PreviousMouseState { get; private set; }

        public static KeyboardState KeyboardState { get; private set; }

        public static KeyboardState PreviousKeyboardState { get; private set; }

        public static void Update()
        {
            PreviousMouseState = MouseState;
            MouseState = Mouse.GetState();

            PreviousKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();

        }

        public static Texture2D OneWhitePixel { get; private set; }

        public static void Initalize(GraphicsDevice gd)
        {
            Texture2D t = new Texture2D(gd, 1, 1);
            t.SetData(new Color[] { Color.White });
            OneWhitePixel = t;
        }
    }


}