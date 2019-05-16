using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XueTiao : MonoBehaviour {

    public float blood;
    private float startBlood;
    public Image bloodImage;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {


      //  Debug.Log("transform.position" + p);
    }

    public void SetStartBlood(float b) {
        blood = b;
        startBlood = blood;
    }

    public void SetBlood(int damage) {
        float count =  damage / startBlood;
        bloodImage.fillAmount -= count;
    }

    public void ResetBlood() {
        bloodImage.fillAmount = 1;
    }
}
