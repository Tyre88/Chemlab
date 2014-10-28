using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ChemEngine.Level
{
    class BackLayer
    {
        private Texture2D _texture;
        private int _numX, _numY;

        public BackLayer(Texture2D texture, int numX, int numY)
        {
            _texture = texture;
            _numX = numX;
            _numY = numY;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int x = 0; x < _numX; x++)
            {
                for (int y = 0; y < _numY; y++)
                {
                    spriteBatch.Draw(_texture, new Vector2(x * _texture.Width, y * _texture.Height), Color.White);
                }
            }
            spriteBatch.End();
        }
    }
}
