using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{

    public Dictionary<String[], DiceFaceScriptiableObject> mergeValues;
    // Start is called before the first frame update
    void Start()
    {
        PopulateMergeList();
    }

    private void PopulateMergeList()
    {
        String[] colorList1 = new[] {"Purple", "Green", "Red"};
        String[] colorList2 = new[] {"Yellow", "Blue", "Grey"};
        List<String> purpleGreen = new List<string>();
        purpleGreen.AddRange();
      
          } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
