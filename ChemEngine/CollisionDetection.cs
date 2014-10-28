using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChemEngine.GameObjects;
using Microsoft.Xna.Framework;

namespace ChemEngine
{
    public class CollisionDetection
    {
        GameObject _selectedObject;
        GameObject _prevSelectedObject;

        public CollisionDetection()
        {
        }

        public void Update(GameTime gameTime, List<GameObject> gameObjects, ChemEngine.Input.Mouse mouse)
        {
            if (mouse.MS.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouse.PreviousMouseState != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
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
                }

                _prevSelectedObject = _selectedObject;
                _selectedObject = gameObjects.Find(g => g.Selected);

                if (_selectedObject != null && _prevSelectedObject != null)
                {
                    if (Vector2.Distance(_prevSelectedObject.Position, _selectedObject.Position) <= 50 &&
                        Vector2.Distance(_prevSelectedObject.Position, _selectedObject.Position) > 0)
                    {
                        Engine.Mixture(_prevSelectedObject, _selectedObject, gameObjects);
                        _prevSelectedObject = null;
                        _selectedObject = null;

                        foreach (GameObject obj in gameObjects)
                        {
                            obj.Selected = false;
                        }
                    }
                    else if (Vector2.Distance(_prevSelectedObject.Position, new Vector2((int)mouse.Position.X - (mouse.Position.X % 32), (int)mouse.Position.Y - (mouse.Position.Y % 32))) <= 50)
                    {
                        _prevSelectedObject.Position = new Vector2((int)mouse.Position.X - (mouse.Position.X % 32), (int)mouse.Position.Y - (mouse.Position.Y % 32));
                        _prevSelectedObject = null;
                        _selectedObject = null;

                        foreach (GameObject obj in gameObjects)
                        {
                            obj.Selected = false;
                        }
                    }
                }

                mouse.PreviousMouseState = Microsoft.Xna.Framework.Input.ButtonState.Pressed;
            }
            else if (mouse.MS.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                mouse.PreviousMouseState = Microsoft.Xna.Framework.Input.ButtonState.Released;
            }
        }

        public void Clear()
        {
            _selectedObject = null;
            _prevSelectedObject = null;
        }
    }
}
