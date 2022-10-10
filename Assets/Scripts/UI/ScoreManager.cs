using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreMultiplierText;
    private PauseMenu pauseMenu;
    private int buildIndex;
    private int pointsI;
    private float pointsF;

    void Start()
    {
        pointsF = 0;
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        GameManager.onGameOver += HighscoreManager;
        pauseMenu = GetComponent<PauseMenu>();
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
        scoreMultiplierText.text = "x" + PointsManager.multiplicator.ToString();
    }

    private void HighscoreManager()
    {
        switch (buildIndex)
        {
            case 1:
                if (pointsI > PlayerPrefs.GetInt("EasyHighscore", 0))
                {
                    PlayerPrefs.SetInt("EasyHighscore", pointsI);
                    pauseMenu.HighscoreSet();
                }
                break;
            case 2:
                if (pointsI > PlayerPrefs.GetInt("NormalHighscore", 0))
                {
                    PlayerPrefs.SetInt("NormalHighscore", pointsI);
                    pauseMenu.HighscoreSet();
                }
                break;
            case 3:
                if (pointsI > PlayerPrefs.GetInt("HardHighscore", 0))
                {
                    PlayerPrefs.SetInt("HardHighscore", pointsI);
                    pauseMenu.HighscoreSet();
                }
                break;
        }
    }

    private void OnDisable()
    {
        GameManager.onGameOver -= HighscoreManager;
    }
}
