using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ChemEngine.GameObjects
{
    class Lithium : GameObject
    {
        public Lithium()
            : base()
        {
            base._name = "Lithium - Li";
            base._type = ObjectType.Solid.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Lithium;

            base._textureNumber = 0;

            _emitter.StartColor1 = Color.Silver;
            _emitter.StartColor2 = Color.Silver;
            _emitter.EndColor1 = Color.Silver;
            _emitter.EndColor2 = Color.Silver;
        }

        public Lithium(Vector2 position, int textureNumber)
            : base(position)
        {
            base._name = "Lithium - Li";
            base._type = ObjectType.Solid.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Lithium;

            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.Silver;
            _emitter.StartColor2 = Color.Silver;
            _emitter.EndColor1 = Color.Silver;
            _emitter.EndColor2 = Color.Silver;
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
