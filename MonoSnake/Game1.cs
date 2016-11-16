using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoSnake
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player pOne;
        Gem gOne;
        Texture2D solidText;
        Player pOne2;

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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            solidText = new Texture2D(GraphicsDevice, 1, 1);
            solidText.SetData(new[] { Color.White });

            pOne = new Player(700, 400, solidText, Color.Red);
            gOne = new Gem(300, 400, solidText, Color.Blue);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            pOne.Update(gameTime);
            gOne.Update(gameTime);

            if (pOne.getRect().Intersects(gOne.getRect())){
                gOne.changeColor(Color.Black);
                pOne2 = new Player(325, 425, solidText, Color.Red);
                pOne2.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            pOne.Draw(spriteBatch);

            gOne.Draw(spriteBatch);
           
            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
