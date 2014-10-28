using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GUI
{
    public class Text
    {
        private Vector2 _position;
        private SpriteFont _font;
        private string _text;
        private string _name;
        private Color _color;

        private int _width;

        public string ActiveText
        {
            get { return _text; }
            set { _text = value; }
        }

        public Text(Vector2 position, SpriteFont font, string text, string name, Color color)
        {
            _position = position;
            _font = font;
            _text = text;
            _name = name;
            _color = color;

            _width = 250;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Update(GameTime gameTime, List<GameObjects.GameObject> gameObjects)
        {
            GameObjects.GameObject obj = gameObjects.Find(g => g.Selected);

            if (obj != null)
            {
                switch (_name)
                {
                    case "Target":
                        _text = obj.Name;
                        break;
                    case "Count":
                        _text = obj.Count.ToString();
                        break;
                    case "Type":
                        _text = obj.Type;
                        break;
                    case "Goal":
                        _text = Engine._currentLevel.Goal;
                        break;
                    default:
                        _text = string.Empty;
                        break;
                }
                
            }
            else
            {
                switch (_name)
                {
                    case "Goal":
                        _text = Engine._currentLevel.Goal;
                        break;
                    case "Next Level":
                        break;
                    case "Finish Level count":
                        break;
                    default:
                        _text = string.Empty;
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(_font, ParseText(string.Format("{0}: {1}", _name, _text)), _position, _color);
            spriteBatch.End();
        }

        private string ParseText(string text)
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                if (_font.MeasureString(line + word).Length() > (_width))
                {
                    returnString = string.Format("{0} {1} \n", returnString, line);
                    line = string.Empty;
                }

                line = string.Format("{0} {1} ", line, word);
            }

            return string.Format("{0} {1}", returnString, line);
        }
    }
}
