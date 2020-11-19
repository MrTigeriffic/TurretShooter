using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFire : MonoBehaviour
{
    private Transform barrelRoll;
    private float topSpeed = 0f;
    public float range = 100f;
    bool rotating = false;

    public float initialSpeed;
    public float damage = 10f;    

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
            RaycastSingle();
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
                //Debug.Log("Wind Down");
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
        Debug.Log("_Mouse Up_");
        rotating = false;
        //muzzleFlash.Stop();
    }

    private void RaycastSingle()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origin, direction * 10, Color.red);
        Ray ray = new Ray(origin, direction);

        RaycastHit hit;
        //Debug.Log("Fire!");
        if (Physics.Raycast(ray, out hit,range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)// only find target component and then take damage
            {
                target.TakeDamage(damage);
                //ScoreManager.instance.AddScore();
            }
        }
    }
}
