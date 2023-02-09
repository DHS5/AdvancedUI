using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    public class ScrollListSocket : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        public float Width { set { rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value); } }
        public float Height { set { rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value); } }


        private ScrollListObject scrollListObject;

        public ScrollListObject ScrollListObject
        {
            get { return scrollListObject; }
            set { scrollListObject = value; ParentScrollListObject(); }
        }

        private void ParentScrollListObject()
        {
            ScrollListObject.transform.SetParent(rectTransform, false);
        }
    }
}
