using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMerge : MonoBehaviour
{
    [SerializeField] private DiceFaceScriptiableObject side;

    [SerializeField] private GameObject mergeDiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
       // mergeDiePrefab.GetComponent<Dice>().diceSides.
      GameObject mergeDie = Instantiate(mergeDiePrefab);
      mergeDie.GetComponent<Dice>().diceSides.Add(side);
    }
}
