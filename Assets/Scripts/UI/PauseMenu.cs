using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject deathScreen;
    [SerializeField] TextMeshProUGUI pauseHighscoreText;
    [SerializeField] TextMeshProUGUI loseHighscoreText;

    void Start()
    {
        ScoreManager.onNewHighscore += HighscoreSet;
        HighscoreSet();
    }

    void Update()
    {
        if (GameManager.Pause && !GameManager.GameEnded)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }

        if (GameManager.GameEnded)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            deathScreen.SetActive(false);
        }
    }

    public void Exit()
    {
        AudioControler.pitchReduced = false;
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        AudioControler.pitchReduced = false;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        GameManager.GameEnded = false;
        GameManager.Pause = false;
    }

    public void ContinuePlay()
    {
        AudioControler.pitchReduced = false;
        pausePanel.SetActive(false);
        GameManager.Pause = false;
    }

    private void HighscoreSet()
    {
        pauseHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        loseHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    private void OnDisable()
    {
        ScoreManager.onNewHighscore -= HighscoreSet;
    }
}
