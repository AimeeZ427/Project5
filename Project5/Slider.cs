using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    internal class Slider
    {
        //Console.Writeline("Hello World");


        int currentV;
        Point location;
        int width;
        bool active;

        public Slider(Point l, int w, int initValue)
        {
            location = l;
            width = w;
            currentV = initValue;
            active = false;
        }


        public void draw(SpriteBatch _spriteBatch)
        {
            //_spriteBatch.Begin();
            //_spriteBatch.DrawString(EthanFont, "This is Ethan's custom font. Ethan's eyesight \nis so bad that he can't read this.", new Vector2(100, 100), Color.DarkBlue);
            // _spriteBatch.Draw(blue, bluer, Color.DarkBlue);
            //_spriteBatch.Draw(apple, new Vector2(190, 0), Color.Red);

            drawRect(new Rectangle(location.X, location.Y, width, 15), _spriteBatch); //the bar part
            drawRect(new Rectangle(location.X + currentV - 4, location.Y - 10, 8, 35), _spriteBatch, Color.LightSlateGray); //the toggle part

            //_spriteBatch.End();

        }

        public void drawRect(Rectangle rect, SpriteBatch _spriteBatch, Color? color = null)
        {
            _spriteBatch.Draw(MM.OneWhitePixel, rect, color ?? new Color(72, 76, 84)); //default color = dark grey
        }

        public void update()
        {
            if (MM.MouseState.LeftButton == ButtonState.Pressed && MM.PreviousMouseState.LeftButton == ButtonState.Released)
            {
                if (new Rectangle(location.X+currentV-2,location.Y-10-2,8+4,35+4).Contains(MM.MouseState.Position)) //debugging stuff; 1==1
                {
                    active = true;
                }

            }

            if (MM.MouseState.LeftButton == ButtonState.Released && MM.PreviousMouseState.LeftButton == ButtonState.Pressed)
            {
                active = false;
            }

            if (active && currentV + 4 < width && currentV - 4 > 0)
            {
                currentV += MM.MouseState.Position.X - MM.PreviousMouseState.Position.X;

            }
            else if (active && currentV + 4 <= width)
            {
                currentV = 5;
            }
            else if (active && currentV - 4 >= 0)
            {
                currentV = width - 5;
            }

        }



    }
}