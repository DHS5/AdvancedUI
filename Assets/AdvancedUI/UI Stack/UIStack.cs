using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.AdvancedUI
{
    public static class UIStack
    {
        private static Stack<GameObject> mainStack;
        public static GameObject TopObject => (mainStack != null && mainStack.Count > 0) ? mainStack.Peek() : null;

        /// <summary>
        /// Show a new GameObject on the main stack
        /// </summary>
        /// <param name="go">GameObject to show</param>
        public static void Show(GameObject go)
        {
            if (mainStack == null) mainStack = new();

            if (TopObject != null)
                TopObject.SetActive(false);

            go.SetActive(true);
            mainStack.Push(go);
        }
        /// <summary>
        /// Show a new GameObject on the <paramref name="stack"/>
        /// </summary>
        /// <param name="go">GameObject to show</param>
        /// <param name="stack">Stack to use</param>
        public static void Show(GameObject go, ref Stack<GameObject> stack)
        {
            if (stack == null) stack = new();

            if (stack.Count > 0)
                stack.Peek().SetActive(false);

            go.SetActive(true);
            stack.Push(go);
        }

        /// <summary>
        /// Add a new GameObject on top of the previous one on the main stack
        /// </summary>
        /// <param name="go">GameObject to show</param>
        public static void Add(GameObject go)
        {
            if (mainStack == null) mainStack = new();

            go.SetActive(true);
            mainStack.Push(go);
        }
        /// <summary>
        /// Add a new GameObject on top of the previous one on the <paramref name="stack"/>
        /// </summary>
        /// <param name="go">GameObject to show</param>
        /// <param name="stack">Stack to use</param>
        public static void Add(GameObject go, ref Stack<GameObject> stack)
        {
            if (stack == null) stack = new();

            go.SetActive(true);
            stack.Push(go);
        }

        /// <summary>
        /// Go back to the previous GameObject on the main stack
        /// </summary>
        public static void Back()
        {
            if (mainStack == null)
            {
                mainStack = new();
                return;
            }

            if (mainStack.Count > 0)
                mainStack.Pop().SetActive(false);

            if (TopObject != null)
                TopObject.SetActive(true);
        }
        /// <summary>
        /// Go back to the previous GameObject on the <paramref name="stack"/>
        /// </summary>
        /// <param name="stack">Stack to use</param>
        public static void Back(ref Stack<GameObject> stack)
        {
            if (stack == null)
            {
                stack = new();
                return;
            }

            if (stack.Count > 0)
                stack.Pop().SetActive(false);

            if (stack.Count > 0)
                stack.Peek().SetActive(true);
        }

        /// <summary>
        /// Clears the main stack and potentially set the new base object
        /// </summary>
        /// <param name="go">New base object of the main stack</param>
        public static void Clear(GameObject go = null)
        {
            if (mainStack == null) mainStack = new();
            else
            {
                foreach (var item in mainStack)
                {
                    item.SetActive(false);
                }

                mainStack.Clear();
            }

            if (go != null)
            {
                go.SetActive(true);
                mainStack.Push(go);
            }
        }
        /// <summary>
        /// Clears the <paramref name="stack"/> and potentially set the new base object
        /// </summary>
        /// <param name="stack">Stack to use</param>
        /// <param name="go">New base object of the main stack</param>
        public static void Clear(ref Stack<GameObject> stack, GameObject go = null)
        {
            if (stack == null) stack = new();
            else
            {
                foreach (var item in stack)
                {
                    item.SetActive(false);
                }

                stack.Clear();
            }

            if (go != null)
            {
                go.SetActive(true);
                stack.Push(go);
            }
        }

        /// <summary>
        /// Replace the current <see cref="TopObject"/> by <paramref name="go"/> on the main stack
        /// </summary>
        /// <param name="go">New GameObject to show</param>
        public static void Replace(GameObject go)
        {
            Back();
            Show(go);
        }
        /// <summary>
        /// Replace the current <see cref="TopObject"/> by <paramref name="go"/> on the <paramref name="stack"/>
        /// </summary>
        /// <param name="go">New GameObject to show</param>
        /// <param name="stack">Stack to use</param>
        public static void Replace(GameObject go, ref Stack<GameObject> stack)
        {
            Back(ref stack);
            Show(go, ref stack);
        }
    }
}
