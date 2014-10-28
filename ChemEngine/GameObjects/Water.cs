using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ParticleEngine;

namespace ChemEngine.GameObjects
{
    public class Water : GameObject
    {
        public Water()
            : base()
        {
            base._name = "Water - H20";
            base._type = ObjectType.Fluid.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Water;

            base._textureNumber = 4;

            _emitter.StartColor1 = Color.Blue;
            _emitter.StartColor2 = Color.WhiteSmoke;
            _emitter.EndColor1 = Color.Blue;
            _emitter.EndColor2 = Color.WhiteSmoke;
        }

        public Water(Vector2 position, int textureNumber)
            : base(position)
        {
            base._name = "Water - H20";
            base._type = ObjectType.Fluid.ToString();
            base._gameObjectType = GameObjects.GameObjectType.Water;

            base._textureNumber = textureNumber;

            _emitter.StartColor1 = Color.Blue;
            _emitter.StartColor2 = Color.WhiteSmoke;
            _emitter.EndColor1 = Color.Blue;
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
