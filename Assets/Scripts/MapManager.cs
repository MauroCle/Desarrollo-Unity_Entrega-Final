using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    float rotationsDegrees = 45;
    public GameObject pivot;
    public GameObject spawned;
    public float smoothness;
    private Vector3 desiredAngleV = Vector3.zero;
    private Quaternion desiredAngleQ;


    // Start is called before the first frame update

    private void Awake()
    {
        RotateMap(1f);
    }
    void Start()
    {
        ShipColisionDetector.Collided += OnCollidedHandler;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseMap();

        if (!GameManager.Pause)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //RotateMap(RotationsDegrees * -1);
                desiredAngleV += new Vector3(-rotationsDegrees, 0, 0);
            }
                
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {   
                //RotateMap(RotationsDegrees);
                desiredAngleV += new Vector3(rotationsDegrees, 0, 0);
            }
                

            TranslateMap();
            RotateMap(smoothness);
        }
                
    }

    void RotateMap(float smoothness)
    {
        desiredAngleQ = Quaternion.Euler(desiredAngleV);
        pivot.transform.rotation = Quaternion.Slerp(pivot.transform.rotation, desiredAngleQ, smoothness);
    }

    void TranslateMap()
    {
        spawned.transform.Translate(new Vector3(10,0,0) * Time.deltaTime * GameManager.Speed);
    }

    public void PauseMap()
    {
        if(GameManager.Pause == false)
        {
            AudioControler.pitchReduced = true;
            GameManager.Pause = true;
        }
        else if (GameManager.Pause == true && GameManager.GameEnded == false)
        {
            AudioControler.pitchReduced = false;
            GameManager.Pause = false;
        }
    }

    void OnCollidedHandler()
    {
        Invoke("PauseMap", 0);
    }

    private void OnDisable()
    {
        ShipColisionDetector.Collided -= OnCollidedHandler;
    }

}
