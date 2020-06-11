using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        //Input.GetButtonDown("Fire1")
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Touch Begin");

            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Button Touch");
            }

            Touch touch = Input.GetTouch(0);
            Shoot();
                       

            //Debug.Log(Input.GetTouch(0).position);
        }
       
    }
    void Shoot()
    {
        RaycastHit hit;
        Debug.Log("Fire!");
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
           if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
