using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChemEngine.GameObjects;
using Microsoft.Xna.Framework;
using ChemEngine.Input;

namespace ChemEngine.Editor
{
    class LevelEditorCollision
    {
        GameObject _selectedObject;

        public GameObject SelectedObject
        {
            get { return _selectedObject; }
            set { _selectedObject = value; }
        }

        public void Update(GameTime gameTime, List<GameObject> gameObjects, Mouse mouse, List<GameObject> levelObjects)
        {
            if (mouse.MS.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouse.PreviousMouseState != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                if (_selectedObject == null)
                {
                    GameObject collideObj = gameObjects.Find(g => new Rectangle((int)g.Position.X, (int)g.Position.Y, g.Texture.Width, g.Texture.Height).Intersects(new Rectangle(
                        (int)mouse.Position.X, (int)mouse.Position.Y, 0, 0)));

                    if (collideObj != null)
                    {
                        foreach (GameObject obj in gameObjects)
                        {
                            obj.Selected = false;
                        }

                        collideObj.Selected = true;
                        _selectedObject = collideObj;
                    }
                    else
                    {
                        collideObj = levelObjects.Find(g => new Rectangle((int)g.Position.X, (int)g.Position.Y, g.Texture.Width, g.Texture.Height).Intersects(new Rectangle(
                        (int)mouse.Position.X, (int)mouse.Position.Y, 0, 0)));

                        if (collideObj != null)
                        {
                            levelObjects.ForEach(g => g.Selected = false);
                            levelObjects.Find(g => g == collideObj).Selected = true;
                        }
                    }
                }
                else if (_selectedObject != null)
                {
                    if ((mouse.Position.X >= 0 && mouse.Position.X <= 480 && mouse.Position.Y >= 0 && mouse.Position.Y <= 320)
                        && !(levelObjects.Exists(g => new Rectangle((int)g.Position.X, (int)g.Position.Y, g.Texture.Width, g.Texture.Height).Intersects(new Rectangle((int)mouse.Position.X, (int)mouse.Position.Y, 0, 0)))))
                    {
                        GameObject newobj = (GameObject)Activator.CreateInstance(_selectedObject.GetType());
                        newobj.Position = new Vector2((int)mouse.Position.X - (mouse.Position.X % 32), (int)mouse.Position.Y - (mouse.Position.Y % 32));

                        levelObjects.Add(newobj);
                    }
                }

                mouse.PreviousMouseState = Microsoft.Xna.Framework.Input.ButtonState.Pressed;
            }
            else if (mouse.MS.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                mouse.PreviousMouseState = Microsoft.Xna.Framework.Input.ButtonState.Released;
            }
        }
    }
}
