using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    float RotationsDegrees = 45;
    public GameObject pivot;
    public GameObject spawned;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseMap(GameManager.Pause);

        if (!GameManager.Pause)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                RotateMap(RotationsDegrees * -1);

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                RotateMap(RotationsDegrees);

            TranslateMap();
        }
    }

    void RotateMap(float degrees)
    {
    pivot.transform.localRotation *= Quaternion.Euler(degrees, 0, 0);
    }

    void TranslateMap()
    {
        spawned.transform.Translate(new Vector3(10,0,0) * Time.deltaTime * GameManager.Speed);
    }

    void PauseMap(bool state)
    {
        if(state == false)
        {
            //lastSpeed = GameManager.Speed;
           // GameManager.Speed = 0;
            GameManager.Pause = true;
        }
        else
        {
           // GameManager.Speed = lastSpeed;
            GameManager.Pause = false;
        }
    }

}
