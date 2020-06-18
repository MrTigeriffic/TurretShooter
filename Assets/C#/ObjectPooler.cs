//Oran Chadwick 18/06/2020
// A generic object pooling script to hadle the object poling of various aspects of the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    public GameObject pooledObj;
    public int pooledAmount = 20;

    public bool willGrow = true;

    List<GameObject> pooledObjects;

    private void Awake()
    {
        current = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i <pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i =0; i< pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObj); //creating an Object and adding ti to a GameObject
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
