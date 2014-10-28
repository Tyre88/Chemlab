using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace ChemEngine.Structs
{
    public struct LevelStruct
    {
        [ContentSerializer(CollectionItemName="GameObjectStruct")]
        public List<GameObjectStruct> _gameObjects;
        public List<FinishLevel> _finishLevel;
        public string _goal;
        public string _dialogText;
        public string _nextLevel;
    }
}
