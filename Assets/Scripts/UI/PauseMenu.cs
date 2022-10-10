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
    private int buildIndex;

    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
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

    public void HighscoreSet()
    {
        switch (buildIndex)
        {
            case 1:
                pauseHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("EasyHighscore", 0);
                loseHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("EasyHighscore", 0);
                break;
            case 2:
                pauseHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("NormalHighscore", 0);
                loseHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("NormalHighscore", 0);
                break;
            case 3:
                pauseHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HardHighscore", 0);
                loseHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HardHighscore", 0);
                break;
        }
    }
}
