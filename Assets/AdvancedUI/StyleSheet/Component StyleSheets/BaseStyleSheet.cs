using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class BaseStyleSheet
    {
        private int uniqueID;
        public int UID => uniqueID;

        private string name;
        public string Name => name;

        public void SetInfos(int uid, string name)
        {
            uniqueID = uid;
            this.name = name;
        }
    }
}
