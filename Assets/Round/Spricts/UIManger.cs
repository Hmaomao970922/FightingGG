using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManger : MonoBehaviour {
    public static UIManger instance;
    public Text damageTip;
    //攻击提示语
    public Text gongjiTip;


    void Awake() {
        instance = this;
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTextTip(bool b) {
        gongjiTip.gameObject.SetActive(b);
    }

    public void SetDamageTextPos(Vector3 pos,int shanghai) {
        damageTip.gameObject.SetActive(true);
        pos = Camera.main.WorldToScreenPoint(pos);
        damageTip.transform.position = pos;
        damageTip.text = "-" + shanghai.ToString();
         float newPosy = pos.y;
        newPosy += 200;
        damageTip.transform.DOMoveY(newPosy, 1);
    }

    public void SetDamageText(bool b) {
        damageTip.gameObject.SetActive(b);
    }
}
