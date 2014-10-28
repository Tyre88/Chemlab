using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChemEngine.GUI;
using Microsoft.Xna.Framework;

namespace ChemEngine.Level
{
    class Level3 : Level
    {
        Dialog _level3Dialog;

        public Level3()
        {
            base.InitLevel("level3");

            _timeOnLevel = 0f;

            _level3Dialog = new Dialog(new Vector2(0, 320), Engine.SingleTon.DialogBackgroundTexture, Engine.SingleTon.Head1, Engine.SingleTon.BaseFont,
                "Can you please make 1 water and 1 methane?", 0, _dialogTimer);
            _level3Dialog.Finish += new Dialog.FinishedLoadingEvent(Engine.SingleTon.Dialog_Finish);
            _level3Dialog.ShowDialog += new Dialog.ShowDialogEvent(Engine.SingleTon.Dialog_Show);
            _level3Dialog.Name = "Noob chemist";

            Engine.SingleTon.DialogList.Add(_level3Dialog);

            _level3Dialog.Show();
        }
    }
}
