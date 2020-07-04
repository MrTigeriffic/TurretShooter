using System;
using UnityEngine;

public class CameraGyrocontrol : MonoBehaviour
{
    
    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rot;

    public float cameraSpeed;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        //gyro = Input.gyro;
        gyroEnabled = EnableGyro();

        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -cameraSpeed);
        
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot; //update local position of camera 
        }

    }

    // Update is called once per frame
    //void Update()
    //{
    //    GyroModifyCamera();
    //    Debug.Log("Rotation Rate: " + m_Gyro.rotationRate);
    //    Debug.Log("Attitude: " + m_Gyro.attitude);
    //}
    //Gyroscope is right handed. Unity is left handed.
    //Make necessary change to the camera.
    //private void GyroModifyCamera()
    //{
    //    Transform.rotation = GyroToUnity(Input.gyro.attitude);
    //}
    //private static Quaternion GyroToUnity(Quaternion q)
    //{
    //    return new Quaternion(q.x, q.y, -q.z, -q.w);
    //}

}
   
