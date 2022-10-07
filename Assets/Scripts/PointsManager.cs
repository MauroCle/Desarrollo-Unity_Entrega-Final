using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointsManager : MonoBehaviour
{
    float points;
    public static int lastUpdate = 0;
    public UnityEvent updatePoints;
    public int updateFrequency = 1;
    public static int multiplicator=1; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

}
