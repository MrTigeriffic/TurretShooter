using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{
    //public float damage = 10f;
    
    public float fireRate = 15f;
    public Transform turrTransform;
    public float initialSpeed;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0;



    // Update is called once per frame
    void Update()
    {
        //Input.GetButtonDown("Fire1") //UI Button pressed
        //if (Input.touchCount > 0 && Time.time >= nextTimeToFire && (Input.GetTouch(0).phase == TouchPhase.Began | Input.GetTouch(0).phase == TouchPhase.Stationary))
        //{
        //    //Debug.Log("Touch Begin");

        //    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) )
        //    {
        //        //Debug.Log("Button Touch");
        //        nextTimeToFire = Time.time + 1f / fireRate;
        //        Shoot();
        //    }

        //    //Touch touch = Input.GetTouch(0);
        //    //Debug.Log(Input.GetTouch(0).position);
        //}
        //____________________Touch Control  

        //Mouse Controls

        if (Input.GetMouseButtonDown(0))
        {

            nextTimeToFire = Time.time + 1f / fireRate;
            //Shoot();
            
        }


    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        //Debug.Log("Fire!");
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) 
        {
            Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
           if(target != null)// only find target component and then take damage
            {
                //target.TakeDamage(damage);
                ScoreManager.instance.AddScore();
            }
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.cyan);
    }
    

    //not needed currently
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
        }
    }
}
