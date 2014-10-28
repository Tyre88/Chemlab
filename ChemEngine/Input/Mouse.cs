using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ChemEngine.Input
{
    public class Mouse
    {
        private Vector2 _position;

        MouseState _ms;

        public ButtonState PreviousMouseState { get; set; }

        public Vector2 Position
        {
            get { return _position; }
        }

        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, 0, 0);
            }
        }

        public MouseState MS
        {
            get { return _ms; }
        }

        public Mouse()
        {
            _position = new Vector2();
        }

        public void Update(GameTime gameTime)
        {
            _ms = Microsoft.Xna.Framework.Input.Mouse.GetState();

            _position.X = _ms.X;
            _position.Y = _ms.Y;
        }
    }
}
