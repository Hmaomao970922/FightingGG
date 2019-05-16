using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSlam : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //如果用了GyroDroid
        //SensorHelper.ActivateRotation();//激活传感器


        //如果没用GyroDroid
        Input.gyro.enabled = true;  //开启陀螺仪        
        Input.gyro.updateInterval = 0.05f;//设置陀螺仪的更新时间，即隔 0.05秒更新一次数据

    }
    // Update is called once per frame
    void Update()
    {
        //transform.rotation = SensorHelper.rotation;
        //让物体旋转和手机陀螺仪的旋转一致

        //或者 没有GyroDroid  平滑旋转
        transform.rotation = Quaternion.Slerp(transform.rotation, Input.gyro.attitude, 0.1f);

    }
}