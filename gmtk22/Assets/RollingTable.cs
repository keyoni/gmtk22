using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RollingTable : MonoBehaviour
{
    [SerializeField] private List<GameObject> diceOnTable;

   // [SerializeField] private List<Transform> diceHolders;

    // private Queue<Transform> openHolders;
    //
    // private List<Transform> closedHolder;
    // Start is called before the first frame update
    void Start()
    {
        diceOnTable = new List<GameObject>();
        // openHolders = new Queue<Transform>();
        // closedHolder = new List<Transform>();
        // foreach (var dHold in diceHolders)
        // {
        //     openHolders.Enqueue(dHold);
        // }
    }
    
    public void RollDice()
    {
        foreach (var die in diceOnTable)
        {
           // print($" Rolling {die.gameObject.name}");
            die.GetComponent<Dice>().Roll();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       // print($" Entering {col.gameObject.name}");
                diceOnTable.Add(col.gameObject);
                // var diceHold = openHolders.Dequeue();
                // col.gameObject.transform.localPosition = diceHold.localPosition;
                // closedHolder.Add(diceHold);
    }   

    private void OnTriggerExit2D(Collider2D other)
    {
     //  print($" Exit {other.gameObject.name}");
        diceOnTable.Remove(other.gameObject);
    }
}





    

