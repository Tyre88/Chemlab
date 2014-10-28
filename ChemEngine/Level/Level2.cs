using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChemEngine.GUI;

namespace ChemEngine.Level
{
    public class Level2 : Level
    {
        Dialog _level2Dialog;

        public Level2()
        {
            base.InitLevel("level2");

            _timeOnLevel = 0f;

            _level2Dialog = new Dialog(new Vector2(0, 320), Engine.SingleTon.DialogBackgroundTexture, Engine.SingleTon.Head1, Engine.SingleTon.BaseFont,
                "Now... I want you to make 2 Water, 1 Carbon dioxide and 2 Carbon monoxide! LETS BEGIN!", 0, _dialogTimer);
            _level2Dialog.Finish += new Dialog.FinishedLoadingEvent(Engine.SingleTon.Dialog_Finish);
            _level2Dialog.ShowDialog += new Dialog.ShowDialogEvent(Engine.SingleTon.Dialog_Show);
            _level2Dialog.Name = "Noob chemist";

            Engine.SingleTon.DialogList.Add(_level2Dialog);

            _level2Dialog.Show();
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
