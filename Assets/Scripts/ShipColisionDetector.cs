using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipColisionDetector : MonoBehaviour
{
    static public event Action Collided;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Colision");

            Collided?.Invoke();
        }
    }
}
