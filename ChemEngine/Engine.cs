using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChemEngine.Level;
using Microsoft.Xna.Framework.Content;
using ChemEngine.GameObjects;
using ChemEngine.Input;
using Microsoft.Xna.Framework.Input;
using ChemEngine.GUI;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using ChemEngine.Editor;
using ChemEngine.Structs;
using ParticleEngine;

namespace ChemEngine
{
    public enum CurrentLevel
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    public enum GameState
    {
        PLAY,
        PAUSE,
        DIALOG,
        MENU,
        DEAD,
        DIALOGANDPLAY,
        EDIT
    }

    public class Engine
    {
        static Random _random;

        private static Engine _singleTon;

        static ParticleSystem _particleSystem;
        public static Texture2D _particleTexture;

        private KeyboardInput _keyboardInput;

        private const int numX = 15;
        private const int numY = 10;
        private BackLayer _backLayer;
        private Texture2D _backLayerTexture;

        public static CurrentLevel currentLevel;
        public static GameState gameState;

        private Level.Level _level1, _level2;
        public static Level.Level _currentLevel;
        private ChemEngine.Input.Mouse mouse;
        CollisionDetection detection;

        Dialog _level1Dialog, _level2Dialog;
        static Dialog _noobDialog;
        List<Dialog> _dialogList;

        public List<Dialog> DialogList
        {
            get { return _dialogList; }
            set { _dialogList = value; }
        }

        SpriteFont _baseFont;

        GUI.GUI _gui, _editGUI;
        GUI.Cursor _cursor;

        Text _targetText, _countText, _goalText, _typeText;

        private Dictionary<int, Texture2D> _gameObjectTextureDictionary;

        public Dictionary<int, Texture2D> GameObjectTextureDictionary
        {
            get
            {
                return _gameObjectTextureDictionary;
            }
        }

        private Dictionary<int, Texture2D> _buttonTextureDictionary;

        public Dictionary<int, Texture2D> ButtonTextureDictionary
        {
            get { return _buttonTextureDictionary; }
        }

        public KeyboardInput KeyboardInput
        {
            get { return _keyboardInput; }
            set { _keyboardInput = value; }
        }

        public SpriteFont BaseFont
        {
            get { return _baseFont; }
        }

        public static Engine SingleTon
        {
            get
            {
                if (_singleTon == null)
                {
                    _singleTon = new Engine();
                }

                return _singleTon;
            }
        }

        #region GameObjects
        private Texture2D _hydrogenTexture, _oxygenTexture, _crossTexture, _carbonTexture;
        private static Texture2D _waterTexture, _methaneTexture, _carbonDioxideTexture, _carbonMonoxideTexture;
        private Texture2D _dialogBackgroundTexture, _rightBackgroundTexture;
        private Texture2D _head1;
        private Texture2D _cursorTexture;

        public Texture2D DialogBackgroundTexture
        {
            get { return _dialogBackgroundTexture; }
        }

        public Texture2D Head1
        {
            get { return _head1; }
        }
        #endregion

        #region Editor
        LevelEditor _editor;
        #endregion

        private Engine()
        {
            mouse = new ChemEngine.Input.Mouse();
            detection = new CollisionDetection();
            gameState = GameState.DIALOG;
            _gui = new GUI.GUI();
            _editGUI = new GUI.GUI();
            _dialogList = new List<Dialog>();
            _gameObjectTextureDictionary = new Dictionary<int, Texture2D>();
            _buttonTextureDictionary = new Dictionary<int, Texture2D>();
            _keyboardInput = new KeyboardInput();
        }

        void _level1_Finish(Level.Level level)
        {
            InitLevel2();
        }

        public void Initialize()
        {
            _random = new Random();

            _particleSystem = new ParticleSystem(new Vector2(0, 0));

            _editor = new LevelEditor();

            _currentLevel = new Level.Level();

            _backLayer = new BackLayer(_backLayerTexture, numX, numY);
            currentLevel = CurrentLevel.Level1;
            InitLevel1();

            _cursor = new Cursor(Vector2.Zero, _cursorTexture);

            _gui.ImageList.Add(new Image(new Vector2(480, 0), _rightBackgroundTexture));
            _gui.ImageList.Add(new Image(new Vector2(0, 320), _dialogBackgroundTexture));

            _editGUI.ImageList.Add(new Image(new Vector2(480, 0), _rightBackgroundTexture));
            _editGUI.ImageList.Add(new Image(new Vector2(0, 320), _dialogBackgroundTexture));

            _targetText = new Text(new Vector2(510, 25), _baseFont, "", "Target", Color.Red);
            _gui.TextList.Add(_targetText);

            _countText = new Text(new Vector2(510, 50), _baseFont, "", "Count", Color.Red);
            _gui.TextList.Add(_countText);

            _typeText = new Text(new Vector2(510, 75), _baseFont, "", "Type", Color.Red);
            _gui.TextList.Add(_typeText);

            _goalText = new Text(new Vector2(510, 350), _baseFont, "", "Goal", Color.Red);
            _gui.TextList.Add(_goalText);

            gameState = GameState.PLAY;
        }

        private void InitLevel1()
        {
            _level1 = new Level.Level1();
            _level1.Finish += new Level.Level.FinishLevelArgs(_level1_Finish);

            _currentLevel = _level1;
        }

        public void Dialog_Finish()
        {
            gameState = GameState.PLAY;
        }

        public void Dialog_Show()
        {
            gameState = GameState.DIALOG;
        }

        public void Dialog_Show_Play()
        {
            gameState = GameState.DIALOGANDPLAY;
        }

        private void InitLevel2()
        {
            _level1.Dispose();

            _level2 = new Level.Level2();
            _level2.Finish += new Level.Level.FinishLevelArgs(_level2_Finish);

            currentLevel = CurrentLevel.Level2;

            _currentLevel = _level2;
        }

        void _level2_Finish(Level.Level level)
        {
            _level2.Dispose();

            Level3 level3 = new Level3();

            currentLevel = CurrentLevel.Level3;

            _currentLevel = level3;
        }

        public void LoadContent(ContentManager Content)
        {
            _backLayerTexture = Content.Load<Texture2D>(@"SingleTiles/BackTile2");
            _hydrogenTexture = Content.Load<Texture2D>(@"SingleTiles/H");
            _oxygenTexture = Content.Load<Texture2D>(@"SingleTiles/O");
            _crossTexture = Content.Load<Texture2D>(@"SingleTiles/Cross");
            _carbonTexture = Content.Load<Texture2D>(@"SingleTiles/C");

            _methaneTexture = Content.Load<Texture2D>(@"SingleTiles/Methane");
            _waterTexture = Content.Load<Texture2D>(@"SingleTiles/H2O");
            _carbonDioxideTexture = Content.Load<Texture2D>(@"SingleTiles/CO2");
            _carbonMonoxideTexture = Content.Load<Texture2D>(@"SingleTiles/CO");

            _dialogBackgroundTexture = Content.Load<Texture2D>(@"SingleTiles/Background2");
            _rightBackgroundTexture = Content.Load<Texture2D>(@"GUI/RightBackground");

            _head1 = Content.Load<Texture2D>(@"SingleTiles/Head1");

            _cursorTexture = Content.Load<Texture2D>(@"GUI/Cursor");

            _baseFont = Content.Load<SpriteFont>(@"Font/BaseFont");

            _particleTexture = Content.Load<Texture2D>(@"Particle");

            Texture2D empty = Content.Load<Texture2D>(@"SingleTiles/EmptyObject");

            //_gameObjectTextureDictionary.Add(-1, _crossTexture);
            //_gameObjectTextureDictionary.Add(0, _hydrogenTexture);
            //_gameObjectTextureDictionary.Add(1, _oxygenTexture);
            //_gameObjectTextureDictionary.Add(2, _carbonTexture);
            //_gameObjectTextureDictionary.Add(3, _methaneTexture);
            //_gameObjectTextureDictionary.Add(4, _waterTexture);
            //_gameObjectTextureDictionary.Add(5, _carbonDioxideTexture);
            //_gameObjectTextureDictionary.Add(6, _carbonMonoxideTexture);

            _gameObjectTextureDictionary.Add(-1, empty);
            _gameObjectTextureDictionary.Add(0, empty);
            _gameObjectTextureDictionary.Add(1, empty);
            _gameObjectTextureDictionary.Add(2, empty);
            _gameObjectTextureDictionary.Add(3, empty);
            _gameObjectTextureDictionary.Add(4, empty);
            _gameObjectTextureDictionary.Add(5, empty);
            _gameObjectTextureDictionary.Add(6, empty);


            _buttonTextureDictionary.Add(0, Content.Load<Texture2D>(@"GUI/Buttons/SaveButton"));
            _buttonTextureDictionary.Add(1, Content.Load<Texture2D>(@"GUI/Buttons/FinishConditionButton"));
            _buttonTextureDictionary.Add(2, Content.Load<Texture2D>(@"GUI/Buttons/NextLevelButton"));
        }

        public void Update(GameTime gameTime)
        {
            _backLayer.Update(gameTime);
            _cursor.Update(gameTime);
            _particleSystem.Update(gameTime.ElapsedGameTime.Milliseconds / 1000f);

            if (gameState != GameState.MENU)
            {
                _gui.Update(gameTime);
                _currentLevel.Update(gameTime);

                foreach (Text text in _gui.TextList)
                {
                    text.Update(gameTime, _currentLevel.GameObjects);
                }
            }

            if (gameState != GameState.DIALOG)
            {
                mouse.Update(gameTime);
            }

            if (gameState == GameState.DIALOG || gameState == GameState.DIALOGANDPLAY)
            {
                _dialogList.ForEach(u => u.Update(gameTime, _currentLevel.TimeOnLevel));
            }

            if (gameState == GameState.PLAY || gameState == GameState.DIALOGANDPLAY)
            {
                detection.Update(gameTime, _currentLevel.GameObjects, mouse);
            }
            else if (gameState == GameState.EDIT)
            {
                _editor.Update(gameTime, mouse);
            }

            _keyboardInput.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _backLayer.Draw(spriteBatch);

            if (gameState != GameState.MENU && gameState != GameState.EDIT)
            {
                _gui.Draw(spriteBatch);
                _currentLevel.Draw(spriteBatch);
            }
            else if (gameState == GameState.EDIT)
            {
                _editGUI.Draw(spriteBatch);
            }

            if (gameState == GameState.DIALOG || gameState == GameState.DIALOGANDPLAY)
            {
                _dialogList.FindAll(a => a.Active).ForEach(u => u.Draw(spriteBatch));
            }

            if (gameState == GameState.EDIT)
            {
                _editor.Draw(spriteBatch);
            }

            _particleSystem.Draw(spriteBatch, 1, Vector2.Zero);
            _cursor.Draw(spriteBatch);
        }

        public static void Mixture(GameObject obj1, GameObject obj2, List<GameObject> objList)
        {
            if (obj1.GetType() == obj2.GetType())
            {
                obj2.Count += obj1.Count;
                objList.Remove(obj1);
            }
                //Water
            else if ((obj1.Count >= 2 && obj1 is Hydrogen && obj2 is Oxygen) ||
                (obj1 is Oxygen && obj2 is Hydrogen && obj2.Count >= 2))
            {
                objList.Add(new Water(new Vector2(obj2.Position.X, obj2.Position.Y), 4));
                objList.Remove(obj1);
                objList.Remove(obj2);

                _particleSystem.AddEmitter(new Vector2(0.001f, 0.0015f),
                    new Vector2(1, 1),
                    new Vector2(1f * MathHelper.Pi, 1f * -MathHelper.Pi),
                    new Vector2((float)_random.NextDouble(), (float)_random.NextDouble()),
                    new Vector2(_random.Next(25, 30), _random.Next(25, 30)),
                    new Vector2(_random.Next(8, 10), _random.Next(8, 10)),
                    Color.Gray,
                    Color.WhiteSmoke,
                    Color.Blue,
                    Color.Blue,
                    new Vector2(40, 40),
                    new Vector2(0, 0),
                    100,
                    new Vector2(obj2.Position.X + (obj2.Texture.Width / 2), obj2.Position.Y + (obj2.Texture.Height / 2)),
                    _particleTexture,
                    false);
            }
                //Methane
            else if ((obj1.Count >= 4 && obj1 is Hydrogen && obj2 is Carbon) ||
                obj1 is Carbon && obj2 is Hydrogen && obj2.Count >= 4)
            {
                objList.Add(new Methane(new Vector2(obj2.Position.X, obj2.Position.Y), 3));
                objList.Remove(obj1);
                objList.Remove(obj2);

                _particleSystem.AddEmitter(new Vector2(0.001f, 0.0015f),
                    new Vector2(1, 1),
                    new Vector2(1f * MathHelper.Pi, 1f * -MathHelper.Pi),
                    new Vector2((float)_random.NextDouble(), (float)_random.NextDouble()),
                    new Vector2(_random.Next(25, 30), _random.Next(25, 30)),
                    new Vector2(_random.Next(8, 10), _random.Next(8, 10)),
                    Color.Green,
                    Color.WhiteSmoke,
                    Color.Green,
                    Color.DarkGreen,
                    new Vector2(40, 40),
                    new Vector2(0, 0),
                    100,
                    new Vector2(obj2.Position.X + (obj2.Texture.Width / 2), obj2.Position.Y + (obj2.Texture.Height / 2)),
                    _particleTexture,
                    false);
            }
                //Carbon dioxide
            else if ((obj1.Count >= 2 && obj1 is Oxygen && obj2 is Carbon) ||
                (obj1 is Carbon && obj2 is Oxygen && obj2.Count >= 2))
            {
                objList.Add(new CarbonDioxide(new Vector2(obj2.Position.X, obj2.Position.Y), 5));
                objList.Remove(obj1);
                objList.Remove(obj2);

                _particleSystem.AddEmitter(new Vector2(0.001f, 0.0015f),
                    new Vector2(1, 1),
                    new Vector2(1f * MathHelper.Pi, 1f * -MathHelper.Pi),
                    new Vector2((float)_random.NextDouble(), (float)_random.NextDouble()),
                    new Vector2(_random.Next(25, 30), _random.Next(25, 30)),
                    new Vector2(_random.Next(8, 10), _random.Next(8, 10)),
                    Color.DarkGray,
                    Color.Black,
                    Color.DarkGray,
                    Color.Black,
                    new Vector2(40, 40),
                    new Vector2(0, 0),
                    100,
                    new Vector2(obj2.Position.X + (obj2.Texture.Width / 2), obj2.Position.Y + (obj2.Texture.Height / 2)),
                    _particleTexture,
                    false);
            }
                //Carbon monoxide
            else if ((obj1 is Oxygen && obj2 is Carbon) ||
                (obj1 is Carbon && obj2 is Oxygen))
            {
                objList.Add(new CarbonMonoxide(new Vector2(obj2.Position.X, obj2.Position.Y), 6));
                objList.Remove(obj1);
                objList.Remove(obj2);

                _particleSystem.AddEmitter(new Vector2(0.001f, 0.0015f),
                    new Vector2(1, 1),
                    new Vector2(1f * MathHelper.Pi, 1f * -MathHelper.Pi),
                    new Vector2((float)_random.NextDouble(), (float)_random.NextDouble()),
                    new Vector2(_random.Next(25, 30), _random.Next(25, 30)),
                    new Vector2(_random.Next(8, 10), _random.Next(8, 10)),
                    Color.Gray,
                    Color.WhiteSmoke,
                    Color.DarkGray,
                    Color.Black,
                    new Vector2(40, 40),
                    new Vector2(0, 0),
                    100,
                    new Vector2(obj2.Position.X + (obj2.Texture.Width / 2), obj2.Position.Y + (obj2.Texture.Height / 2)),
                    _particleTexture,
                    false);
            }
            else
            {
                _particleSystem.AddEmitter(new Vector2(0.001f, 0.0015f),
                    new Vector2(1, 1),
                    new Vector2(1f * MathHelper.Pi, 1f * -MathHelper.Pi),
                    new Vector2((float)_random.NextDouble(), (float)_random.NextDouble()),
                    new Vector2(_random.Next(25, 30), _random.Next(25, 30)),
                    new Vector2(_random.Next(8, 10), _random.Next(8, 10)),
                    Color.Green,
                    Color.WhiteSmoke,
                    Color.Green,
                    Color.DarkGreen,
                    new Vector2(40, 40),
                    new Vector2(0, 0),
                    100,
                    new Vector2(obj2.Position.X + (obj2.Texture.Width / 2), obj2.Position.Y + (obj2.Texture.Height / 2)),
                    _particleTexture,
                    false);
            }
        }

        public void SaveLevel(Dictionary<string, string> strings, List<GameObject> levelObjects, List<FinishLevel> finishLevel)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            ChemEngine.Structs.LevelStruct saveData = new ChemEngine.Structs.LevelStruct();
            saveData._gameObjects = new List<ChemEngine.Structs.GameObjectStruct>();

            foreach (ChemEngine.GameObjects.GameObject item in levelObjects)
            {
                saveData._gameObjects.Add(new ChemEngine.Structs.GameObjectStruct
                {
                    _count = item.Count,
                    _gameObjectType = item.GameObjectType,
                    _name = item.Name,
                    _position = item.Position,
                    _selected = false,
                    _type = item.Type
                });
            }

            saveData._finishLevel = finishLevel;

            saveData._goal = strings["goal"];
            saveData._dialogText = strings["dialogText"];
            saveData._nextLevel = strings["nextLevel"];


            using (XmlWriter writer = XmlWriter.Create(strings["name"] + ".level", settings))
            {
                IntermediateSerializer.Serialize<ChemEngine.Structs.LevelStruct>(writer, saveData, null);
            }
        }

        public void DeselectAll()
        {
            foreach (GameObject obj in _currentLevel.GameObjects)
            {
                obj.Selected = false;
            }

            detection.Clear();
        }
    }
}
