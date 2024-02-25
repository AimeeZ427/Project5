using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project5;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Numerics;
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
        string leftl;
        string rightl;

        public Slider(Point l, int w, int initValue, string l1, string l2)
        {
            location = l;
            width = w;
            currentV = initValue;
            active = false;
            leftl = l1;
            rightl = l2;    
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

        /*
         * public void drawText(SpriteBatch _spriteBatch,SpriteFont font,SpriteFont font2)
        {
            Point l = new Point();
            l.X = (int)((140-font.MeasureString(texts[which]).X)/2);
            l.Y = (int)((70 - font.MeasureString(texts[which]).Y) / 2);
            Point l2 = new Point();
            l2.X = location.X - (int)font.MeasureString(label).X;
            l2.Y = location.Y + (int)(70 - font.MeasureString(label).Y) / 2;
            _spriteBatch.DrawString(font, texts[which], new Microsoft.Xna.Framework.Vector2(l.X+location.X, location.Y+l.Y), new Color(72, 76, 84));
            _spriteBatch.DrawString(font2, label, new Microsoft.Xna.Framework.Vector2(l2.X, l2.Y), new Color(72, 76, 84));
        }
         */

        public void drawLabels(SpriteBatch _spriteBatch, SpriteFont font2, string title,SpriteFont font)
        {
            Point l = new Point();
            l.X = (int)(location.X - font.MeasureString(title).X)-(int)font2.MeasureString(leftl).X-(int)font.MeasureString("ii").X-5;
            l.Y = (int)((font.MeasureString(title).Y-15) / 2);

            int y = (int)(font2.MeasureString(leftl).Y - 15) / 2;

            _spriteBatch.DrawString(font, title, new Microsoft.Xna.Framework.Vector2(l.X, l.Y*-1+location.Y), new Color(72, 76, 84));
            _spriteBatch.DrawString(font2,leftl, new Microsoft.Xna.Framework.Vector2(l.X+ (int)font.MeasureString("ii").X+(int)font.MeasureString(title).X,-y+location.Y), new Color(72, 76, 84));
            _spriteBatch.DrawString(font2,rightl,new Microsoft.Xna.Framework.Vector2(location.X+width+5, -y + location.Y), new Color(72, 76, 84));
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