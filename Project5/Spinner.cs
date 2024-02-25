using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    internal class Spinner
    {
        public int currentV;
        Point location;
        public Spinner(int i, Point p)
        {
            currentV = i;
            location = p;
        }

        public void draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(MM.OneWhitePixel,new Rectangle(location.X, location.Y, 600, 50), Color.DarkBlue);
        }


    }
}
