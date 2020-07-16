﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float objectDistance = -40f;
    [SerializeField] private float despawnDistance = -110f;

    private bool canSpawnGround = true;
    //private Rigidbody rb;

    void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;

        //if the component the object is attached to is "Ground" 
        if(transform.position.z <= objectDistance && transform.tag == "Ground" && canSpawnGround)
        {
            ObjectSpawner.instance.SpawnGround();
            canSpawnGround = false;

        }
        if(transform.position.z <= despawnDistance)//make object invisible when off screen
        {
            canSpawnGround = true;
            gameObject.SetActive(false);
        }
    }
}
