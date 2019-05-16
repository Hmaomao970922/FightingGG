using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  IState  {
    /// <summary>
    /// 每次状态进入，必须重写
    /// </summary>
    public abstract void Enter();
    /// <summary>
    /// 停留在状态中
    /// </summary>
    public virtual void Stay() {

    }
    /// <summary>
    /// 离开此状态
    /// </summary>
    public virtual void Leave() {

    }
}
