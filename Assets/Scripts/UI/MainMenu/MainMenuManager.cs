using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public List<GameObject> HideableMainMenu = new List<GameObject>();
    public List<GameObject> HideableSubMenu = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

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
        foreach (var item in HideableSubMenu)
        {
            item.gameObject.SetActive(nextState);
        }
    }

    public void ChangeSubMenuState(bool nextState, string gameobjectName)
    {

        foreach (var item in HideableSubMenu)
        {
            if(item.gameObject.name == gameobjectName)
            item.gameObject.SetActive(nextState);
        }
    }

    public void OnClicControls()
    {
        ChangeMainMenuState(false);

        //  TODO
    }

    public void OnClosePlay()
    {
        ChangeMainMenuState(true);
        ChangeSubMenuState(false, "Level selector");

        //  TODO
    }

    public void OnClicPlay()
    {
        ChangeMainMenuState(false);

        ChangeSubMenuState(true,"Level selector");  
    }

    public void OnClicEasy()
    {
        // TODO
    }

    public void OnClicNormal()
    {
        // TODO
    }

    public void OnClicHard()
    {
        // TODO
    }
}
