using Apos.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Profession
{
    public class main : Game
    {
        private Manager manager;

        private GraphicsDeviceManager _graphics;


        private SpriteBatch _spriteBatch;
        private SpriteFont debug_font;

        public static bool Quit = false;

        public string debug = "state";
        public main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            manager = new Manager(this, Content, _graphics);

            Window.Title = config.w_title;
            _graphics.PreferredBackBufferHeight = config.w_height;
            _graphics.PreferredBackBufferWidth = config.w_width;
        }

        protected override void Initialize()
        {
            manager.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            manager.LoadComponents();
            manager.LoadContent();

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            manager.Update();
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if(StateManager.CurrentState == StateManager.states.MainMenu)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            else
            {
                GraphicsDevice.Clear(Color.Black);
            }

            _spriteBatch.Begin();

            manager.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}