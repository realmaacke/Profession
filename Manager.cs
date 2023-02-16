using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Profession.Scenes;
using Profession.EventHandlers;

namespace Profession
{
    public class Manager
    {
        private Game instance;
        // Managers
        private ReturnManager returnManager;
        private UiManager uiManager;

        //Components

        private ContentManager Content;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private SpriteFont debug_font;

        public Manager(Game instance, ContentManager Content, GraphicsDeviceManager graphics)
        {
            this.instance = instance;
            this.Content = Content;
            this.graphics = graphics;

            // Instancing of managers
            returnManager = new ReturnManager(this.Content, this.graphics);

        }

        public void LoadComponents()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            uiManager = new UiManager(this.spriteBatch, graphics.GraphicsDevice);
        }

        public void LoadContent()
        {
            
            debug_font = ReturnManager.LoadSpriteFont("debug_font");
        }

        public void Initialize()
        {
            StateManager.OnMainMenu();
        }

        private string debug;
        private string debug_1;
        private string debug_2;

        public void Update()
        {
            // Debug
            debug = KeyHandler.GetKeys().ToString();
            debug_1 = KeyHandler.GetKeyAction(KeyHandler.GetKeys()).ToString();
            debug_2 = StateManager.CurrentState.ToString();


            KeyHandler.KeyEvent();

            //Updating managers
            uiManager.Update();


            // check if exit enum is active
            if (KeyHandler.OnExit())
                instance.Exit();
        }

        public void Draw()
        {
            uiManager.Draw();

        }


        public void DebugUpdate()
        {
            spriteBatch.Begin();

            Vector2 debug_1_pos = new Vector2((config.w_width - 100), 10);
            Vector2 debug_2_pos = new Vector2(config.w_width - 100, 40);
            Vector2 debug_3_pos = new Vector2(config.w_width - 100, 80);

            spriteBatch.DrawString(debug_font, debug, debug_1_pos, Color.Yellow);
            spriteBatch.DrawString(debug_font, debug_1, debug_2_pos, Color.Yellow);
            spriteBatch.DrawString(debug_font, debug_2, debug_3_pos, Color.Yellow);

            spriteBatch.End();

        }

    }

    public static class StateManager
    {
        public static states CurrentState;

        public enum states
        {
            MainMenu, PausMenu,
            InGame, InCombat
        }

        public static states OnMainMenu() => CurrentState = states.MainMenu;
        public static states OnInGame() => CurrentState = states.InGame;
        public static states OnPauseMenu() => CurrentState = states.PausMenu;
        // kinda deprecated method
        public static states OnCombat() => CurrentState = states.InCombat;

    }

    public class UiManager
    {
        private IScenes UiInterface;
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphics;

        public UiManager(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;

        }

        public void Update()
        {
            switch (StateManager.CurrentState)
            {
                case StateManager.states.MainMenu:
                    UiInterface = new MainMenuScene(spriteBatch, graphics);
                    break;
                case StateManager.states.PausMenu:
                    UiInterface = new PausMenuScene(spriteBatch, graphics);
                    break;
                case StateManager.states.InGame:
                    UiInterface = new GameScene(spriteBatch, graphics);
                    break;
            }
        }

        public void Draw()
        {
            UiInterface.Draw();
        }

        public void UnloadUI()
        {
            UiInterface = null;
        }

    }


    public class ReturnManager  // Returns content
    {
        private static ContentManager Content;
        private static GraphicsDeviceManager Graphics;
        public ReturnManager(ContentManager content, GraphicsDeviceManager graphics)
        {
            Content = content;
            Graphics = graphics;
        }

        // Screen

        public static int ReturnCenterWidthOfScreen() => Graphics.PreferredBackBufferWidth / 2;
        public static int ReturnCenterHeightOfScreen() => Graphics.PreferredBackBufferHeight / 2;

        // Content
        public static Texture2D LoadTexture(string name) => Content.Load<Texture2D>(name);
        public static SpriteFont LoadSpriteFont(string name) => Content.Load<SpriteFont>(name);
        public static Vector2 ReturnMiddleVector(SpriteFont sprite, string name) => sprite.MeasureString(name);

        public static Texture2D TextureData(int width, int height, Color color, GraphicsDevice device)
        {
            Texture2D rect = new Texture2D(device, width, height);
            Color[] data = new Color[width * height];

            for (int i = 0; i < data.Length; i++) data[i] = color;
            rect.SetData(data);

            return rect;
        }
    }
}
