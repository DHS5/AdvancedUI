using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Dhs5.AdvancedUI
{
    public abstract class ScrollListObject : MonoBehaviour
    {
        public int Index { get; private set; }

        public void Set<T>(T obj, int index)
        {
            Index = index;
            SetUp(obj);
        }

        protected abstract void SetUp<T>(T objectToSetUpFrom);

        public abstract string GetName<T>(T objectToGetNameFrom);

        public void Move(float delta, bool xAxis)
        {
            transform.Translate(new Vector3(xAxis ? delta : 0, xAxis ? 0 : delta, 0));
        }
    }
}
