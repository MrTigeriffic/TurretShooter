using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseControl : MonoBehaviour
{
    //private Transform ThisTransform = null;
    public float RotSpeed = 50.0f;
    public float rotHead = 50.0f;

    public Transform Target;
    public Transform rotAround;


    float mouseX, mouseY;
    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (Input.GetMouseButton(1))
        //{
        //    if(Input.GetAxis("Mouse X")> 0)
        //    {
        //        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, Input.GetAxisRaw("Mouse Y")* Time.deltaTime * speed);
        //    }
        //    else if (Input.GetAxis("Mouse X") < 0)
        //    {
        //        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        //    }
        //}

        CamControl();
        CamRotate();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotSpeed;
        mouseY = Mathf.Clamp(mouseY, -25, 40);
        mouseX = Mathf.Clamp(mouseX, -75, 75);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        //Player.rotation = Quaternion.Euler(0, mouseX, 0);

        //Quaternion DestRot = Quaternion.LookRotation(Target.position - this.transform.position, Vector3.up);

        //Target.rotation = Quaternion.RotateTowards(Player.transform.rotation, DestRot, RotSpeed * Time.deltaTime);

    }
    void CamRotate()
    {
        //Vector3 pos = this.transform.position;
        //Quaternion rot = Quaternion.AngleAxis(angle, axis);//get desired rotation
        //Vector3 dir = pos - centre;//find current direction relative 
        //dir = rot * dir; //rotate the direction
        //this.transform.position = centre + dir;//define new position 

        //Quaternion myRot = transform.rotation;
        //transform.rotation *= Quaternion.Inverse(myRot) * rot * myRot; //rotate object to keep looking at center

        Vector3 lookDir = new Vector3(0.0f, 0.0f, 0.0f);
        mouseX += Input.GetAxis("Mouse X") * RotSpeed * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * RotSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -25, 40);
        mouseX = Mathf.Clamp(mouseX, -75, 75);
        lookDir = Quaternion.Euler(0.0f, mouseX, 0.0f) * lookDir;

        transform.RotateAround(rotAround.transform.position, rotAround.transform.up, Input.GetAxis("Mouse X") * rotHead * Time.deltaTime);// getting some results but getting weird rotation that does not appear to be clamping on the rotating
        transform.RotateAround(rotAround.transform.position, rotAround.transform.up, Input.GetAxis("Mouse Y") * rotHead * Time.deltaTime);
        

    }

}
