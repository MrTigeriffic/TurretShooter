using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private bool spawningObject = false;//check to see if we can object or not don't want 

    [SerializeField] private float groundSpawnDistance = 50f;
    public static ObjectSpawner instance;

    private void Awake()
    {
        instance = this;

    }
    public void SpawnGround()
    {
        //creating the new ground tile of type Ground with position and same quaternion value
        ObjectPooler_3.instance.SpawnFromPool("Ground", new Vector3(0, 0, 100f), Quaternion.identity);

    }
}
