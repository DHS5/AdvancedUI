using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dhs5.AdvancedUI
{
    public class ScrollListObjectExample : ScrollListObject
    {
        [SerializeField] private Image image;

        protected override void SetUp<T>(T objectToSetUpFrom)
        {
            image.color = Random.ColorHSV();
        }
    }
}
