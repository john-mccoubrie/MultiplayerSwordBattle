﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLostState : BattleBaseState
{
    public override void CmdEnterState(BattleController_FSM battle)
    {
        Debug.Log("Lost");
    }

    public override void CmdOnClickStab(BattleController_FSM battle)
    {
        throw new System.NotImplementedException();
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {
        throw new System.NotImplementedException();
    }
    public override void RpcMyUpdate(BattleController_FSM battle)
    {
        
    }

    public override void OnClickHeal(BattleController_FSM battle)
    {
        throw new System.NotImplementedException();
    }
}
