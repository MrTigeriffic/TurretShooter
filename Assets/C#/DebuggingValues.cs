using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuggingValues : MonoBehaviour
{
    [SerializeField] private Text fpsText;
    [SerializeField] private Text rotXText;
    [SerializeField] private Text rotYText;
    [SerializeField] private Text rotZText;

    private float timer;
    private float initOrientationX;
    private float initOrientationY;
    private float initOrientationZ;
    // Start is called before the first frame update
    void Start()
    {
        initOrientationX = Input.gyro.rotationRateUnbiased.x;
        initOrientationY = Input.gyro.rotationRateUnbiased.y;
        initOrientationZ = -Input.gyro.rotationRateUnbiased.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 previousEulerAngle = transform.eulerAngles;
        //Vector3 gyroInput = -Input.gyro.rotationRateUnbiased;

        //Vector3 targetEulerAngles = previousEulerAngle + gyroInput * Time.deltaTime * Mathf.Rad2Deg;
        rotXText.text = "Att: " + Input.gyro.attitude;
        rotYText.text = "Rot Y: " + Input.gyro.attitude.y;
        rotZText.text = "Rot Z: " + Input.gyro.attitude.z;

        //Debug.Log("Rot X: " + Input.gyro.rotationRateUnbiased.x);
        //Debug.Log("Rot Y: " + Input.gyro.rotationRateUnbiased.y);
        //Debug.Log("Rot Z: " + Input.gyro.rotationRateUnbiased.z);

        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps;
        }
    }
}
