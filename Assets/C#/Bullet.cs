using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 5;
    public float bulletDuration = 3f;

    private float durationTimer;
    // Start is called before the first frame update
    void OnEnable()//enables on the instantiated bullet
    {
        bulletDuration = durationTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           GameObject gameObject = BulletPool.Instance.GetBullet();//This will need to be added to the turret code
           transform.position += transform.forward * speed * Time.deltaTime;
        }
        bulletDuration -= Time.deltaTime;

        if (bulletDuration <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
