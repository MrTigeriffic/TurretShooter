using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInput : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") | Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Shoot();
            //Debug.Log(Input.mousePosition);
        }
       
    }
    void Shoot()
    {
        RaycastHit hit;
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
