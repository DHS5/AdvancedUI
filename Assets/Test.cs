using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dhs5.AdvancedUI;

public class Test : MonoBehaviour
{
    public StyleSheetContainer container;

    public List<string> list = new();

    public ScrollListComponent scrollList;

    public StylePicker stylePicker;

    private void OnValidate()
    {
        stylePicker.SetUp(container, StyleSheetType.TEXT);
    }

    private void Start()
    {
        scrollList.CreateList(list);
    }

    public void TestFunc()
    {
        Debug.Log("test");
    }
}
