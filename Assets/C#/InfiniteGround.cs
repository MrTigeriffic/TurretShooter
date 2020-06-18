// Oran Chadwick 18/06/2020
// Create and Destroy class for ground tiles to create a repeating effect.
//Upon further research this method of create and destroy is not optimised for mobile development 

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
    private float timer = 10f;
    //private GameObject newInstance;
    // First attempt of repeating bg worked but the destroy was not working as desired.

    //private BoxCollider2D groundCollider;
    //private float groundHorizontalLength;

    void Start()
    {
        StartCoroutine(spawnTile());
        //groundCollider = GetComponent<BoxCollider2D>();
        //groundHorizontalLength = groundCollider.size.x;
    }

    void Update()
    {
        //timer += Time.deltaTime;
        if (timer >= 0f)
        {

            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Debug.Log("Time");
                //StartCoroutine(spawnTile());
                Destruction();

            }

        }
        //Not desired outcome as once timer reaches its value gameobject destroys and does not get created again
        // Tags appear to be what I need to look into to destroy 
        //Debug.Log(gameObject.name + " " + " Child Count: " + gameObject.transform.childCount);

        //if (transform.position.x < -groundHorizontalLength)
        //{
        //    RepositionBG();
        //}

    }

    //private void RepositionBG()
    //{
    //    System.Numerics.Vector2 groundOffSet = new System.Numerics.Vector2(groundHorizontalLength * 2f, 0);

    //    //transform.position = (System.Numerics.Vector2)transform.position + groundOffSet;
    //}

    void Destruction()
    {
        Debug.Log("Destroy");
        Destroy(gameObject);
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
