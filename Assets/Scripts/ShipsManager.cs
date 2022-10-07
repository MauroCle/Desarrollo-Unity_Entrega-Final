using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : MonoBehaviour
{
    public GameObject mainShip;
    Vector3 MainShipOriginarPosition;
    public GameObject topShip;
    public GameObject[] lateralShips = new GameObject[2];
    bool topShipState = false;
    bool lateralShipsState = false;
    bool CentredShip = false;

    // Start is called before the first frame update
    void Start()
    {
        MainShipOriginarPosition = mainShip.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Pause)
        {
            if (!CentredShip)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                    DespawnLastShip();

                if (Input.GetKeyDown(KeyCode.Mouse0))
                    SpawnShips();

                if (Input.GetKeyDown(KeyCode.Space))
                    DespawnAllShips();
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                DespawnAllShips();
                CenterMainShip();

            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ResetMainShip();
            }
        }
    }

    void SpawnShips()
    {
        if (topShipState == true)
        {
            for (int i = 0; i < lateralShips.Length; i++)
            {
                lateralShips[i].SetActive(true);
            }
            lateralShipsState = true;
            PointsManager.multiplicator = 4;

        }
        else
        {
            topShip.SetActive(true);
            topShipState = true;
            PointsManager.multiplicator = 2;
        }
    }

    void DespawnLastShip()
    {
        if (lateralShipsState == true)
        {
            for (int i = 0; i < lateralShips.Length; i++)
            {
                lateralShips[i].SetActive(false);

            }
            lateralShipsState = false;
            PointsManager.multiplicator = 2;
        }
        else if (topShipState == true)
        {
            topShip.SetActive(false);
            topShipState = false;
            PointsManager.multiplicator = 1;
        }
    }

    void DespawnAllShips()
    {
        topShip.SetActive(false);
        topShipState = false;
        lateralShipsState = false;
        for (int i = 0; i < lateralShips.Length; i++)
        {
            lateralShips[i].gameObject.SetActive(false);
        }
        PointsManager.multiplicator = 1;

    }

    void CenterMainShip()
    {
        Transform aux = mainShip.transform;
        mainShip.transform.position = new Vector3(aux.position.x, 2.97801f, aux.position.z);
        CentredShip = true;
        PointsManager.multiplicator = -2;
    }

    void ResetMainShip()
    {
        mainShip.transform.position = MainShipOriginarPosition;
        CentredShip = false;
        PointsManager.multiplicator = 1;
    }
}
