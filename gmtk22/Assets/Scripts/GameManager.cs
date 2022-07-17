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
    public TMP_Text scoreFinalText;
    public int score;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject dicePrefab;
    private int _rounds = 1;
    private bool gameOver;
    [SerializeField] private GameObject gameOverPanel;
    
    private void Start()
    
    {
        ProblemCard.ProblemSolved += Score;
        ProblemCard.ProblemSolved += ResetDie;
        
    }
    
    void Update()
    {
        if (!gameOver)
        {
            UpdateTimer();
        }
    }
    private void UpdateTimer()
    {
        //Timer
        _countUpAccumulated += Time.deltaTime;
        
        if (_countUpAccumulated > 0.01f)
        {
            timeUp += 0.01f;
            //timer.text = timeUp.ToString("00");
            _countUpAccumulated = 0f;
        }
        
        
    }

    private void Score()
    {
        score += (int) timeUp;
        //scoreText.text = score.ToString("00");
        print($"Score: {score}");
        timeUp = 0;
    }

    private void ResetDie()
    {
        _rounds++;
        if (_rounds == 3)
        {
            GameOver();
        }
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

    void GameOver()
    {
     
        gameOver = true;
        scoreFinalText.text = score.ToString("00");
          gameOverPanel.GetComponent<Animator>().Play("GameOverPanel");
        
    }
}

   

   
