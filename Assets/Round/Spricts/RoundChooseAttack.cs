using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundChooseAttack : IState {

    public override void Enter()
    {
        UIManger.instance.SetTextTip(true);
        Debug.Log("RoundStartEnter");
    }

    public override void Stay()
    {
        RoundManger.instances.ChooseGongji();

    }

    public override void Leave()
    {
        UIManger.instance.SetTextTip(false);
        Debug.Log("RoundStartLeave");
    }
}
