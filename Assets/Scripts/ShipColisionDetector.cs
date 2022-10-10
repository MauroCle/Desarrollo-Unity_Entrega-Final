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

    void Start()
    {
        Collided += PlayerDeath;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            PlayerDeath();
            Collided?.Invoke();
        }
    }

    void PlayerDeath()
    {
        explosionEffect.gameObject.SetActive(true);
        propeller.gameObject.SetActive(false);
        mesh.SetActive(false);
        
    }

    private void OnDisable()
    {
        Collided -= PlayerDeath;
    }
}
