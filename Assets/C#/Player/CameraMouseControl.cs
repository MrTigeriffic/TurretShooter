using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseControl : MonoBehaviour
{
    //private Transform ThisTransform = null;
    public float RotSpeed = 50.0f;
    public float rotHead = 50.0f;
    public float angleMax = 30.0f;

    public Transform TargetCursor;
    public Transform CameraRotation;

    private Vector3 initalVector = Vector3.forward;

    float mouseX, mouseY;
    void Start()
    {
        
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //if (TargetCursor != null)
        //{
        //    initalVector = transform.position - TargetCursor.position;
        //    initalVector.y = 0;
        //}
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
        //CamRotate();
        CamRot_Test();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotSpeed;
        mouseY = Mathf.Clamp(mouseY, -25, 40);
        mouseX = Mathf.Clamp(mouseX, -75, 75);

        transform.LookAt(TargetCursor);

        TargetCursor.rotation = Quaternion.Euler(mouseY, mouseX, 0);
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
        Vector3 normal = Vector3.Cross(this.transform.position - TargetCursor.position, lookDir).normalized;

        transform.RotateAround(CameraRotation.transform.position, CameraRotation.transform.position, mouseX * Time.deltaTime);// getting some results but getting weird rotation that does not appear to be clamping on the rotating

        

    }

    void CamRot_Test()
    {
        if (TargetCursor != null)
        {
            
            mouseX += Input.GetAxis("Mouse X") * RotSpeed * Time.deltaTime;
            mouseY -= Input.GetAxis("Mouse Y") * RotSpeed * Time.deltaTime;

            mouseY = Mathf.Clamp(mouseY, -28, 3);
            mouseX = Mathf.Clamp(mouseX, -55, 55);

            CameraRotation.rotation = Quaternion.Euler(mouseY, mouseX, 0.0f);// Euler rotates from float values rather than using transform rotate with vectors.
            //Vector3 currentVector = transform.position = Target.position;
            //currentVector.y = 0;
            //float angleBetween = Vector3.Angle(initalVector, currentVector) * (Vector3.Cross(initalVector, currentVector).y > 0 ? 1 : -1);
            //float newAngle = Mathf.Clamp(angleBetween + rotateDegress, -angleMax, angleMax);

            //transform.RotateAround(Target.position, Vector3.up, rotateDegress);
        }
    }

}
