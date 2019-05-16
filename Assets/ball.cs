using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public GameObject gg;
    public GameObject pikachu;
    public GameObject targetcube;
    public float downPosX;
    public float downPosY;
    public float upPosX;
    public float upPosY;
    public Vector3 resetPos;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    void StartSet()
    {
        Debug.Log("设置精灵球位置");
        resetPos = this.transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            downPosX = Input.mousePosition.x;
            downPosY = Input.mousePosition.y;
        }

        if(Input.GetMouseButtonUp(0))
        {
            upPosX = Input.mousePosition.x;
            upPosY = Input.mousePosition.y;
            shootEnd();
        }
    }
    void shootEnd()
    {
        targetcube.transform.position = new Vector3((upPosX - downPosX) * 0.1F, (upPosY - downPosY) * 0.05F, (upPosY - downPosY) * 0.1F);
        this.GetComponent<Rigidbody>().velocity = targetcube.transform.position;
        this.GetComponent<Rigidbody>().useGravity = true;
    }
    void ResetBall()
    {
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.transform.localPosition = resetPos;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.name=="pikachu")
        {
            pikachu.SetActive(false);
            Debug.Log("success!");
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
        else if(collisionInfo.gameObject.name=="wall")
        {
            ResetBall();
        }
       
    }
}
