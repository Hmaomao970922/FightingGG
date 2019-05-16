using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : Shuxing {

    public static List<Enemy> enemys = new List<Enemy>();
    public Duiyou duiyou;
    private Animator ani;
    // Use this for initialization
    void Start () {
        startPos = transform.position;
        startBlood = blood;
        enemys.Add(this);
        xuetiao.SetStartBlood(startBlood);
        SetBlood();
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isMove)
        {
            SetBlood();
        }
    }

    public override void Reset()
    {
        transform.position = startPos;
        enemys.Add(this);
        blood = startBlood;
        xuetiao.SetStartBlood(startBlood);
        SetBlood();
        xuetiao.ResetBlood();

        isDead = false;
        isMove = false;
        isSelect = false;
    }

    public override void Gongji()
    {

        JuadeAttack();
        Vector3 enemyPos = Vector3.zero;
        if (duiyou != null)
        {
            enemyPos = duiyou.transform.position;
        }
        if (state == MoveState.startmove)
        {
            StartCoroutine(Attack());
            transform.DOMove(enemyPos, 1);
            state = MoveState.move;
        }

        if (state == MoveState.move)
        {
            isMove = true;
            if (Vector3.Distance(transform.position, enemyPos) < 0.2f)
            {
                state = MoveState.startback;
                UIManger.instance.SetDamageTextPos(enemyPos,shanghai);

            }
        }

        if (state == MoveState.startback)
        {
            transform.DOMove(startPos, 1);
            state = MoveState.moveback;
            duiyou.Shoushang(shanghai);
        }

        if (state == MoveState.moveback)
        {
            if (Vector3.Distance(transform.position, startPos) < 0.2f)
            {
                state = MoveState.overmove;
                UIManger.instance.SetDamageText(false);

            }
        }

        if (state == MoveState.overmove)
        {
            state = MoveState.startmove;
            RoundManger.instances.currentId++;
            isMove = false;
            duiyou.JuadeDead();
            if (Duiyou.duiyous.Count == 0)
            {
                RoundManger.instances.Reset();
            }
        }
    }

    public override void Shoushang(int damage)
    {
        blood -= damage;
        xuetiao.SetBlood(damage);
    }

    public override void SelectGongji()
    {
        if (!isDead) {
            if (Duiyou.duiyous.Count == 0)
            {

            }
            else
            {
                do
                {
                    int index = Random.Range(0, Duiyou.duiyous.Count);
                    duiyou = Duiyou.duiyous[index];
                } while (duiyou.isDead == true);
            }
        }
        isSelect = true;
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && !isDead) {
            RoundManger.instances.SetPlayer(this);
            RoundManger.instances.SwitchState(1);
        }
        
    }

    public override void JuadeDead()
    {
        if (blood <= 0)
        {
            isDead = true;
            
            enemys.Remove(this);
        }
       
    }

    public override void JuadeAttack()
    {
        if (isDead)
        {
            ani.SetTrigger("Death");
            state = MoveState.overmove;
        }
        else if (blood <= 0) {
            ani.SetTrigger("Death");
            state = MoveState.overmove;

        }
        else if (!isDead && duiyou != null && duiyou.isDead)
        {
            duiyou = null;
            if (Duiyou.duiyous.Count == 0)
            {
                Debug.Log("失败");
                state = MoveState.overmove;
            }
            else
            {
                SelectGongji();
            }
        }
        
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(.3f);
        ani.SetTrigger("Attack");

    }

}
