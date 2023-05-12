using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class BattlePlayerState : BattleBaseState
{
    public override void CmdEnterState(BattleController_FSM battle)
    {
        Debug.Log("Player");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        battle.playerManager = networkIdentity.GetComponent<PlayerManager>();
    }
    public override void CmdOnClickStab(BattleController_FSM battle)
    {
        if(battle.playerStabCount > 0)
        {
            battle.playerAttack = "Stab";
            battle.playerManager.CmdSlice(battle.playerAttack);
        }
    }
    public override void OnClickSlice(BattleController_FSM battle)
    {
        if(battle.playerSliceCount > 0)
        {
            battle.playerAttack = "Slice";
            battle.playerManager.CmdSlice(battle.playerAttack);
        }
    }
    public override void RpcMyUpdate(BattleController_FSM battle)
    {
        
    }

    public override void OnClickHeal(BattleController_FSM battle)
    {
        if(battle.playerHealCount > 0)
        {
            battle.playerAttack = "Heal";
            battle.playerManager.CmdSlice(battle.playerAttack);        
        }        
    }
}
