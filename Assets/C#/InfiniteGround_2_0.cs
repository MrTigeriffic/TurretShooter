using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround_2_0 : MonoBehaviour
{
    public GameObject[] ground;
    public float groundSpeed = 100f;

    private Transform startPos;
    private Vector3 endPos;
    private int cloneCount = 0;

    void Start()
    {

        foreach (GameObject obj in ground)
        {
            loadChildObjects(obj);
        }
    }

    void Update()
    {
        //transform.position += new Vector3(0, 0, groundSpeed * Time.deltaTime);

    }

    void loadChildObjects(GameObject obj)
    {
        
        
         //cloning the child object 
        for (int i = 0; i <= ground.Length; i ++)
        {
            GameObject clone = Instantiate(obj);
            cloneCount++;
            //c.transform.SetParent(obj.transform);
            //c.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z * 100);
            //c.name = obj.name + i;
            Debug.Log(obj.name + " " + i);
            if(cloneCount > 10)
            {
                Destroy(clone);
            }
            break;
        }
        //if (cloneCount > 10)
        //{
            //Destroy(c);
        //}
        //Destroy(clone);
        //Destroy(obj.GetComponent<Renderer>());
    }
}
