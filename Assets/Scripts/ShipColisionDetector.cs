using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipColisionDetector : MonoBehaviour
{
    static public event Action Collided;
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] ParticleSystem propeller;
    [SerializeField] GameObject mesh;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.onGameOver += PlayerDeath;
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

    void PlayerDeath()
    {
        explosionEffect.gameObject.SetActive(true);
        propeller.gameObject.SetActive(false);
        mesh.SetActive(false);
    }
}
