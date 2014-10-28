using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ChemEngine.Editor.Buttons
{
    class SaveButton : Button
    {
        public SaveButton(Texture2D texture, Vector2 position)
            : base(texture, position)
        {

        }

        public override void Update(GameTime gameTime, Input.Mouse mouse)
        {
            base.Update(gameTime, mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
