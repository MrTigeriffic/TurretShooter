using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround_2_0 : MonoBehaviour
{
    public GameObject groundObj;
    public Transform groundSpawnPoint;
    public float groundDistance; 

    private float groundLength;

    public float groundDistMin;
    public float groundDistMax;

    public ObjPler theObjPool;

    private void Start()
    {
        groundLength = groundObj.transform.localScale.z;
    }

    private void Update()
    {
        if (transform.position.z > groundSpawnPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - groundLength - groundDistance);
            //Instantiate(groundObj,transform.position,transform.rotation);
            GameObject newGround = theObjPool.GetPooledObject();

            newGround.transform.position = transform.position;
            newGround.transform.rotation = transform.rotation;
            newGround.SetActive(true);
        }
    }
}
