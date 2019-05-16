using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态机管理类
/// </summary>
public class StateManeger {
    private static StateManeger instance;
    public List<IState> stateList = new List<IState>();
    private int currentID;

    /// <summary>
    /// 定义一个私有构造函数，是外界不能创建该类实例
    /// </summary>
    private StateManeger() {

    }

    public static StateManeger GetInstance() {
        if (instance == null) {
            instance = new StateManeger();
        }
        return instance;
    }

    /// <summary>
    /// 添加状态到状态列表里面
    /// </summary>
    /// <param name="state"></param>
    public void AddState(IState state) {
        stateList.Add(state);
    }

    public void CreateRoundStateList() {
        AddState(new RoundChooseAttack());
        AddState(new RoundAttack());
    }

    /// <summary>
    /// 转换状态
    /// </summary>
    /// <param name="i"></param>
    public void ChangeState(int i) {
        stateList[currentID].Leave();
        currentID = i;
        stateList[currentID].Enter();
    }
    /// <summary>
    /// 保持持续状态
    /// </summary>
    public void UpdateState() {
        stateList[currentID].Stay();
    }
}
