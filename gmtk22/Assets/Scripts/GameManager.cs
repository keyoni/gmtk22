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
    private void Start()
    {
        ProblemCard.ProblemSolved += Score;
    }
    
    void Update()
    {

        UpdateTimer();

    }
    private void UpdateTimer()
    {
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
        score = (int) timeUp;
        print($"Score: {score}");
        timeUp = 0;
    }
}

// Start is called before the first frame update
   
   

   
