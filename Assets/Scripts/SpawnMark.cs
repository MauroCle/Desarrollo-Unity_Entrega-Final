using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnMark : MonoBehaviour
{
    public UnityEvent OnMarkTriggerExit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saliendo del trigger mark" + other.name);
        if (other.tag == "Wall")
        {
            Debug.Log("Saliendo del trigger mark" + other.name);
            OnMarkTriggerExit?.Invoke();
            //ActivateSpawn()
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entrando del trigger mark" + other.name);

    }


}
