using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dhs5.AdvancedUI;

public class Test : MonoBehaviour
{
    public List<string> list = new();

    public HorizontalScrollList horizontalScrollList;

    private void Start()
    {
        horizontalScrollList.CreateList(list);
    }

    private void Update()
    {
        Debug.Log(horizontalScrollList.CurrentSelectionIndex);
    }
}
