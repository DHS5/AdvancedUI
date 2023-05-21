using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class BaseStyleSheet
    {
        [SerializeField, ReadOnly, AllowNesting] private int uniqueID;
        public int UID => uniqueID;

        [SerializeField] private string name;
        public string Name => name;

        public void SetUID(int uid)
        {
            uniqueID = uid;
        }
    }
}
