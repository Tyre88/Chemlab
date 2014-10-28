using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ChemEngine.Input;
using Microsoft.Xna.Framework.Input;

namespace ChemEngine.Editor.Buttons
{
    class Button
    {
        public delegate void IntersectEvent();

        protected ButtonState _lastMouseState;
        private bool _intersecting;
        protected Texture2D _texture;
        protected Vector2 _position;

        public event IntersectEvent Intersect;

        protected Rectangle Rect
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public Button()
        {
        }

        public Button(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        public virtual void Update(GameTime gameTime, ChemEngine.Input.Mouse mouse)
        {
            if (mouse.MS.LeftButton == ButtonState.Pressed)
            {
                if (mouse.Rect.Intersects(this.Rect) && mouse.MS.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && _lastMouseState == Microsoft.Xna.Framework.Input.ButtonState.Released)
                {
                    _lastMouseState = Microsoft.Xna.Framework.Input.ButtonState.Pressed;
                    if (Intersect != null)
                    {
                        _intersecting = true;
                        Intersect();
                    }
                }

                _lastMouseState = Microsoft.Xna.Framework.Input.ButtonState.Pressed;
            }
            else if (mouse.MS.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                _intersecting = false;
                _lastMouseState = Microsoft.Xna.Framework.Input.ButtonState.Released;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (_intersecting)
            {
                spriteBatch.Draw(_texture, _position, Color.Yellow);
            }
            else
            {
                spriteBatch.Draw(_texture, _position, Color.White);
            }
            spriteBatch.End();
        }
    }
}
