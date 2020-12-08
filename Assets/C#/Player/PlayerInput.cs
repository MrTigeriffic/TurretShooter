/* Oran Chadwick Nov 2020
 * This Script handles the firing of the Turret and Turret animations.
 * The turret will produce a raycast out from its forward vector and if it collides (hits) any enemy objects it will detect 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{
    //public float damage = 10f;
    //public float initialSpeed;

    public float fireRate = 15f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0;
    [SerializeField]
    private Transform crossHair;
    [SerializeField]
    private Transform turretBarrel;

    // Update is called once per frame
    //void Update()
    //{
    //    //Input.GetButtonDown("Fire1") //UI Button pressed
    //    //if (Input.touchCount > 0 && Time.time >= nextTimeToFire && (Input.GetTouch(0).phase == TouchPhase.Began | Input.GetTouch(0).phase == TouchPhase.Stationary))
    //    //{
    //    //    //Debug.Log("Touch Begin");

    //    //    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) )
    //    //    {
    //    //        //Debug.Log("Button Touch");
    //    //        nextTimeToFire = Time.time + 1f / fireRate;
    //    //        Shoot();
    //    //    }

    //    //    //Touch touch = Input.GetTouch(0);
    //    //    //Debug.Log(Input.GetTouch(0).position);
    //    //}
    //    //____________________Touch Control  

    //    //Mouse Controls




    //}
    private void Awake()
    {
        turretBarrel = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(turretBarrel.transform.position, forward, Color.cyan);
        if (Input.GetMouseButtonDown(0))
        {

            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        //Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("Fire!");
        if (Physics.Raycast(turretBarrel.transform.position, turretBarrel.transform.forward,out hit)) 
        {
           Debug.Log(hit.transform.name);
            if (hit.collider != null)
            {
                //turretBarrel.rotation = Quaternion.LookRotation(hit.point);
                crossHair.transform.position = fpsCam.WorldToViewportPoint(hit.point);
            }


           Target target = hit.transform.GetComponent<Target>();
           if(target != null)// only find target component and then take damage
            {
                //target.TakeDamage(damage);
                ScoreManager.instance.AddScore();
            }
        }
        
    }
    

    //not needed currently
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
        }
    }
}
