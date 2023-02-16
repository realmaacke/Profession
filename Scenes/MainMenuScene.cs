using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Profession.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profession.Scenes
{
    public class MainMenuScene : IScenes
    {
        private SpriteBatch spriteBatch;
        private GraphicsDevice device;
        private SpriteFont font;


        private List<Button> Buttons = new List<Button>()
        {
          new Button(new Vector2(ReturnManager.ReturnCenterWidthOfScreen(),ReturnManager.ReturnCenterHeightOfScreen()), "Play", 300, 100, Color.White),
        };

        public MainMenuScene(SpriteBatch spriteBatch, GraphicsDevice device)
        {
            this.spriteBatch = spriteBatch;
            this.device = device;

            font = ReturnManager.LoadSpriteFont("debug_font");
        }

        public void Draw()
        {
            spriteBatch.Begin();

            Buttons.ForEach(e => e.draw(spriteBatch, device));

            spriteBatch.End();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
