using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ChemEngine.GameObjects
{
    public class CarbonDioxide : GameObject
    {
        public CarbonDioxide()
            : base()
        {
            base._name = "Carbon dioxide - CO2";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.CarbonDioxide;

            base._textureNumber = 5;

            _emitter.StartColor1 = Color.DarkGray;
            _emitter.StartColor2 = Color.Black;
            _emitter.EndColor1 = Color.DarkGray;
            _emitter.EndColor2 = Color.Black;
        }

        public CarbonDioxide(Vector2 position, int textureNumber)
            : base(position)
        {
            base._name = "Carbon dioxide - CO2";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.CarbonDioxide;

            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.DarkGray;
            _emitter.StartColor2 = Color.Black;
            _emitter.EndColor1 = Color.DarkGray;
            _emitter.EndColor2 = Color.Black;
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
