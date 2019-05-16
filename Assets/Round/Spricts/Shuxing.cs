using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuxing : MonoBehaviour, IComparable<Shuxing>
{
    public enum MoveState {startmove,move,startback,moveback,overmove };
    public MoveState state;
    public float blood;
    public float startBlood;
    public int Speed;
    public int shanghai;
    public bool isAttrack;
    public bool isDamage;
    public bool isMove;
    public bool isSelect;
    public bool isDead;

    public Vector3 startPos;
    public XueTiao xuetiao;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetBlood()
    {
        Vector3 pos = transform.position;
        pos = Camera.main.WorldToScreenPoint(pos);
        pos.y += 100;
        xuetiao.transform.position = pos;
    }

    /// <summary>
    /// 重写CompareTO用于排序
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>

    public int CompareTo(Shuxing other)
    {
        return other.Speed.CompareTo(this.Speed);//降序
    }

    /// <summary>
    /// 攻击
    /// </summary>
    public virtual void Gongji() {

    }

    /// <summary>
    /// 受伤
    /// </summary>
    public virtual void Shoushang(int d) {

    }

    /// <summary>
    /// 选择攻击
    /// </summary>
    public virtual void SelectGongji() {

    }

    /// <summary>
    /// 判断是否死亡
    /// </summary>
    public virtual void JuadeDead() {
       
    }

    /// <summary>
    /// 判断是否口可以攻击
    /// </summary>
    public virtual void JuadeAttack() {
      
    }

    public virtual void Reset() {

    }
}
