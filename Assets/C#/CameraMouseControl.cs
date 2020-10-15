using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseControl : MonoBehaviour
{
    private Transform ThisTransform = null;
    public float RotSpeed = 50.0f;
    // Start is called before the first frame update

    public Transform Target = null;
    void Start()
    {
        ThisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
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

        Quaternion DestRot = Quaternion.LookRotation(Target.position - ThisTransform.position, Vector3.up);

        ThisTransform.rotation = Quaternion.RotateTowards(ThisTransform.rotation, DestRot, RotSpeed * Time.deltaTime);
    }
}
