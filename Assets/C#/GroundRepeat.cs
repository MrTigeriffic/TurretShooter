using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    public float grndRepeat = 1f;

    void Start()
    {

        InvokeRepeating("Ground", grndRepeat, grndRepeat);
    }

    void Ground()
    {
        //Instantiate(groundObj, transform.position, Quaternion.identity);
        //find a ground tile that is not active
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = transform.position * 2;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
