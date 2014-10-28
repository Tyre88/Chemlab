using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ChemEngine.GameObjects
{
    class Helium : GameObject
    {
        public Helium()
            : base()
        {
            base._name = "Helium - He";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Helium;

            base._textureNumber = 0;

            _emitter.StartColor1 = Color.IndianRed;
            _emitter.StartColor2 = Color.IndianRed;
            _emitter.EndColor1 = Color.IndianRed;
            _emitter.EndColor2 = Color.IndianRed;
        }

        public Helium(Vector2 position, int textureNumber)
            : base(position)
        {
            base._name = "Helium - He";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Helium;

            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.IndianRed;
            _emitter.StartColor2 = Color.IndianRed;
            _emitter.EndColor1 = Color.IndianRed;
            _emitter.EndColor2 = Color.IndianRed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
