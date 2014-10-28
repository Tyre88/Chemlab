using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChemEngine.GUI
{
    public class Cursor : Image
    {
        MouseState _ms;

        public Cursor(Vector2 position, Texture2D texture)
            : base(position, texture)
        {
            _ms = new MouseState();
        }

        public override void Update(GameTime gameTime)
        {
            _ms = Mouse.GetState();
            _position = new Vector2(_ms.X, _ms.Y);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
