using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score scoreInstance;
    public int totalScore;
    public int scoreTmp;

    public Text scoreText;
    public Button calculateScore;

    public void Start()
    {
        calculateScore.onClick.AddListener(SetScore);
    }

    public void AddScore()
    { 
        totalScore += scoreTmp;
        scoreTmp = 0;
    }

    public void SetScore()
    { 
        scoreText.text = $"Score: {totalScore}";
    }
}
