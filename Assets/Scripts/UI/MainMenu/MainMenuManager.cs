using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public List<GameObject> HideableMainMenu = new List<GameObject>();
    public List<GameObject> hideableSubMenu = new List<GameObject>();
    public Slider musicVolumeSlide;
    [SerializeField] TextMeshProUGUI highscoreText;

    void Start()
    {
        ChangeMainMenuState(true);
        ChangeSubMenuState(false);
        musicVolumeSlide.value = GameManager.MusicVolume;
        ScoreManager.onNewHighscore += HighscoreSet;
        HighscoreSet();
    }

    void Update()
    {

    }

    public void ChangeMainMenuState(bool nextState)
    {
        foreach (var item in HideableMainMenu)
        {
            item.gameObject.SetActive(nextState);
        }
    }

    public void ChangeSubMenuState(bool nextState)
    {
        foreach (var item in hideableSubMenu)
        {
            item.gameObject.SetActive(nextState);
        }
    }

    public void ChangeSubMenuState(bool nextState, string gameobjectName)
    {

        foreach (var item in hideableSubMenu)
        {
            if (item.gameObject.name == gameobjectName)
                item.gameObject.SetActive(nextState);
        }
    }

    public void OnClicControls()
    {
        ChangeMainMenuState(false);
        ChangeSubMenuState(true, "Controls");
        //  TODO
    }

    public void OnClosePlay()
    {
        ChangeMainMenuState(true);
        ChangeSubMenuState(false, "Level selector");

        //  TODO
    }

    public void OnCloseControls()
    {
        ChangeMainMenuState(true);
        ChangeSubMenuState(false, "Controls");

        //  TODO
    }

    public void OnClicPlay()
    {
        ChangeMainMenuState(false);

        ChangeSubMenuState(true, "Level selector");
    }

    public void OnClicEasy()
    {
        GameManager.Pause = false;
        GameManager.GameEnded = false;
        SceneManager.LoadScene("Easy");
    }

    public void OnClicNormal()
    {
        GameManager.Pause = false;
        GameManager.GameEnded = false;
        SceneManager.LoadScene("Normal");
    }

    public void OnClicHard()
    {
        GameManager.Pause = false;
        GameManager.GameEnded=false;
        SceneManager.LoadScene("Hard");
    }

    public void OnChangeMusicVolume()
    {
        GameManager.MusicVolume = musicVolumeSlide.value;
    }

    private void HighscoreSet()
    {
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    private void OnDisable()
    {
        ScoreManager.onNewHighscore -= HighscoreSet;
    }
}
