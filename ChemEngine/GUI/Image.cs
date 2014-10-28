using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GUI
{
    public class Image
    {
        protected Vector2 _position;
        protected Texture2D _texture;

        public Image(Vector2 position, Texture2D texture)
        {
            _position = position;
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, _position, Color.White);
            spriteBatch.End();
        }
    }
}
