using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BattleEnemyState : BattleBaseState
{
    public override void CmdEnterState(BattleController_FSM battle)
    {
        Debug.Log("Enemy");
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        battle.playerManager = networkIdentity.GetComponent<PlayerManager>();
    }
    
    public override void CmdOnClickStab(BattleController_FSM battle)
    {
        if(battle.enemyStabCount > 0)
        {
            
            battle.enemyAttack = "Stab";
            battle.playerManager.CmdSliceEnemy(battle.enemyAttack, battle.enemyStabCount);
            if (battle.playerIsDone)
            {
                battle.playerIsDone = false;
                battle.enemyStabCount--;
                battle.TransitionToState(battle.assessmentState);
            }
        }
        
               
    }

    public override void RpcMyUpdate(BattleController_FSM battle)
    {
        
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {
        if(battle.enemySliceCount > 0)
        {
            battle.enemyAttack = "Slice";
            battle.playerManager.CmdSliceEnemy(battle.enemyAttack, battle.enemySliceCount);
            if (battle.playerIsDone)
            {
                battle.playerIsDone = false;
                battle.enemySliceCount--;
                battle.TransitionToState(battle.assessmentState);
            }
        
        }

    }
    public override void OnClickHeal(BattleController_FSM battle)
    {
        if(battle.enemyHealCount > 0)
        {
            battle.enemyAttack = "Heal";
            battle.playerManager.CmdSliceEnemy(battle.enemyAttack, battle.enemyHealCount);
            if (battle.playerIsDone)
            {
                battle.playerIsDone = false;
                battle.enemyHealCount--;
                battle.TransitionToState(battle.assessmentState);
            }
        
        }

    }
}
