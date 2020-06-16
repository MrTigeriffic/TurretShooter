using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround : MonoBehaviour
{
    public Transform ground1Obj;
    public Transform cubeSpawn;
    private Vector3 nextGroundSpawn;
    private Vector3 nextCubeSpawn;

    private int randX;
    private float timer;
        
    void Start()
    {
        StartCoroutine(spawnTile());
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            Destroy(gameObject);
        }
        //Not desired outcome as once timer reaches its value gameobject destroys and does not get created again
        // Tags appear to be what I need to look into to destroy 

    }

    IEnumerator spawnTile()
    {
        randX = Random.Range(-500, 501);
        nextCubeSpawn = nextGroundSpawn;
        nextCubeSpawn.y = 55f;
        nextCubeSpawn.x = randX;

        yield return new WaitForSeconds(1);//time measured in seconds
        Instantiate(ground1Obj, nextGroundSpawn, ground1Obj.rotation);
        Instantiate(cubeSpawn, nextCubeSpawn, cubeSpawn.rotation); //cube to randomly spawn on the x of the ground tile

        nextGroundSpawn.z -= 1000;
        StartCoroutine(spawnTile());
    }
}
