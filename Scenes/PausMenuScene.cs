using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profession.Scenes
{
    public class PausMenuScene : IScenes
    {
        private SpriteBatch spriteBatch;
        private GraphicsDevice device;
        private SpriteFont font;
        public PausMenuScene(SpriteBatch spriteBatch, GraphicsDevice device)
        {
            this.spriteBatch = spriteBatch;
            this.device = device;

            font = ReturnManager.LoadSpriteFont("debug_font");
        }

        public void Draw()
        {
            spriteBatch.Begin();


            spriteBatch.DrawString(font, "Pause Menu", new Vector2(200, 200), Color.White);

            spriteBatch.End();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
