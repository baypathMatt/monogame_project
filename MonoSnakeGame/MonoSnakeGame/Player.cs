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
    public class Player
    {

        private Rectangle bb;
        private Color c;
        private Texture2D snakeTex;
        private Keys direction;
        private int xVel;
        private int yVel;
        private double length;

        public Player(Texture2D t)
        {
            length = 1;
            c = Color.Red;
            bb = new Rectangle(300, 300, 50, 50);
            snakeTex = t;
            direction = Keys.D;
            xVel = 2;
            yVel = 2;
        }

        public Player(int l, Color cl, Rectangle r, Texture2D t)
        {
            length = l;
            c = cl;
            bb = r;
            snakeTex = t;
            xVel = 2;
            yVel = 2;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                direction = Keys.D;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                direction = Keys.A;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                direction = Keys.S;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                direction = Keys.W;

            if (direction.Equals(Keys.D))
            {
                bb.X += xVel;
            }
            if (direction.Equals(Keys.A))
            {
                bb.X -= xVel;
            }
            if (direction.Equals(Keys.S))
            {
                bb.Y += yVel;
            }
            if (direction.Equals(Keys.W))
            {
                bb.Y -= yVel;
            }


            if (bb.X <= 0 || bb.X >= 1000)
            {
                c = Color.Black;
            }

            if (bb.Y <= 0 || bb.Y >= 600)
            {
                c = Color.Black;
            }

        }

        public void Draw(SpriteBatch s)
        {

            s.Draw(snakeTex, bb, c);
            if (direction.Equals(Keys.D))
            {
                for(int i = 0; i < length; i++)
                {
                    s.Draw(snakeTex, new Rectangle(bb.X - 28 * i, bb.Y, 25, 25 ), c);
                }
            }

            else if (direction.Equals(Keys.A))
            {
                for (int i = 0; i < length; i++)
                {
                    s.Draw(snakeTex, new Rectangle(bb.X + 28 * i, bb.Y, 25, 25), c);
                }
            }

            else if(direction.Equals(Keys.S))
            {
                for (int i = 0; i < length; i++)
                {
                    s.Draw(snakeTex, new Rectangle(bb.X, bb.Y - 28 * i, 25, 25), c);
                }
            }

            else if(direction.Equals(Keys.W))
            {
                for (int i = 0; i < length; i++)
                {
                    s.Draw(snakeTex, new Rectangle(bb.X, bb.Y + 28 * i, 25, 25), c);
                }
            }
            else
            {
                for(int i = 0; i<length; i++)
                {
                    s.Draw(snakeTex, new Rectangle(bb.X - 28 * i, bb.Y, 25, 25), c);
                }
            }
        }

        public bool gemGet(Gem g)
        {
            if (this.bb.Intersects(g.getRect()))
            {
                return true;
            }
            else return false;
        }

        public Color getColor()
        {
            return c;
        }

        public Rectangle getRect()
        {
            return bb;
        }

        public void changeColor(Color cl)
        {
            c = cl;
        }

        public void grow()
        {
            length += 0.15;
        }
    }
}
