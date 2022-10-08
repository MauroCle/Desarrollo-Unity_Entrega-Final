using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public List<GameObject> HideableMainMenu = new List<GameObject>();
    public List<GameObject> hideableSubMenu = new List<GameObject>();
    public Slider musicVolumeSlide;

    // Start is called before the first frame update
    void Start()
    {
        ChangeMainMenuState(true);
        ChangeSubMenuState(false);
        musicVolumeSlide.value = GameManager.MusicVolume;
    }

    // Update is called once per frame
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
}
