using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RollingTable : MonoBehaviour
{
    private List<GameObject> diceOnTable;
    // Start is called before the first frame update
    void Start()
    {
        diceOnTable = new List<GameObject>();
    }
    
    public void RollDice()
    {
        foreach (var die in diceOnTable)
        {
            print($" Rolling {die.gameObject.name}");
            die.GetComponent<Dice>().Roll();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        print($" Entering {col.gameObject.name}");
                diceOnTable.Add(col.gameObject);
        print($" List size {diceOnTable.Count}");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print($" Exit {other.gameObject.name}");
        diceOnTable.Remove(other.gameObject);
    }
}





    

