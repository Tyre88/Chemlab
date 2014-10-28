using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GameObjects
{
    public class Oxygen : GameObject
    {
        public Oxygen()
            : base()
        {
            base._name = "Oxygen - O";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Oxygen;
            base._textureNumber = 1;

            _emitter.StartColor1 = Color.Blue;
            _emitter.StartColor2 = Color.Blue;
            _emitter.EndColor1 = Color.Blue;
            _emitter.EndColor2 = Color.Blue;
        }

        public Oxygen(Vector2 position, int textureNumber)
            : base(position)
        {
            base._name = "Oxygen - O";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Oxygen;

            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.Blue;
            _emitter.StartColor2 = Color.Blue;
            _emitter.EndColor1 = Color.Blue;
            _emitter.EndColor2 = Color.Blue;
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
