using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ChemEngine.GameObjects;
using Microsoft.Xna.Framework.Graphics;

namespace ChemEngine.Structs
{
    [Serializable]
    public struct GameObjectStruct
    {
        public Vector2 _position;
        public bool _selected;
        public int _count;
        public string _name;
        public string _type;
        public GameObjectType _gameObjectType;
        //public int _texture;
    }
}
