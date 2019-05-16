using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 一个测试倒计时的类
/// </summary>
public class TestCountDown : MonoBehaviour
{
    private bool IsTiming;  //是否开始计时
    private float CountDown; //倒计时

    void Update()
    {
        EixtDetection(); //调用 退出检测函数
    }


    /// <summary>
    /// 退出检测
    /// </summary>
    private void EixtDetection()
    {
        if (Input.GetKeyDown(KeyCode.Escape))            //如果按下退出键
        {
            if (CountDown == 0)                          //当倒计时时间等于0的时候
            {
                CountDown = Time.time;                   //把游戏开始时间，赋值给 CountDown
                IsTiming = true;                        //开始计时
              //  LoginDate.ShowToast("再按我就把自己关掉"); //显示提示信息 —— 这里的提示方法，需要根据自己需求来完成（用你自己所需要的方法完成提示）
            }
            else
            {
                Application.Quit();                      //退出游戏
            }
        }

        if (IsTiming) //如果 IsTiming 为 true 
        {
            if ((Time.time - CountDown) > 2.0)           //如果 两次点击时间间隔大于2秒
            {
                CountDown = 0;                           //倒计时时间归零
                IsTiming = false;                       //关闭倒计时
            }
        }
    }

}