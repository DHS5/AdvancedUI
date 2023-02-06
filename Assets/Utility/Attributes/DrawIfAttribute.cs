using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Dhs5.Utility
{
    public enum HidingType { READ_ONLY, HIDE }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class DrawIfAttribute : PropertyAttribute
    {
        public string PropertyName { get; private set; }
        public HidingType HidingType { get; private set; }

        public DrawIfAttribute(string propertyName, HidingType hidingType = HidingType.HIDE)
        {
            PropertyName = propertyName;
            HidingType = hidingType;
        }
    }
}
