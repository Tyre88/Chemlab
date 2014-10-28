using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GUI
{
    public class GUI
    {
        List<Image> _imageList;
        List<Text> _textList;

        public List<Image> ImageList
        {
            get { return _imageList; }
            set { _imageList = value; }
        }

        public List<Text> TextList
        {
            get { return _textList; }
            set { _textList = value; }
        }

        public GUI()
        {
            _imageList = new List<Image>();
            _textList = new List<Text>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Image image in _imageList)
            {
                image.Update(gameTime);
            }

            foreach (Text text in _textList)
            {
                text.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Image image in _imageList)
            {
                image.Draw(spriteBatch);
            }

            foreach (Text text in _textList)
            {
                text.Draw(spriteBatch);
            }
        }
    }
}
