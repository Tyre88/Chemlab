using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GameObjects
{
    public class Hydrogen : GameObject
    {
        public Hydrogen()
            : base()
        {
            base._name = "Hydrogen - H";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Hydrogen;

            base._textureNumber = 0;

            _emitter.StartColor1 = Color.Tan;
            _emitter.StartColor2 = Color.Tan;
            _emitter.EndColor1 = Color.Tan;
            _emitter.EndColor2 = Color.Tan;
        }

        public Hydrogen(Vector2 position, int textureNumber) :
            base(position)
        {
            base._name = "Hydrogen - H";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Hydrogen;

            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.Tan;
            _emitter.StartColor2 = Color.Tan;
            _emitter.EndColor1 = Color.Tan;
            _emitter.EndColor2 = Color.Tan;
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
