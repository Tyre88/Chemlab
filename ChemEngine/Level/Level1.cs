using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChemEngine.GameObjects;
using ChemEngine.GUI;

namespace ChemEngine.Level
{
    class Level1 : Level
    {
        Dialog _level1Dialog;
        Dialog _makeWater;

        public Level1()
        {
            base.InitLevel("level1");

            _timeOnLevel = 0f;

            _level1Dialog = new Dialog(new Vector2(0, 320), Engine.SingleTon.DialogBackgroundTexture, Engine.SingleTon.Head1, Engine.SingleTon.BaseFont,
                "I want you to make 5 water molekules! If you can't make it you shouldn't be here... LETS BEGIN!", 0, _dialogTimer);
            _level1Dialog.Finish += new Dialog.FinishedLoadingEvent(Engine.SingleTon.Dialog_Finish);
            _level1Dialog.TimeToShow = 0;
            _level1Dialog.Name = "Noob chemist";

            _makeWater = new Dialog(new Vector2(0, 320), Engine.SingleTon.DialogBackgroundTexture, Engine.SingleTon.Head1, Engine.SingleTon.BaseFont,
                "OHHH, so you can make water after all!?", 0, 2000);
            _makeWater.Name = "Noob chemist";
            _makeWater.TimeToShow = -1;
            _makeWater.ShowDialog += new Dialog.ShowDialogEvent(Engine.SingleTon.Dialog_Show_Play);

            Engine.SingleTon.DialogList.Add(_level1Dialog);
            Engine.SingleTon.DialogList.Add(_makeWater);
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
