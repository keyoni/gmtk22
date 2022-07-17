using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MergeManager : MonoBehaviour
{

    public Dictionary<int, DiceFaceScriptiableObject> mergeValues;

    [SerializeField] public List<DiceFaceScriptiableObject> diceFaces;

    [SerializeField] private GameObject mergeDiePrefab;

    [SerializeField] private GameObject mergeParticles;
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

    public bool MergeNumbers(GameObject dice1, GameObject dice2, Transform pos)
    {
        //Put In Co-thingy
        if (!lockMerge)
        {
            print("merging");
            lockMerge = true;
            int currentVal = dice1.GetComponent<Dice>().finalSide + dice2.GetComponent<Dice>().finalSide;
            print(currentVal);
            if (mergeValues.TryGetValue(currentVal, out DiceFaceScriptiableObject mergedDice))
            {
                var mergePar =Instantiate(mergeParticles, pos.position, Quaternion.identity);
                Destroy(mergePar,5);
                Destroy(dice1);
                Destroy(dice2);
                //Spawn new dice - Maybe add a space for that to pop out of 
                GameObject mergeDie = Instantiate(mergeDiePrefab,pos.position,Quaternion.identity);
                mergeDie.GetComponent<Dice>().diceSides.Add(mergedDice);
                mergeDie.GetComponent<Dice>().fromMerge = true;
                
                lockMerge = false;
                return true;
            }
            else
            {
                //otherParticles
            }

            lockMerge = false;
            
        }

        return false;
    }

}
// Update is called once per frame

