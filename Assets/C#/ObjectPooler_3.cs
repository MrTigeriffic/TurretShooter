using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler_3 : MonoBehaviour
{
   [System.Serializable]

   public class Pool
    {
        public string type;
        public GameObject prefab;
        public int size; //number of objects
    }

    public static ObjectPooler_3 instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary; //Queue more efficient than Instantiate
    GameObject objectToSpawn;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();//object pool
            for(int i = 0; i<pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);//spawning at the start 
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            //add the object pool to the pool dictonary
            poolDictionary.Add(pool.type, objectPool);
        }
    }

    //spawn from the object pool
    public GameObject SpawnFromPool(string type, Vector3 position, Quaternion rotation)
    {
        //adding the object to the dictonary and then returning the object 
        if (!poolDictionary.ContainsKey(type)){
            Debug.LogWarning("Pool with type " + type + " does not exist");
            return null;
        }
        objectToSpawn = poolDictionary[type].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[type].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
