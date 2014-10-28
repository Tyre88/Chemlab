using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.GameObjects
{
    public class CarbonMonoxide : GameObject
    {
        public CarbonMonoxide()
            : base()
        {
            base._name = "Carbon monoxide - CO";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.CarbonMonoxide;

            base._textureNumber = 6;

            _emitter.StartColor1 = Color.LightGray;
            _emitter.StartColor2 = Color.WhiteSmoke;
            _emitter.EndColor1 = Color.LightGray;
            _emitter.EndColor2 = Color.WhiteSmoke;
        }

        public CarbonMonoxide(Vector2 position, int textureNumber)
            : base(position)
        {
            base._name = "Carbon monoxide - CO";
            base._type = ObjectType.Gas.ToString();
            base._gameObjectType = GameObjects.GameObjectType.CarbonMonoxide;

            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.LightGray;
            _emitter.StartColor2 = Color.WhiteSmoke;
            _emitter.EndColor1 = Color.LightGray;
            _emitter.EndColor2 = Color.WhiteSmoke;
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
