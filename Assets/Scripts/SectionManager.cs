using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class SectionManager : MonoBehaviour
{

    static public event Action Delete;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (transform.position.x >= 12.57305f)
        {
            Delete?.Invoke();
            Destroy(this.gameObject);
            //Debug.Log("Eliminado " + this.gameObject.name);
        }
    }
}
