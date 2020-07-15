using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static NewObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictonary;
    void Start()
    {
        poolDictonary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i<pool.size; i++)
            {
                GameObject obj =  Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj); //adds object to end of queue
            }

            poolDictonary.Add(pool.tag, objectPool);
        }
    }

    public object SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictonary.ContainsKey(tag))
        {
            Debug.Log("Pool with Tag " + tag + " doesn't exist!");
            return null;
        }
        GameObject objToSpawn = poolDictonary[tag].Dequeue();//puul out first element in queue
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objToSpawn.GetComponent<IPooledObject>();
        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDictonary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }

}
