using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GameObjects
{
    public class Carbon : GameObject
    {
        public Carbon()
            : base()
        {
            base._name = "Carbon - C";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Carbon;
            base._textureNumber = 2;

            _emitter.StartColor1 = Color.DarkGray;
            _emitter.StartColor2 = Color.DarkGray;
            _emitter.EndColor1 = Color.DarkGray;
            _emitter.EndColor2 = Color.DarkGray;
        }

        public Carbon(Vector2 position, int textureNumber)
            : base(position)
        {
            base._name = "Carbon - C";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Carbon;
            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.DarkGray;
            _emitter.StartColor2 = Color.DarkGray;
            _emitter.EndColor1 = Color.DarkGray;
            _emitter.EndColor2 = Color.DarkGray;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
