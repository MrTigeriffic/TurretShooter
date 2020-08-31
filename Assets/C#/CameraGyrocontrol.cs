using System;
using UnityEngine;

public class CameraGyrocontrol : MonoBehaviour
{

    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rot;
    private float initOrientationX;
    private float initOrientationY;
    private float initOrientationZ;

    public GameObject playerView;
    public float lookUpMax = -60f;
    public float lookDownMax = 60f;
    public float lookLeftMax = -180f;
    public float lookRightMax = 180f;
    public GameObject playerNode;
    public float cameraSpeed;

   
    //private Transform ThisTransform = null;// rotation speed delay setup
    //private GameObject cameraContainer;
    //public Transform Target = null;

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

    void Update()
    {
        if (gyroEnabled)
        {
            //11/08/2020 Code below has desired effects with gyroscope and z axis locked
            Vector3 previousEulerAngle = transform.eulerAngles;
            Vector3 gyroInput = -Input.gyro.rotationRateUnbiased;
            Vector3 targetEulerAngles = previousEulerAngle + gyroInput * Time.deltaTime * Mathf.Rad2Deg;
            targetEulerAngles.x += Mathf.Clamp(targetEulerAngles.x, lookDownMax, lookUpMax);
            targetEulerAngles.y += Mathf.Clamp(targetEulerAngles.y, lookLeftMax, lookRightMax);
            targetEulerAngles.z = 0.0f;

            //transform.localRotation = gyro.attitude * rot; //update local position of camera 
            //playerNode.transform.Rotate(0, initOrientationY - Input.gyro.rotationRateUnbiased.y * cameraSensitivity, 0);
            //playerView.transform.Rotate(initOrientationX - Input.gyro.rotationRateUnbiased.x * cameraSensitivity, 0, initOrientationZ + Input.gyro.rotationRateUnbiased.z * cameraSensitivity);
            //rotation has undesired effects but starting position from where player hold their phone works
            //transform.eulerAngles = targetEulerAngles;

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
   
