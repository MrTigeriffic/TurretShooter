using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour, IPooledObject
{
    private Rigidbody rgbd;
    public void OnObjectSpawn()
    {
        rgbd = GetComponent<Rigidbody>();
        rgbd.velocity = new Vector3(1000, 0, 110);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
