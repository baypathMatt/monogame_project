using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoSnake
{
    public class Gem
    {

        private Rectangle bb;
        private Color color;
        private Texture2D solidText;
        private static Random rand = new Random();

        public Gem(int x, int y, Texture2D texture, Color c)
        {
            //int xpos = rand.Next(300, 800);
            //int ypos = rand.Next(200, 500);
            bb = new Rectangle(x, y, 25, 25);
            color = c;
            solidText = texture;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch sb)
        {

            sb.Draw(solidText, bb, color);

        }

        public Rectangle getRect()
        {
            return bb;
        }

        public void changeColor(Color c)
        {
            color = c;
        }
    }
}
