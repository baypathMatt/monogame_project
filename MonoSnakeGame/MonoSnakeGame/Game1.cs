using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MonoSnakeGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player pOne;
        Gem gOne;
        Gem gTwo;
        Gem gThree;
        Gem gFour;
        Texture2D genTex;
        SpriteFont font;
        double score = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {

            genTex = new Texture2D(GraphicsDevice, 1, 1);
            genTex.SetData(new[] { Color.White });

            // Player and Gem Initialization
            pOne = new Player(4, Color.Green, new Rectangle(300, 300, 25, 25), genTex);
            gOne = new Gem(genTex, Color.Red);
            gTwo = new Gem(genTex, Color.Red);
            gThree = new Gem(genTex, Color.Red);
            gFour = new Gem(genTex, Color.Red);

            //SpriteFont initialization
            font = Content.Load<SpriteFont>("gemScore");

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            pOne.Update();
            gOne.Update();
            gTwo.Update();
            gThree.Update();
            gFour.Update();

            if (pOne.getColor() == Color.Black)
            {
                Exit();
            }

            if(pOne.gemGet(gOne) == true)
            {
                gOne.Hide();
                pOne.grow();
                score += 0.5;
            }

            if (pOne.gemGet(gTwo) == true)
            {
                gTwo.Hide();
                pOne.grow();
                score += 0.5;
            }

            if (pOne.gemGet(gThree) == true)
            {
                gThree.Hide();
                pOne.grow();
                score += 0.5;
            }

            if (pOne.gemGet(gFour) == true)
            {
                gFour.Hide();
                pOne.grow();
                score += 0.5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                pOne.changeColor(Color.TransparentBlack);    
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin Drawing
            spriteBatch.Begin();

            // Drawing the Gem's and Player
            pOne.Draw(spriteBatch);
            gOne.Draw(spriteBatch);
            gTwo.Draw(spriteBatch);
            gThree.Draw(spriteBatch);
            gFour.Draw(spriteBatch);

            // Drawing the score
            int final_score = (int)score; 
            spriteBatch.DrawString(font, "Score: " + final_score, new Vector2(25, 25), Color.White);

            // End Drawing
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
