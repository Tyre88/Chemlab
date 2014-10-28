using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using ParticleEngine;

namespace ChemEngine.GameObjects
{
    public enum ObjectType
    {
        Gas,
        Solid,
        Fluid,
    }

    public enum GameObjectType
    {
        Carbon,
        CarbonDioxide,
        CarbonMonoxide,
        Hydrogen,
        Methane,
        Oxygen,
        Water,
        Lithium,
        Helium
    }

    public class GameObject
    {
        protected Vector2 _position;
        protected bool _selected;
        protected int _count;
        protected string _name;
        protected string _type;
        protected GameObjectType _gameObjectType;
        protected Random _random;
        protected ParticleSystem _particleSystem;
        protected Emitter _emitter;

        protected int _textureNumber;

        public Texture2D Texture
        {
            get { return Engine.SingleTon.GameObjectTextureDictionary[_textureNumber]; }
        }

        public GameObjectType GameObjectType
        {
            get { return _gameObjectType; }
            set { _gameObjectType = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Vector2 CenterPosition
        {
            get { return new Vector2(_position.X + (Engine.SingleTon.GameObjectTextureDictionary[_textureNumber].Width / 2), 
                _position.Y + (Engine.SingleTon.GameObjectTextureDictionary[_textureNumber].Height / 2)); }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public GameObject()
        {
            Count = 1;
            _textureNumber = -1;
            _random = new Random();
            _particleSystem = new ParticleSystem(new Vector2(0, 0));

            _emitter = new ParticleEngine.Emitter(new Vector2(0.1f, 0.15f),
                new Vector2(1, 1),
                new Vector2(1f * MathHelper.Pi, 1f * -MathHelper.Pi),
                new Vector2(1, 1),
                new Vector2(25, 25),
                new Vector2(8, 8),
                Color.White,
                Color.White,
                Color.White,
                Color.White,
                new Vector2(20, 20),
                new Vector2(0, 0),
                10,
                new Vector2(300, 300),
                Engine._particleTexture,
                _random,
                _particleSystem,
                true);

            _particleSystem.AddEmitter(_emitter);
        }

        public GameObject(Vector2 position)
        {
            _position = position;

            Count = 1;

            _random = new Random();
            _particleSystem = new ParticleSystem(new Vector2(0, 0));

            _emitter = new ParticleEngine.Emitter(new Vector2(0.1f, 0.15f),
                new Vector2(1, 1),
                new Vector2(1f * MathHelper.Pi, 1f * -MathHelper.Pi),
                new Vector2(1, 1),
                new Vector2(25, 25),
                new Vector2(8, 8),
                Color.White,
                Color.White,
                Color.White,
                Color.White,
                new Vector2(20, 20),
                new Vector2(0, 0),
                10,
                new Vector2(300, 300),
                Engine._particleTexture,
                _random,
                _particleSystem,
                true);

            _particleSystem.AddEmitter(_emitter);
        }

        public virtual void Update(GameTime gameTime)
        {
            _emitter.RelPosition = CenterPosition;
            _particleSystem.Update(gameTime.ElapsedGameTime.Milliseconds / 1000f);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (Selected)
            {
                spriteBatch.Draw(Engine.SingleTon.GameObjectTextureDictionary[_textureNumber], _position, null, Color.Yellow, 0f, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(Engine.SingleTon.GameObjectTextureDictionary[_textureNumber], _position, Color.White);
            }
            spriteBatch.End();

            _particleSystem.Draw(spriteBatch, 1, Vector2.Zero);
        }
    }
}
