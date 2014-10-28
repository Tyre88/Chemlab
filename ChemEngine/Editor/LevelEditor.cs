using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChemEngine.GameObjects;
using ChemEngine.Input;
using ChemEngine.GUI;
using ChemEngine.Editor.Buttons;
using ChemEngine.Structs;
using ChemEngine.Editor.Forms;

namespace ChemEngine.Editor
{
    class LevelEditor
    {
        List<GameObject> _gameObjDB;
        List<GameObject> _levelObjects;
        List<Button> _buttons;
        List<FinishLevel> _finishLevel;
        List<Text> _texts;
        string _nextLevel;

        Text _selectedText, _nextLevelText, _finishLevelText;

        LevelEditorCollision _collision;

        #region Forms
        SetLevelName setLevelName;
        NextLevel nextLevel;
        AddFinishCondition addFinishCondition;
        #endregion

        public LevelEditor()
        {
            _levelObjects = new List<GameObject>();
            _collision = new LevelEditorCollision();
            _buttons = new List<Button>();
            _finishLevel = new List<FinishLevel>();
            _texts = new List<Text>();

            _gameObjDB = new List<GameObject>();

            _gameObjDB.Add(new Hydrogen());
            _gameObjDB.Add(new Oxygen());
            _gameObjDB.Add(new Carbon());
            _gameObjDB.Add(new Lithium());
            _gameObjDB.Add(new Helium());

            _gameObjDB.Add(new CarbonDioxide());
            _gameObjDB.Add(new CarbonMonoxide());
            _gameObjDB.Add(new Methane());
            _gameObjDB.Add(new Water());
            

            SaveButton saveButton = new SaveButton(Engine.SingleTon.ButtonTextureDictionary[0], new Vector2(717, 448));
            saveButton.Intersect += new Button.IntersectEvent(Input_SaveLevel);
            _buttons.Add(saveButton);

            Button finishConditionButton = new Button(Engine.SingleTon.ButtonTextureDictionary[1], new Vector2(650, 448));
            finishConditionButton.Intersect += new Button.IntersectEvent(finishConditionButton_Intersect);
            _buttons.Add(finishConditionButton);

            Button nextLevelButton = new Button(Engine.SingleTon.ButtonTextureDictionary[2], new Vector2(583, 448));
            nextLevelButton.Intersect += new Button.IntersectEvent(nextLevelButton_Intersect);
            _buttons.Add(nextLevelButton);

            Initialize();

            _selectedText = new Text(new Vector2(25, 350), Engine.SingleTon.BaseFont, "", "Target", Color.Red);
            _nextLevelText = new Text(new Vector2(25, 375), Engine.SingleTon.BaseFont, _nextLevel, "Next Level", Color.Red);
            _finishLevelText = new Text(new Vector2(25, 400), Engine.SingleTon.BaseFont, "", "Finish Level count", Color.Red);

            _texts.Add(_selectedText);
            _texts.Add(_nextLevelText);
            _texts.Add(_finishLevelText);

            Engine.SingleTon.KeyboardInput.IsEditing = true;

            Engine.SingleTon.KeyboardInput.Escape += new KeyboardInput.EmptyEvent(KeyboardInput_Escape);
            Engine.SingleTon.KeyboardInput.Delete += new KeyboardInput.EmptyEvent(KeyboardInput_Delete);
            Engine.SingleTon.KeyboardInput.SaveLevel += new KeyboardInput.EmptyEvent(Input_SaveLevel);

            #region Forms
            setLevelName = new SetLevelName();
            setLevelName.Save += new SetLevelName.ReturnName(SaveLevel);

            nextLevel = new NextLevel();
            nextLevel.Save += new NextLevel.SaveEvent(SetNextLevelName);

            addFinishCondition = new AddFinishCondition();
            addFinishCondition.Save += new AddFinishCondition.SaveEvent(AddFinishConditionToLevel);
            #endregion
        }

        void AddFinishConditionToLevel(string type, int count)
        {
            _finishLevel.Add(new FinishLevel
            {
                CountToDone = count,
                GameObjectType = (GameObjects.GameObjectType)Enum.Parse(typeof(GameObjects.GameObjectType), type, true),
                IsDone = false
            });

            _finishLevelText.ActiveText = string.IsNullOrEmpty(_finishLevelText.ActiveText) ? string.Format("{0} {1}", _finishLevel.Last().CountToDone, _finishLevel.Last().GameObjectType) : string.Format("{0}, {1} {2}",_finishLevelText.ActiveText, _finishLevel.Last().CountToDone, _finishLevel.Last().GameObjectType);//_finishLevel.Count.ToString();
        }

        void SetNextLevelName(string name)
        {
            _nextLevel = name;
            _nextLevelText.ActiveText = name;
        }

        void nextLevelButton_Intersect()
        {
            DeselectAll();

            if (!nextLevel.Visible)
            {
                nextLevel.ShowDialog();
                nextLevel.Focus();
            }
        }

        void finishConditionButton_Intersect()
        {
            DeselectAll();

            if (!addFinishCondition.Visible)
            {
                addFinishCondition.Reset();
                addFinishCondition.ShowDialog();
                addFinishCondition.Focus();
            }
        }

        void Input_SaveLevel()
        {
            DeselectAll();

            if (!setLevelName.Visible)
            {
                setLevelName.ShowDialog();
                setLevelName.Focus();
            }
        }

        void SaveLevel(string name, string goal)
        {
            Dictionary<string, string> strings = new Dictionary<string, string>();
            strings.Add("name", name);
            strings.Add("goal", goal);
            strings.Add("nextLevel", _nextLevel);
            strings.Add("dialogText", "");

            Engine.SingleTon.SaveLevel(strings, _levelObjects, _finishLevel);
        }

        void KeyboardInput_Delete()
        {
            _levelObjects.RemoveAll(g => g.Selected);
        }

        void KeyboardInput_Escape()
        {
            DeselectAll();
        }

        private void Initialize()
        {
            for (int i = 0; i < _gameObjDB.Count; i++)
            {
                if (i != 0)
                {
                    _gameObjDB[i].Position = new Vector2(_gameObjDB[i - 1].Position.X, _gameObjDB[i - 1].Position.Y + 30);
                }
                else
                {
                    _gameObjDB[i].Position = new Vector2(500, 25);
                }
            }
        }

        public void Update(GameTime gameTime, Mouse mouse)
        {
            _collision.Update(gameTime, _gameObjDB, mouse, _levelObjects);
            _gameObjDB.ForEach(g => g.Update(gameTime));
            _levelObjects.ForEach(g => g.Update(gameTime));

            List<GameObject> collectedList = new List<GameObject>();
            collectedList.AddRange(_gameObjDB);
            collectedList.AddRange(_levelObjects);

            _texts.ForEach(t => t.Update(gameTime, collectedList));
            _buttons.ForEach(b => b.Update(gameTime, mouse));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _gameObjDB.ForEach(g => g.Draw(spriteBatch));
            _levelObjects.ForEach(g => g.Draw(spriteBatch));

            _texts.ForEach(t => t.Draw(spriteBatch));
            _buttons.ForEach(b => b.Draw(spriteBatch));
        }

        private void DeselectAll()
        {
            _gameObjDB.ForEach(g => g.Selected = false);
            _levelObjects.ForEach(g => g.Selected = false);
            _collision.SelectedObject = null;
        }
    }
}
