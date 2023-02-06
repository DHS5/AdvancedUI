using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Dhs5.AdvancedUI
{
    public class Test : MonoBehaviour
    {
        public Teeest test;

        public bool isActive;
        [ShowIf("isActive")]
        public int backgroundIndex = -1;
    }

    [System.Serializable]
    public class Teeest
    {
        public bool isActive;
        [ShowIf("isActive")]
        public int backgroundIndex = -1;
    }
}
