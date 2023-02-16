using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profession.Widgets
{
    public class Button
    {
        private Vector2 position;
        private string text;
        private int sizeX, sizeY;
        private Color color;
        private SpriteFont font;


        public Button(Vector2 position, string text, int width, int height, Color color)
        {
            this.position = position;
            this.text = text;
            this.sizeX = width;
            this.sizeY = height;
            this.color = color;

            font = ReturnManager.LoadSpriteFont("debug_font");
        }

        public void draw(SpriteBatch spriteBatch, GraphicsDevice device)
        {
            var rect = ReturnManager.TextureData(sizeX, sizeY, color, device);

            spriteBatch.Draw(rect, new Vector2(position.X - sizeX / 2, position.Y - sizeY / 2), Color.White);
            spriteBatch.DrawString(font, text, ReturnManager.ReturnMiddleVector(font, text), Color.Black);

        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
