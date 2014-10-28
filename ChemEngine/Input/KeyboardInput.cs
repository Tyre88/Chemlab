using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ChemEngine.Input
{
    public class KeyboardInput
    {
        public delegate void EmptyEvent();

        private Keys _lastState;
        private float _timer;
        private bool _isEditing;

        public event EmptyEvent Escape;
        public event EmptyEvent Delete;
        public event EmptyEvent SaveLevel;

        public KeyboardState State { get; set; }
        public bool IsEditing
        {
            get { return _isEditing; }
            set { _isEditing = value; }
        }

        public KeyboardInput()
        {
            _lastState = Keys.None;
            State = new KeyboardState();
        }

        public void Update(GameTime gameTime)
        {
            State = Keyboard.GetState();

            if (_lastState != Keys.None)
            {
                _timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            }

            if (State.IsKeyDown(Keys.F12) && _lastState != Keys.F12 && _isEditing)
            {
                _lastState = Keys.F12;

                SaveLevel();
            }
            else if (State.IsKeyDown(Keys.Escape) && _lastState != Keys.Escape)
            {
                _lastState = Keys.Escape;
                Engine.SingleTon.DeselectAll();
                Escape();
            }
            else if (State.IsKeyDown(Keys.Delete) && _lastState != Keys.Delete)
            {
                Delete();
            }

            if (_lastState != Keys.None && _timer > 300)
            {
                _lastState = Keys.None;
                _timer = 0;
            }
        }
    }
}
