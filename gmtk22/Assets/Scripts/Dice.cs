using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{

    // Array of dice sides sprites to load from Resources folder
    [SerializeField] public List<DiceFaceScriptiableObject> diceSides;


    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    public bool fromMerge;
    private MergeManager _mergeManager;
    public int finalSide = 0;

    private bool isOverDie;
    private bool mouseHover;

    private GameObject currentlyCol;

    [SerializeField] private GameObject locked;

    private AudioManager _audioManager;
    public static event Action DiceRolling;
    // Use this for initialization
    private void Start()
    {
        // print(fromMerge);
        _mergeManager = FindObjectOfType<MergeManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        print(_audioManager);
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();
        print($" Dice Side: {diceSides[0].value} ");
        if (fromMerge)
        {
            locked.SetActive(true);
        }

        Roll();


    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && mouseHover)
        {
            Roll();
        }
    }

    // If you left click over the dice then RollTheDice coroutine is started
    public void Roll()
    {
        StartCoroutine(nameof(RollTheDice));
    }

    private void OnMouseEnter()
    {
        mouseHover = true;
    }

    private void OnMouseExit()
    {
        mouseHover = false;
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        var randomDiceSide = 0;
        
       //DiceRolling?.Invoke();

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, diceSides.Count);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide].faceSprite;

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = diceSides[randomDiceSide].numValue;

        // Show final dice value in Console
        //    Debug.Log(finalSide);
    }

    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (!fromMerge){
            if (col.gameObject.CompareTag("Dice"))
            {
                isOverDie = true;
                //Particles happen here
                yield return new WaitForSeconds(1f);
                if (isOverDie)
                {
                    //print("Still Working");
                    _mergeManager.MergeNumbers(gameObject, col.gameObject, this.transform);
                    //print($"Merged = {merged}");
                    // if (merged)
                    // {
                    //     Play animation
                    //     Destroy(col.gameObject);
                    //     Destroy(this.gameObject);
                    // }
                }
            }
    }
}



    private void OnTriggerExit2D(Collider2D other)
    {
        //Particles Disappears here
        isOverDie = false;
    }

    public void SetLocked(bool locking)
    {
      locked.SetActive(locking);
    }
}



//---------------------------------------------------------------------------------------------
// private IEnumerator OnTriggerEnter2D(Collider2D col)
// {
//     if (col.gameObject.CompareTag("Dice"))
//     {
//         yield return new WaitForSeconds(2f);
//         
//         print("Still Working");
//         bool merged = _mergeManager.MergeNumbers(finalSide, col.GetComponent<Dice>().finalSide);
//         print($"Merged = {merged}");
//         if (merged)
//         {
//             //Play animation
//             Destroy(col.gameObject,1);
//             Destroy(this.gameObject,1);
//         }
//     }
