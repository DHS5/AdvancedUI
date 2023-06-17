using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public abstract class BaseStyleSheet
    {
        [SerializeField, HideInInspector] protected StyleSheetContainer container;

        [SerializeField, HideInInspector] private int uniqueID;
        public int UID => uniqueID;

        [SerializeField, HideInInspector] private string name;
        public string Name => name;

        public void SetInfos(int uid, string name)
        {
            uniqueID = uid;
            this.name = name;
        }

        public virtual void SetUp(StyleSheetContainer _container) 
        { 
            container = _container;
        }

        public abstract List<StyleSheetPlaceholder> GetDependencies();

        public void Copy(BaseStyleSheet s)
        {
            if (s == null) return;

            uniqueID = s.uniqueID;
            name = s.name;

            CopyStyleSheet(s);
        }
        protected abstract void CopyStyleSheet(BaseStyleSheet s);
    }
}
