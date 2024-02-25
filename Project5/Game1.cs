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
        private SpriteFont labelFont; //modify JasonFont for labelFont
        private SpriteFont labelFont2;
        private SpriteFont labelFont3;
        private Toggle toggle1;
        private Spinner spinner;

        //things to create:
        /*
         * admissions' officer's temper
         * legacy (y/n)
         * wealth
         * consultancy agent used (y/n)
         * 
         */

        public Game1()
        {
            
            _graphics = new GraphicsDeviceManager(this);
            //REMEMBER TO TURN ON IS FULL SCREEN!!!!!!!
            //_graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            slider1 = new Slider(new Point(200,64), 200, 100,"Bad","Good");
            toggle1 = new Toggle(new Point(200), "No", "Yes","Toggle:");
            spinner = new Spinner(10, new Point(100, 300));
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
            labelFont = JasonFont;
            labelFont2 = Content.Load<SpriteFont>("labelFont2");
            labelFont3 = Content.Load<SpriteFont>("labelFont3");
            //labelFont = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            MM.Update();
            slider1.update();
            toggle1.update();
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(154, 190, 252));

            // TODO: Add your drawing code here
            //draws stuff

            _spriteBatch.Begin();
            slider1.draw(_spriteBatch);
            slider1.drawLabels(_spriteBatch, labelFont3, "label:",labelFont2);
            toggle1.draw(_spriteBatch, labelFont,labelFont2);
            spinner.draw(_spriteBatch);
            //_spriteBatch.DrawString(JasonFont, "Hello World", new Vector2(100, 100), Color.BlueViolet);
            _spriteBatch.End();

            base.Draw(gameTime);
        }



    }
}