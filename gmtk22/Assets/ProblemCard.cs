using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemCard : MonoBehaviour
{

    private List<Dice> children;
    private int winningValue;
    private int currentValue;
    private int winningNumber;
    private int currentNumber;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<Dice>();
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject.GetComponent<Dice>());
        }

        StartCoroutine("GetNewValue");
        winningNumber = children.Count;
    }


    private IEnumerator GetNewValue()
    {
        yield return new WaitForSeconds(5f);
        foreach (Dice die in children)
        {
            winningValue += die.finalSide;

        }

        print("winning val" + winningValue);
        print($"currentVal" + currentValue);
    }

    private void OnMouseDown()
    {
        foreach (Dice die in children)
        {
            print($"Problem Card: {die.finalSide}");
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Dice"))
        {
            currentValue += col.GetComponent<Dice>().finalSide;
            currentNumber++;
        }

        CheckWinState();
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            currentValue += other.GetComponent<Dice>().finalSide;
            currentNumber--;
        }

        CheckWinState();
    }



    private void CheckWinState()
    {
        if (winningNumber == currentNumber)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            if (winningValue == currentValue)
            {
                print("WINNER!!!");
                
                GetNewProblemCard();
            }
        }
        else GetComponent<SpriteRenderer>().color = Color.red;
        
    }

    private void GetNewProblemCard()
    {
        foreach (Dice die in children)
        {
            die.Roll();
        }
        //Do a Action event
        StartCoroutine("GetNewValue");
        currentNumber = 0;
        currentValue = 0;
        
    }

}