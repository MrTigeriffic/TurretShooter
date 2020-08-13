using System;
using UnityEngine;

public class CameraGyrocontrol : MonoBehaviour
{
    
    private bool gyroEnabled;
    private Gyroscope gyro;
    //private GameObject cameraContainer;
    private Quaternion rot;

    private float initOrientationX;
    private float initOrientationY;
    private float initOrientationZ;

    private float maxRotYPos = 75f;
    private float maxRotYNeg = -75f;
    //private Transform ThisTransform = null;// rotation speed delay setup
    //public Transform Target = null;


    public GameObject playerView;
    public GameObject playerNode;
    public float cameraSpeed;


    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //cameraContainer = new GameObject("Camera Container");
        //cameraContainer.transform.position = transform.position;
       //transform.SetParent(cameraContainer.transform);
        gyro = Input.gyro;
        gyroEnabled = EnableGyro();

        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -cameraSpeed);
        initOrientationX = Input.gyro.rotationRateUnbiased.x;
        initOrientationY = Input.gyro.rotationRateUnbiased.y;
        initOrientationZ = -Input.gyro.rotationRateUnbiased.z;
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
           // cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            //rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            //transform.localRotation = gyro.attitude * rot; //update local position of camera 
            //playerNode.transform.Rotate(0, initOrientationY - Input.gyro.rotationRateUnbiased.y * cameraSensitivity, 0);
            //playerView.transform.Rotate(initOrientationX - Input.gyro.rotationRateUnbiased.x * cameraSensitivity, 0, initOrientationZ + Input.gyro.rotationRateUnbiased.z * cameraSensitivity);
            //rotation has undesired effects but starting position from where player hold their phone works

            //11/08/2020 Code below has desired effects with gyroscope and z axis locked
            Vector3 previousEulerAngle = transform.eulerAngles;
            Vector3 gyroInput = -Input.gyro.rotationRateUnbiased;

            Vector3 targetEulerAngles = previousEulerAngle + gyroInput * Time.deltaTime * Mathf.Rad2Deg;
            targetEulerAngles.z = 0.0f;
            transform.eulerAngles = targetEulerAngles;
        }

        //Quaternion DestRot = Quaternion.LookRotation(Target.position - ThisTransform.position, Vector3.up);
        //ThisTransform.rotation = Quaternion.RotateTowards(ThisTransform.rotation, DestRot, cameraSensitivity * Time.deltaTime);// look delay to be applied to gun when rotating. Needs tweaking
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
   
