using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProblemCard : MonoBehaviour
{

    private List<Dice> children;
    [SerializeField]  private int winningValue;
   [SerializeField] private int currentValue;
    [SerializeField] private int winningNumber;
    [SerializeField] private int currentNumber;

    public static event Action ProblemSolved;
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

    //check of childwen dice numbwers reset

    private IEnumerator GetNewValue()
    {
        yield return new WaitForSeconds(3f);
        foreach (Dice die in children)
        {
            winningValue += die.finalSide;

        }

        print("winning val" + winningValue);
        print($"currentVal" + currentValue);
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Dice"))
        {
            col.GetComponent<Dice>().setLocked(true);
            currentValue += col.GetComponent<Dice>().finalSide;
            currentNumber++;
        }

        CheckWinState();
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            other.GetComponent<Dice>().setLocked(false);
            currentValue -= other.GetComponent<Dice>().finalSide;
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
                ProblemSolved?.Invoke();
                GetNewProblemCard();
            }
        }
        else  if(currentNumber> winningNumber)
            GetComponent<SpriteRenderer>().color = Color.red;
        
    }

    private void GetNewProblemCard()
    {
        
        currentNumber = 0;
        currentValue = 0;
        print("Old NUM: "+children[0].finalSide);
        foreach (Dice die in children)
        {
            die.Roll();
        }

        winningValue = 0;
        print("New NUM: "+children[0].finalSide);
        //Do a Action event
        StartCoroutine("GetNewValue");
        
        
    }

}