using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreMultiplierText;
    private float pointsF;
    private int pointsI;
    private string scoreMultiplier = "x";
    public static Action onNewHighscore;
 
    void Start()
    {
        pointsF = 0;
    }

    void Update()
    {
        ScorePointsUpdater();
        ScoreMultiplierUpdater();
        HighscoreManager();
    }

    private void ScorePointsUpdater()
    {
        pointsF = PointsManager.points;
        pointsI = (int)pointsF;
        scoreText.text = pointsI.ToString();
    }

    private void ScoreMultiplierUpdater()
    {
        scoreMultiplierText.text = scoreMultiplier + PointsManager.multiplicator.ToString();
    }

    private void HighscoreManager()
    {
        if (pointsI > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", pointsI);
            onNewHighscore?.Invoke();
        }
        
    }
}
