using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro_Camera : MonoBehaviour
{
    private Gyroscope gyro;
    private bool gyroSupported;
    private Quaternion rotfix;

    [SerializeField]
    private Transform worldObj;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        gyroSupported = SystemInfo.supportsGyroscope;

        GameObject camParent = new GameObject("CamParent");
        camParent.transform.parent = transform.position;
        transform.parent = Quaternion.identity;
        if(gyroSupported )
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyro.enabled = true ;

            camParent.transform.rotation = Quaternion.Euler(90f,180f,0f);
            rotfix = new Quaternion(0,0,1,0);
        }
        gyro = Input.gyro;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroSupported && startY == a)
        {
            ResetGyroRotation();
        }
        transform.localrotaion = gyro.attitude * rotfix;
    }
    void ResetGyroRotation()
    {
        startY = transform.eulerAngles.y;
        worldObj.rotation = Quaternion.Euler(0f,startY,0f);
    }
}
