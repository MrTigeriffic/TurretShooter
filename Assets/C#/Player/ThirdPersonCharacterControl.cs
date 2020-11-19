using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float turnSpeed;
    private Transform ThisTransform = null;

    public Transform TurretTarget = null;
    void Start()
    {
        ThisTransform = GetComponent<Transform>();
    }

    
    void Update()
    {
        Quaternion DestRot = Quaternion.LookRotation(TurretTarget.position - ThisTransform.position, Vector3.up);

        ThisTransform.rotation = Quaternion.RotateTowards(ThisTransform.rotation, DestRot, turnSpeed * Time.deltaTime);
        //PlayerMovement();
    }

    private void PlayerMovement()
    {
        //float hor = Input.GetAxis("Horizontal");
        //float ver = Input.GetAxis("Vertical");
        //Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized * turnSpeed * Time.deltaTime;
        Quaternion DestRot = Quaternion.LookRotation(TurretTarget.position - ThisTransform.position, Vector3.up);

        ThisTransform.rotation = Quaternion.RotateTowards(ThisTransform.rotation, DestRot, turnSpeed * Time.deltaTime);
        //throw new NotImplementedException();
    }
}
