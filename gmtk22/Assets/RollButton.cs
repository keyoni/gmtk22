using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollButton : MonoBehaviour
{
    private RollingTable table;
    // Start is called before the first frame update
    void Start()
    {
        table = GetComponentInParent<RollingTable>();
    }

    private void OnMouseDown()
    {
        print("Rolling!");
        table.RollDice();
    }

    private void OnMouseOver()
    {
        print("uh oh, are you going to click me??");
    }
}
