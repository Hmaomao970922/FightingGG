using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundAttack : IState {

    public override void Enter()
    {
        Debug.Log("RoundAttackEnter");
    }

    public override void Stay()
    {
        RoundManger.instances.Gongji();
        Debug.Log("RoundAttacStay");

    }

    public override void Leave()
    {
        RoundManger.instances.ResetAttackTarget();
        Debug.Log("RoundAttacleave");
    }

    
}
