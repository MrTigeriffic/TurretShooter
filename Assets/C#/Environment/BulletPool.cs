using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool instance;
    public static BulletPool Instance    { get { return instance; }    }

    public GameObject bulletPrefab;
    public int bulletAmount = 20;

    private List<GameObject> bullets;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        bullets = new List<GameObject>(bulletAmount);

        for (int i =0; i < bulletAmount; i++){
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);

            
        }
    }

    // Update is called once per frame
   public GameObject GetBullet()
    {
        foreach(GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        bullets.Add(prefabInstance);

        return prefabInstance;
        //Debug.Log("Bullet pool");
        //return null;
    }
}
