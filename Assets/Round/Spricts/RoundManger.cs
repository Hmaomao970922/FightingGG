using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManger : MonoBehaviour {

    public enum RoundState { start,game,gameover};
    public static RoundManger instances;

    public List<GameObject> allPeople = new List<GameObject>();
    public StateManeger stateManger;
    public GameObject player;
    public int currentId;
    public bool isOver;
    [HideInInspector]
    public List<Shuxing> allPeoPleShuxing = new List<Shuxing>();

    void Awake() {
        instances = this;
    }

	// Use this for initialization
	void Start () {
        stateManger = StateManeger.GetInstance();
        stateManger.CreateRoundStateList();
        stateManger.stateList[0].Enter();

        foreach (GameObject shuxing in allPeople)
        {
            allPeoPleShuxing.Add(shuxing.GetComponent<Shuxing>());
        }
        Sort();

    }

    // Update is called once per frame
    void Update () {

        stateManger.UpdateState();

    }

    public void Reset() {
        Enemy.enemys.Clear();
        Duiyou.duiyous.Clear();
        
        currentId = 0;
        SwitchState(0);
        foreach (Shuxing shuxing in allPeoPleShuxing)
        {
            shuxing.Reset();
        }
        UIManger.instance.SetTextTip(true);
    }

    public void Sort() {

        allPeoPleShuxing.Sort();
    }

    public void Gongji() {
     
       allPeoPleShuxing[currentId].Gongji();
        //   Debug.Log("currentId" + currentId);
        if (currentId == allPeoPleShuxing.Count) {
            currentId = 0;
            SwitchState(0);
        }
    }

    public void ChooseGongji() {
        foreach (Shuxing people in allPeoPleShuxing)
        {
            if (!people.isSelect) {
                people.SelectGongji();
            }
        }
    }

    public void SetPlayer(Enemy enmey) {
        Duiyou duiyou = player.GetComponent<Duiyou>();
        duiyou.enemy = enmey;
        duiyou.isSelect = true;
    }

    public void SwitchState(int i) {
        stateManger.ChangeState(i);
    }

    /// <summary>
    /// 重新选择攻击对象
    /// </summary>
    public void ResetAttackTarget() {
        foreach (Duiyou duiyou in Duiyou.duiyous)
        {
            duiyou.isSelect = false;
            duiyou.enemy = null;
        }

        foreach (Enemy enemey in Enemy.enemys)
        {
            enemey.isSelect = false;
            enemey.duiyou = null;
        }
    }
}
