using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{

    public Dictionary<int, DiceFaceScriptiableObject> mergeValues;

    [SerializeField] public List<DiceFaceScriptiableObject> diceFaces;

    [SerializeField] private GameObject mergeDiePrefab;

    private bool lockMerge;
    // Start is called before the first frame update
    void Start()
    {
        mergeValues = new Dictionary<int, DiceFaceScriptiableObject>();
        PopulateMergeList();
    }

    private void PopulateMergeList()
    {
        foreach (var dice in diceFaces)
        {
            mergeValues.Add(dice.mergeNum,dice);
            //print($"Die - {dice.value}, {mergeValues[dice.mergeNum]}");
        }
       
      
    }

    public bool MergeNumbers(int val1, int val2)
    {
        //Put In Co-thingy
        if (!lockMerge)
        {
            print("merging");
            lockMerge = true;
            int currentVal = val1 + val2;
            print(currentVal);
            if (mergeValues.TryGetValue(currentVal, out DiceFaceScriptiableObject mergedDice))
            {
                //Spawn new dice - Maybe add a space for that to pop out of 
                GameObject mergeDie = Instantiate(mergeDiePrefab);
                mergeDie.GetComponent<Dice>().diceSides.Add(mergedDice);
                mergeDie.GetComponent<Dice>().fromMerge = true;
                return true;
            }
            

            lockMerge = false;
        }

        return false;
    }

}
// Update is called once per frame

