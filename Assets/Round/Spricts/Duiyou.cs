using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Duiyou : Shuxing {

    public static List<Duiyou> duiyous = new List<Duiyou>();
    public int jineng;
    public Enemy enemy;
    public bool isBack;
    private Animator ani;
    // Use this for initialization
    void Start () {
        startPos = transform.position;
        duiyous.Add(this);
        startBlood = blood;
        xuetiao.SetStartBlood(blood);
        SetBlood();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (isMove) {
            SetBlood();
        }

    }

    public override void Reset()
    {
        startPos = transform.position;
        duiyous.Add(this);
        blood = startBlood;
        xuetiao.SetStartBlood(startBlood);
        xuetiao.ResetBlood();
        SetBlood();
        isDead = false;
        isMove = false;
        isSelect = false;
    }


    /// <summary>
    /// 攻击
    /// </summary>
    public override void Gongji()
    {
        JuadeAttack();
        Vector3 enemyPos = Vector3.zero;
        if (enemy != null) {
            enemyPos = enemy.transform.position;
            
        }

        if (state == MoveState.startmove) {
            StartCoroutine(Attack());
            transform.DOMove(enemyPos, 1);
            state = MoveState.move;
        }

        if (state == MoveState.move) {
            isMove = true;
            if (Vector3.Distance(transform.position, enemyPos) < 0.2f) {
                state = MoveState.startback;
                UIManger.instance.SetDamageTextPos(enemyPos,shanghai);
            }
        }

        if (state == MoveState.startback) {
            

            transform.DOMove(startPos, 1);
            enemy.Shoushang(shanghai);
            state = MoveState.moveback;
        }

        if (state == MoveState.moveback) {
            if (Vector3.Distance(transform.position, startPos) < 0.2f)
            {
                state = MoveState.overmove;
                UIManger.instance.SetDamageText(false);
            }
        }

        if (state == MoveState.overmove) {
            state = MoveState.startmove;
            RoundManger.instances.currentId++;
            isMove = false;
            enemy.JuadeDead();
         
            if (Enemy.enemys.Count == 0) {
                RoundManger.instances.Reset();
            }
        }
    }

    public override void SelectGongji()
    {
        if (!isDead) {
            if (gameObject.tag == "duiyou")
            {
                if (Enemy.enemys.Count == 0)
                {
                }
                else
                {
                    do
                    {
                        int index = Random.Range(0, Enemy.enemys.Count);
                        enemy = Enemy.enemys[index];
                    } while (enemy.isDead == true);
                }


                isSelect = true;
            }
        }
        
        
    }

    public override void Shoushang(int damage)
    {
        blood -= damage;

        xuetiao.SetBlood(damage);
    }

    public override void JuadeDead()
    {
        if (blood <= 0)
        {
            isDead = true;
            duiyous.Remove(this);
        }
     
    }

    public override void JuadeAttack()
    {
        if (isDead) {
            state = MoveState.overmove;
        }
        else if (blood <= 0)
        {
            state = MoveState.overmove;

        }
        else if (enemy != null && enemy.isDead)
        {
            enemy = null;
            if (Enemy.enemys.Count == 0)
            {
                state = MoveState.overmove;
            }
            else
            {
                SelectGongji();
            }
        }
        else {
        }
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(.3f);
        ani.SetTrigger("Attack");

    }
}
