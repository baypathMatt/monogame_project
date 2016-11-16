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
    public class Player
    {

        private Rectangle bb;
        private Color color;
        private Texture2D solidText;
        private int direction = 5;
    
        public Player(int x, int y, Texture2D texture, Color c)
        {
            bb = new Rectangle(x, y, 25, 25);
            color = c;
            solidText = texture;
        }

        public void Update(GameTime gameTime)
        {

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Up))
            {
                bb.Y -= direction;
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                bb.Y += direction;
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                bb.X -= direction;
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                bb.X += direction;
            }

            if (bb.X <= 0 || bb.X >= 1000)
            {
                bb.X -= bb.X;
            }

            if (bb.Y <= 0 || bb.Y >= 600)
            {
                bb.Y -= bb.Y;
            }

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
