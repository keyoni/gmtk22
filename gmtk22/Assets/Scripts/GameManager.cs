using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Time management
    private float _timeAccumulated;
    private float _countUpAccumulated;
    public float timeUp = 20f;
    public TMP_Text timer;
    public TMP_Text scoreText;
    public int score;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject dicePrefab;
    private void Start()
    {
        ProblemCard.ProblemSolved += Score;
        ProblemCard.ProblemSolved += ResetDie;
        
    }
    
    void Update()
    {
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        //Timer
        _countUpAccumulated += Time.deltaTime;
        
        if (_countUpAccumulated > 0.01f)
        {
            timeUp += 0.01f;
            timer.text = timeUp.ToString("00");
            _countUpAccumulated = 0f;
        }
        
        
    }

    private void Score()
    {
        score += (int) timeUp;
        scoreText.text = score.ToString("00");
        print($"Score: {score}");
        timeUp = 0;
    }

    private void ResetDie()
    {
        var dice = FindObjectsOfType<Dice>();
        foreach (var die in dice)
        {
            if (die.gameObject.CompareTag("Dice"))
            {
                Destroy(die.gameObject);
            }

        } 
        Instantiate(dicePrefab);
    }
}

// Start is called before the first frame update
   
   

   
