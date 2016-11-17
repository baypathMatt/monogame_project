using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoSnakeGame
{
    public class Gem
    {

        private Rectangle bb;
        private Color color;
        private Texture2D solidText;
        private static Random rand = new Random();

        public Gem(Texture2D texture, Color c)
        {
            int xpos = rand.Next(75, 975);
            int ypos = rand.Next(75, 575);
            bb = new Rectangle(xpos, ypos, 25, 25);
            color = c;
            solidText = texture;
        }

        public void Update()
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

        public void Hide()
        {
            this.color = color * 0.5f;
        }
    }
}
