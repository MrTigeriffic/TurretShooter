using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseControl : MonoBehaviour
{
    //private Transform ThisTransform = null;
    public float RotSpeed = 50.0f;
    // Start is called before the first frame update
    public Transform Target;
    //public Transform Player;
    //private Transform Target,Player;

    float mouseX, mouseY;
    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Target = this.transform.parent;
       //Player = Target.transform.parent;
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
}
