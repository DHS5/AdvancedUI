using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    public abstract class AdvancedComponent : MonoBehaviour
    {
        protected virtual void Awake()
        {
            SetUpConfig();
        }
        private void OnValidate()
        {
            SetUpConfig();
        }

        private void OnEnable()
        {
            LinkEvents();
        }
        private void OnDisable()
        {
            UnlinkEvents();
        }

        protected abstract void LinkEvents();
        protected abstract void UnlinkEvents();

        protected abstract void SetUpConfig();
    }
}
