using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChemEngine.GameObjects;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using ChemEngine.GUI;
using ChemEngine.Structs;
using System.Threading;

namespace ChemEngine.Level
{
    public class Level
    {
        private StorageDevice device;

        private string _nextLevel;

        public delegate void FinishLevelArgs(Level level);

        protected List<GameObject> _gameObjects;
        protected float _timeOnLevel;

        protected const int _dialogTimer = 4000;

        protected List<FinishLevel> _finishLevelList;

        public event FinishLevelArgs Finish;

        public float TimeOnLevel
        {
            get { return _timeOnLevel; }
        }

        public bool Done { get; set; }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        public string Goal { get; set; }

        public Level()
        {
            _gameObjects = new List<GameObject>();
            _finishLevelList = new List<FinishLevel>();
        }

        public virtual void Update(GameTime gameTime)
        {
            _timeOnLevel += gameTime.ElapsedGameTime.Milliseconds / 2;

            _finishLevelList.FindAll(a => !a.IsDone && _gameObjects.Count(g => g.GameObjectType == a.GameObjectType) >= a.CountToDone).ForEach(a => a.IsDone = true);

            if (_finishLevelList.Count(a => !a.IsDone) == 0)
            {
                if (Finish != null)
                {
                    FinishLevel();
                }
            }

            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }

        public void Dispose()
        {
            GameObjects.Clear();
            Finish = null;
        }

        protected void FinishLevel()
        {
            InitLevel(_nextLevel);
        }

        protected void InitLevel(string levelName)
        {
            _gameObjects = new List<GameObject>();
            Structs.LevelStruct level;

            using (FileStream stream = new FileStream(levelName + ".level", FileMode.Open))
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    level = IntermediateSerializer.Deserialize<Structs.LevelStruct>(reader, null);
                }
            }

            foreach (var item in level._gameObjects)
            {
                switch (item._gameObjectType)
                {
                    case GameObjectType.Carbon:
                        _gameObjects.Add(new Carbon
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                    case GameObjectType.CarbonDioxide:
                        _gameObjects.Add(new CarbonDioxide
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                    case GameObjectType.CarbonMonoxide:
                        _gameObjects.Add(new CarbonMonoxide
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                    case GameObjectType.Hydrogen:
                        _gameObjects.Add(new Hydrogen
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                    case GameObjectType.Methane:
                        _gameObjects.Add(new Methane
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                    case GameObjectType.Oxygen:
                        _gameObjects.Add(new Oxygen
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                    case GameObjectType.Water:
                        _gameObjects.Add(new Water
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                    case GameObjectType.Lithium:
                        _gameObjects.Add(new Lithium
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                    default:
                        _gameObjects.Add(new GameObject
                        {
                            Count = item._count,
                            GameObjectType = item._gameObjectType,
                            Name = item._name,
                            Position = item._position,
                            Type = item._type
                        });
                        break;
                }

                //Thread.Sleep(10);
            }
            Goal = level._goal;
            _finishLevelList = level._finishLevel;
            _nextLevel = level._nextLevel;
        }
    }
}
