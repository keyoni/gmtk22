using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

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
            int dice1Num = dice1.GetComponent<Dice>().finalSide;
            int dice2Num = dice2.GetComponent<Dice>().finalSide;
             var positionNew = pos.position;
            print("merging");
            lockMerge = true;   
            var mergePar =Instantiate(mergeParticles, positionNew, Quaternion.identity);
            ParticleSystem par = mergePar.GetComponent<ParticleSystem>(); 
            var mainModule = par.main;
            par.Play();
            int currentVal = dice1Num + dice2Num;
            print(currentVal);
            if (mergeValues.TryGetValue(currentVal, out DiceFaceScriptiableObject mergedDice))
            {
                mainModule.startColor = Color.blue;
                par.Play();
                Destroy(dice1);
                Destroy(dice2);
                //Spawn new dice - Maybe add a space for that to pop out of 
                GameObject mergeDie = Instantiate(mergeDiePrefab,positionNew,Quaternion.identity);
                mergeDie.GetComponent<Dice>().diceSides.Add(mergedDice);
                mergeDie.GetComponent<Dice>().fromMerge = true;
                mergeDie.GetComponent<SpriteRenderer>().color = Color.white;
                Destroy(mergePar,1);
                lockMerge = false;
                return true;
            }
            if (dice1Num < -100 || dice2Num < -100)
            {
                mainModule.startColor = Color.yellow;
                Destroy(dice1);
                Destroy(dice2);
                //otherParticles
                if (dice1Num > 0)
                {
                    print("Die 1 was the NON Split");
                    par.Play();
                    int ran = Random.Range(1, dice1Num - 1);
                   
                    GameObject dice1New = Instantiate(mergeDiePrefab, positionNew, Quaternion.identity);
                    dice1New.GetComponent<Dice>().diceSides.Add(mergeValues[ran]);
                    dice1New.GetComponent<Dice>().fromMerge = true;
                    dice1New.GetComponent<SpriteRenderer>().color = Color.white;
                   
                    GameObject dice2New = Instantiate(mergeDiePrefab, positionNew, Quaternion.identity);
                    dice2New.GetComponent<Dice>().diceSides.Add(mergeValues[dice1Num - ran]);
                    dice2New.GetComponent<Dice>().fromMerge = true;
                    dice2New.GetComponent<SpriteRenderer>().color = Color.white;
                    Destroy(mergePar,1);
                    lockMerge = false;
                    return true;
                    
                }
                else 
                {
                    print("Die 2 was the NON Split");
                    par.Play();
                    int ran = Random.Range(1, dice2Num - 1);
                    GameObject dice1New = Instantiate(mergeDiePrefab, positionNew, Quaternion.identity);
                    dice1New.GetComponent<Dice>().diceSides.Add(mergeValues[ran]);
                    dice1New.GetComponent<Dice>().fromMerge = true;
                    dice1New.GetComponent<SpriteRenderer>().color = Color.white;
                    
                    GameObject dice2New = Instantiate(mergeDiePrefab, pos.position, Quaternion.identity);
                    dice2New.GetComponent<Dice>().diceSides.Add(mergeValues[dice2Num - ran]);
                    dice2New.GetComponent<Dice>().fromMerge = true;
                    dice2New.GetComponent<SpriteRenderer>().color = Color.white;
                    Destroy(mergePar,1);
                    lockMerge = false;
                    return true;
                }
                
            }
            
            
            mainModule.startColor = Color.red;
            par.Play();
            Destroy(mergePar,1);

            lockMerge = false;
            
        }

        return false;
    }

}
