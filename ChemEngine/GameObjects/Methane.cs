using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GameObjects
{
    public class Methane : GameObject
    {
        public Methane()
            : base()
        {
            base._name = "Methane - CH4";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Methane;

            base._textureNumber = 3;

            _emitter.StartColor1 = Color.Green;
            _emitter.StartColor2 = Color.LightGreen;
            _emitter.EndColor1 = Color.Green;
            _emitter.EndColor2 = Color.LightGreen;
        }

        public Methane(Vector2 position, int textureNumber)
            : base(position)
        {
            base._name = "Methane - CH4";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Methane;

            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.Green;
            _emitter.StartColor2 = Color.LightGreen;
            _emitter.EndColor1 = Color.Green;
            _emitter.EndColor2 = Color.LightGreen;
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
