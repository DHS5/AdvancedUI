using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    public class UIStackComponent : MonoBehaviour
    {
        private Stack<GameObject> stack;
        public GameObject TopObject => stack.Peek();

        /// <summary>
        /// Show a new GameObject on the main stack
        /// </summary>
        /// <param name="go">GameObject to show</param>
        public void Show(GameObject go)
        {
            UIStack.Show(go, ref stack);
        }

        public void Add(GameObject go)
        {
            UIStack.Add(go, ref stack);
        }

        /// <summary>
        /// Go back to the previous GameObject on the main stack
        /// </summary>
        public void Back()
        {
            UIStack.Back(ref stack);
        }
        /// <summary>
        /// Clears the main stack and potentially set the new base object
        /// </summary>
        /// <param name="go">New base object of the main stack</param>
        public void Clear(GameObject go = null)
        {
            UIStack.Clear(ref stack, go);
        }

        /// <summary>
        /// Replace the current <see cref="TopObject"/> by <paramref name="go"/>
        /// </summary>
        /// <param name="go">New GameObject to show</param>
        public void Replace(GameObject go)
        {
            UIStack.Replace(go, ref stack);
        }
    }
}
