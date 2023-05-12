using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BattleStartState : BattleBaseState
{
    //both clients are going to run this -- only server should run this maybe
    bool setupComplete = false;

    public override void CmdEnterState(BattleController_FSM battle)
    {
        Debug.Log("Start State");

        battle.StartCoroutine(SetupBattle());
    }

    void TargetChangeState(string state)
    {
        Debug.Log(state);
    }
    IEnumerator SetupBattle()
    {
        //set up the battle space


        yield return new WaitForSeconds(5f);
        setupComplete = true;
    }
    public override void CmdOnClickStab(BattleController_FSM battle)
    {
        
    }
    [ClientRpc]
    public override void RpcMyUpdate(BattleController_FSM battle)
    {
        if(setupComplete)
        {
            battle.TransitionToState(battle.playerState);
            setupComplete = false;
        }
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {

    }

    public override void OnClickHeal(BattleController_FSM battle)
    {
        
    }
}
