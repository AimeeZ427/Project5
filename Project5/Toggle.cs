using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    internal class Toggle
    {
        Point location;
        string[] texts;
        int which;
        string label;

        public Toggle(Point l, string txtNo, string txtYes, string la)
        {
            location = l;
            texts = new string[] { txtNo, txtYes };
            which = 0;
            label = la;
            
        }

        public void update()
        {
            if (isClicked(new Rectangle(location.X, location.Y, 140, 70)))
            {
                if (which == 0) { which = 1; }
                else { which = 0; }
            }
        }

        public bool isClicked(Rectangle rect)
        {
            return rect.Contains(MM.MouseState.Position.ToVector2())&& (MM.MouseState.LeftButton == ButtonState.Pressed) && (MM.PreviousMouseState.LeftButton == ButtonState.Released);
            //

        }


        public void draw(SpriteBatch _spriteBatch, SpriteFont font, SpriteFont font2)
        {
            //_spriteBatch.Begin();
            //_spriteBatch.DrawString(EthanFont, "This is Ethan's custom font. Ethan's eyesight \nis so bad that he can't read this.", new Vector2(100, 100), Color.DarkBlue);
            // _spriteBatch.Draw(blue, bluer, Color.DarkBlue);
            //_spriteBatch.Draw(apple, new Vector2(190, 0), Color.Red);

            _spriteBatch.Draw(MM.OneWhitePixel, new Rectangle(location.X,location.Y,140,70), Color.LightSlateGray);
            drawText(_spriteBatch,font,font2);
            //drawRect(toggleBounds, _spriteBatch, Color.LightSlateGray); //the toggle part



            //_spriteBatch.End();

        }
        
        public void drawText(SpriteBatch _spriteBatch,SpriteFont font,SpriteFont font2)
        {
            Point l = new Point();
            l.X = (int)((140-font.MeasureString(texts[which]).X)/2);
            l.Y = (int)((70 - font.MeasureString(texts[which]).Y) / 2);
            Point l2 = new Point();
            l2.X = location.X - (int)font2.MeasureString(label).X;
            l2.Y = location.Y + (int)(70 - font2.MeasureString(label).Y) / 2;
            _spriteBatch.DrawString(font, texts[which], new Microsoft.Xna.Framework.Vector2(l.X+location.X, location.Y+l.Y), new Color(72, 76, 84));
            _spriteBatch.DrawString(font2, label, new Microsoft.Xna.Framework.Vector2(l2.X, l2.Y), new Color(72, 76, 84));
        }






    }
}
