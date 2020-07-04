// Oran Chadwick 18/06/2020
// Create and Destroy class for ground tiles to create a repeating effect.
//Upon further research this method of create and destroy is not optimised for mobile development 

//19/06/2020

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InfiniteGround : MonoBehaviour
{
    public Transform ground1Obj;
    public Transform cubeSpawn;
    private int count;
    private int currentCount;
    private Vector3 nextCubeSpawn;
    private Vector3 lastPosition;

    private int randX;
    //private GameObject obj;
    //private float timer = 10f;
    //private GameObject newInstance;
    // First attempt of repeating bg worked but the destroy was not working as desired.

    //private BoxCollider2D groundCollider;
    //private float groundHorizontalLength;

    //public GameObject[] ground;
    //public float groundSpeed = 100f;

    //private Transform startPos;
    //private Vector3 endPos;
    //private Vector2 screenBounds;
    //public Rigidbody rb;

    //private bool isMoving = false;


    void Start()
    {
        StartCoroutine(InstantiatefloorObj());
        StartCoroutine(InstantiateEnemyObj());
        //StartCoroutine(spawnTile());

        //groundCollider = GetComponent<BoxCollider2D>();
        //groundHorizontalLength = groundCollider.size.x;

        //rb = GetComponent<Rigidbody>();


        //foreach (GameObject obj in ground)
        //{
        //    loadChildObjects(obj);
        //}
        //startPos = GetComponent<Transform>();
        //transform.position = new Vector3(0, 0, groundSpeed * Time.deltaTime);

    }

    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer >= 0f)
        //{

        //    timer -= Time.deltaTime;
        //    if (timer <= 0f)
        //    {
        //        Debug.Log("Time");
        //        //StartCoroutine(spawnTile());
        //        Destruction();
        //    }
        //}
        //Not desired outcome as once timer reaches its value gameobject destroys and does not get created again
        // Tags appear to be what I need to look into to destroy 
        //Debug.Log(gameObject.name + " " + " Child Count: " + gameObject.transform.childCount);
        //if (transform.position.x < -groundHorizontalLength)
        //{
        //    RepositionBG();
        //}

        //Code to Stop ground when game over

        //transform.position += new Vector3(0, 0, groundSpeed * Time.deltaTime);
        //Debug.Log(startPos.position.z);
        //if (startPos.position.z > 1000)
        //{
        //    transform.position = transform.position + new Vector3(0, 0, 0);
        //}
        //StartCoroutine(InstantiateEnemyObj());
    }

    IEnumerator InstantiatefloorObj()
    {
        count++;
        for (int i = 0; i < 10; i++)
        {
            Instantiate(ground1Obj, new Vector3(0, 0, i * 10000f), Quaternion.identity);
            //ground1Obj.SetParent(ground1Obj.transform);
            
            //Debug.Log(count);
            if (i == 10)
            {
                count = currentCount;
                Debug.Log("Current Count: " + currentCount);
            }
        }
        if (count > currentCount)
        {
            yield return new WaitForSeconds(5.0f);
            //Destroy(ground1Obj);
            Debug.Log("5 seconds");
        }
        yield return null;
    }
    IEnumerator InstantiateEnemyObj()
    {
        randX = Random.Range(-500, 501);
        nextCubeSpawn.z = Random.Range(-1000, 1000);
        nextCubeSpawn.y = 55f;
        nextCubeSpawn.x = randX;
        yield return new WaitForSeconds(1);
        Instantiate(cubeSpawn, nextCubeSpawn, cubeSpawn.rotation); //cube to randomly spawn on the x of the ground tile
    }

    //private void RepositionBG()
    //{
    //    System.Numerics.Vector2 groundOffSet = new System.Numerics.Vector2(groundHorizontalLength * 2f, 0);

    //    //transform.position = (System.Numerics.Vector2)transform.position + groundOffSet;
    //}

    //void Destruction()
    //{
    //    Debug.Log("Destroy");
    //    Destroy(gameObject);
    //}

    //IEnumerator spawnTile()
    //{
    //    randX = Random.Range(-500, 501);
    //    nextCubeSpawn = nextGroundSpawn;
    //    nextCubeSpawn.y = 55f;
    //    nextCubeSpawn.x = randX;
    //    yield return new WaitForSeconds(1);//time measured in seconds
    //    Instantiate(ground1Obj, nextGroundSpawn, ground1Obj.rotation);
    //    Instantiate(cubeSpawn, nextCubeSpawn, cubeSpawn.rotation); //cube to randomly spawn on the x of the ground tile
    //    nextGroundSpawn.z -= 1000;
    //    Coroutine b = StartCoroutine(destroyTile());
    //}

    //IEnumerator destroyTile()
    //{
    //    float f = 0.0f;
    //    float start = Time.time;

    //    while (f < 5.0f)
    //    {
            
    //        yield return new WaitForSeconds(1.0f);
    //        f = f + 1.0f;
    //        Destroy(ground1Obj);
    //    }
    //    float t = Time.time - start;
    //    yield return null;
    //}
    //void loadChildObjects(GameObject obj)
    //{
    //    float groundLength = obj.GetComponent<Renderer>().bounds.size.z /2;
    //    Debug.Log(groundLength);
    //    //int childsNeeded = (int)Mathf.Ceil();
    //    GameObject clone = Instantiate(obj) as GameObject;
    //    for(int i =0; i<= 7; i++)
    //    {
    //        Debug.Log(clone + " " + i);
    //        //GameObject c = Instantiate(clone) as GameObject;
    //        //c.transform.SetParent(obj.transform);
    //        //c.transform.position = new Vector3(groundLength * i, obj.transform.position.y, obj.transform.position.z);
    //        //c.name = obj.name + i;
    //    }
    //    //Destroy(clone);
    //}


}
