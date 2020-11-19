/*Oran Chadwick November 2020
 * 
 * This script updates the crosshair position to where the mouse cursor is located on screen
 * This script will work with the turret prefab where the prefab to the crosshair and raycast out to aid the user
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    private RectTransform reticle;

    public float restingSize;
    public float maxSize;
    public float speed;
    public float currentSize;

    private void Start()
    {
        Cursor.visible = false;
        reticle = GetComponent<RectTransform>(); 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
        if (isMoving)
        {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        }
    }

    bool isMoving
    {
        get
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                return true;
            else
                return false;
        }
    }
}
