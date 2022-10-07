using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawned;
    public int safeChance = 30;
    public bool easierOnFast = true;
    public float easierMultiplicator = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        SectionManager.Delete += NewInstance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewInstance()
    {
        int aux = Random.Range(0, 100);
        if (easierOnFast && (GameManager.Speed / GameManager.MaxSpeed) >= 0.5)
            InstanceGenerator(aux, (int)(safeChance * easierMultiplicator));
        else
        InstanceGenerator(aux, safeChance);
    }

    public void InstanceGenerator(int random, int actualSafeChance)
    {
        if (random <= actualSafeChance)
        {
            Instantiate(GameManager.staticTiles[0], this.transform.position, this.transform.rotation, spawned.transform);
        }
        else
        {
            int aux2 = Random.Range(0, GameManager.staticTiles.Count);

            Instantiate(GameManager.staticTiles[aux2], this.transform.position, this.transform.rotation, spawned.transform);
        }
    }

}
