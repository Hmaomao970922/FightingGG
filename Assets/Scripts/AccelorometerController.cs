using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelorometerController : MonoBehaviour
{
    float speed = 5;//位移速度

    static bool isTouched = false;
    //表示屏幕是否被点击的变量

    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount >= 1)
        {
            isTouched = true;
        }//屏幕被点击至少一次
        if(isTouched)
        {
            //表示三维的位移随重力加速度的位移向量
            Vector3 mMovement = new Vector3(
            Input.acceleration.x * speed * Time.deltaTime,
            Input.acceleration.y * speed * Time.deltaTime);
            //根据向量移动游戏对象
            transform.Translate(mMovement);
        }
        
    }
}
