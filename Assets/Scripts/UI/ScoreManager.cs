using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreMultiplierText;
    private float pointsF;
    private int pointsI;
    private string scoreMultiplier = "x";

    void Start()
    {
        pointsF = 0;
    }

    void Update()
    {
        ScorePointsUpdater();
        ScoreMultiplierUpdater();
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
}
