using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFire : MonoBehaviour
{
    private Transform barrelRoll;
    
    bool rotating = false;
    public float initialSpeed;
    private float topSpeed = 0f;
    //private Vector3 relativePosition;
    //private Quaternion targetRotation;

    //private float easeStrength = 0.5f;

    void Start()
    {
        barrelRoll = GetComponent<Transform>();
    }


    void Update()
    {
        if (Input.GetMouseButton(0)){
            rotating = true;
            initialSpeed += 0.03f;
            transform.Rotate(0, 0, initialSpeed);
            if (initialSpeed > 8f)
            {
                initialSpeed = 8f;
                topSpeed = 8f;
            }
            //initialSpeed = Mathf.Lerp(initialSpeed, 5, easeStrength);

            //float rotation = initialSpeed * brlSpeed * Time.deltaTime;
            //transform.Rotate(0, 0, rotation); 

            //transform.rotation = Quaternion.Slerp(barrelRoll.rotation, barrelRoll.rotation, 0);
            //relativePosition = barrelRoll.position - transform.position;
            //targetRotation = Quaternion.LookRotation(relativePosition);

            //brlSpeed = 0;

        }
        else
        {
            //rotating = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            if (topSpeed == 8f)
            {
                Debug.Log("Wind Down");
                rotating = true;
                initialSpeed -= 0.5f;
                transform.Rotate(0, 0, initialSpeed);
                if (topSpeed <= 0f)
                {
                    
                    topSpeed = 0f;
                    initialSpeed = 0f;
                    rotating = false;
                }
            }

        }
        //if (rotating)
        //{
        //    brlSpeed += Time.deltaTime * initialSpeed;
        //    transform.rotation = Quaternion.Lerp(barrelRoll.rotation, targetRotation, brlSpeed);
        //}

    }
    private void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        rotating = false;        
        
    }
}
