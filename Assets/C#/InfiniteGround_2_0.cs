using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGround_2_0 : MonoBehaviour
{
    public float groundSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, groundSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, groundSpeed * Time.deltaTime);
    }
}
