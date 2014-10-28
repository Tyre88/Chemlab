using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChemEngine.GameObjects;

namespace ChemEngine.Structs
{
    public class FinishLevel
    {
        public GameObjectType GameObjectType { get; set; }
        public int CountToDone { get; set; }
        public bool IsDone { get; set; }
    }
}
