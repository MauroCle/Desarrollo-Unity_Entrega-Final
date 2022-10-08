using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public static float points;
    public static int lastUpdate = 0;
    public UnityEvent updatePoints;
    public int updateFrequency = 1;
    public static int multiplicator=1;


    void Start()
    {
        SceneManager.sceneLoaded += resetScore;
    }

    void FixedUpdate()
    {
        if (!GameManager.Pause)
        {
            points += Time.deltaTime * multiplicator;
            if (points - lastUpdate >= updateFrequency * multiplicator)
            {
                UpdatePoints();
            }
        }
    }

    void UpdatePoints()
    {
        if ((int)points < 0)
        { 
            points = 0;
        }

        lastUpdate = (int)points;

        updatePoints?.Invoke();
    }

    void resetScore(Scene scene, LoadSceneMode mode)
    {
        points = 0;
        multiplicator = 1;
    }
}
