using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project5;

namespace Project5
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Slider slider1;
        private SpriteFont JasonFont; //label font
        //private SpriteFont labelFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            slider1 = new Slider(new Point(64), 200, 100);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            MM.Initalize(GraphicsDevice);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            JasonFont = Content.Load<SpriteFont>("JasonFont");
            //labelFont = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            MM.Update();
            slider1.update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(154, 190, 252));

            // TODO: Add your drawing code here
            //draws stuff

            _spriteBatch.Begin();
            slider1.draw(_spriteBatch);
            slider1.drawLabels(_spriteBatch, JasonFont, "idk"); //why wont label font work??? idk
            //_spriteBatch.DrawString(JasonFont, "Hello World", new Vector2(100, 100), Color.BlueViolet);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}