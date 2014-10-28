using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GUI
{
    public class Dialog
    {
        public delegate void FinishedLoadingEvent();
        public delegate void ShowDialogEvent();

        private Vector2 _position;
        private Texture2D _backgroundTexture, _talkerTexture;
        private SpriteFont _font;
        private string _text;
        private int _tileSize;
        private int _padding;
        private bool _showBackgroundTexture;

        public int TimeToShow { get; set; }

        public bool ShowBackgroundTexture
        {
            get { return _showBackgroundTexture; }
            set { _showBackgroundTexture = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Name { get; set; }

        private bool _active, _hasBeenActive;

        private int _activeTime;

        private float _timer;

        public event FinishedLoadingEvent Finish;
        public event ShowDialogEvent ShowDialog;

        public bool Active
        {
            get { return _active; }
        }

        public Dialog(Vector2 position, Texture2D background, Texture2D talker, SpriteFont font, string text, int tileSize, int activeTime)
        {
            _position = position;
            _backgroundTexture = background;
            _talkerTexture = talker;
            _font = font;
            _text = text;
            _tileSize = tileSize;
            _activeTime = activeTime;

            _active = false;
            _padding = 20;
            _showBackgroundTexture = false;
            _hasBeenActive = false;
        }

        public void Show()
        {
            _active = true;
            _hasBeenActive = true;
            _timer = 0;

            if (ShowDialog != null)
            {
                ShowDialog();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (_active)
            {
                _timer += gameTime.ElapsedGameTime.Milliseconds / 2;

                if (_timer > _activeTime)
                {
                    _active = false;
                    if (Finish != null)
                    {
                        Finish();
                    }
                }
            }
        }

        public void Update(GameTime gameTime, float timeOnLevel)
        {
            if (_active)
            {
                _timer += gameTime.ElapsedGameTime.Milliseconds / 2;

                if (_timer > _activeTime)
                {
                    _active = false;
                    if (Finish != null)
                    {
                        Finish();
                    }
                }
            }
            else if(!_hasBeenActive && TimeToShow >= 0)
            {
                if (timeOnLevel > TimeToShow)
                {
                    this.Show();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_active)
            {
                spriteBatch.Begin();
                if (_showBackgroundTexture)
                {
                    spriteBatch.Draw(_backgroundTexture, _position, Color.White);
                }
                spriteBatch.Draw(_talkerTexture, new Vector2(_position.X + _padding, _position.Y + _padding), Color.White);
                if (!string.IsNullOrEmpty(Name))
                {
                    spriteBatch.DrawString(_font, string.Format("{0} says:", Name), new Vector2(_position.X + _talkerTexture.Width + _padding, _position.Y + _padding), Color.Red, 0, Vector2.Zero, 1.2f, SpriteEffects.None, 0);
                }
                spriteBatch.DrawString(_font, ParseText(_text), new Vector2(_position.X + _talkerTexture.Width + _padding, _position.Y + _padding + 20), Color.White);
                spriteBatch.End();
            }
        }

        private string ParseText(string text)
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                if (_font.MeasureString(line + word).Length() > (_backgroundTexture.Width - _talkerTexture.Width - (_padding * 2)))
                {
                    returnString = string.Format("{0} {1} \n", returnString, line);
                    line = string.Empty;
                }

                line = string.Format("{0} {1} ", line, word);
            }

            return string.Format("{0} {1}", returnString, line);
        }

        private void DrawColorFormattedText(SpriteBatch spriteBatch, SpriteFont font, Vector2 position, string text)
        {
            Color defaultColor = Color.White;

            // only bother if we have color commands involved
            if (text.Contains("[color:"))
            {
                // how far in x to offset from position
                int currentOffset = 0;

                // example: 
                // string.Format("You attempt to hit the [color:#FFFF0000]{0}[/color] but [color:{1}]MISS[/color]!", 
                // currentMonster.Name, Color.Red.ToHex(true));
                string[] splits = text.Split(new string[] { "[color:" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var str in splits)
                {
                    // if this section starts with a color
                    if (str.StartsWith("#"))
                    {
                        // #AARRGGBB
                        // #FFFFFFFFF
                        // #123456789
                        string color = str.Substring(0, 9);
                        
                        // any subsequent msgs after the [/color] tag are defaultColor
                        string[] msgs = str.Substring(10).Split(new string[] { "[/color]" }, StringSplitOptions.RemoveEmptyEntries);
                        
                        // always draw [0] there should be at least one
                        spriteBatch.DrawString(font, msgs[0], position + new Vector2(currentOffset, 0), Helpers.ColorHelper.ToColor(color));
                        currentOffset += (int)font.MeasureString(msgs[0]).X;
                        
                        // there should only ever be one other string or none
                        if (msgs.Length == 2)
                        {
                            spriteBatch.DrawString(font, msgs[1], position + new Vector2(currentOffset, 0), defaultColor);
                            currentOffset += (int)font.MeasureString(msgs[1]).X;
                        }
                    }
                    else
                    {
                        spriteBatch.DrawString(font, str, position + new Vector2(currentOffset, 0), defaultColor);
                        currentOffset += (int)font.MeasureString(str).X;
                    }
                }
            }
            else
            {
                // just draw the string as ordered
                spriteBatch.DrawString(font, text, position, defaultColor);
            }
        }
    }
}
