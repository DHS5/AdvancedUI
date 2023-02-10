using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dhs5.AdvancedUI;

public class Test : MonoBehaviour
{
    public List<string> list = new();

    public ScrollListComponent scrollList;

    private void Start()
    {
        scrollList.CreateList(list);
    }
}
