using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BattleAssessmentState : BattleBaseState
{
    public override void CmdEnterState(BattleController_FSM battle)
    {
        Debug.Log("Assessment State");

        //reset values
        battle.playerDamage = 0;
        battle.enemyDamage = 0;
        battle.playerHeal = 0;
        battle.enemyHeal = 0;

        #region Attacks
        if (battle.playerAttack == "Slice")
        {
            switch (battle.enemyAttack)
            {
                case "Slice":
                    battle.playerDamage = 5;
                    battle.enemyDamage = 5;
                    break;
                case "Stab":
                    battle.playerDamage = 5;
                    battle.enemyDamage = 3;
                    break;
                case "Heal":
                    battle.playerDamage = 0;
                    battle.enemyDamage = 0;
                    battle.enemyHeal = 5;
                    break;
            }
            battle.playerSliceCount--;
        }

        if (battle.playerAttack == "Stab")
        {
            
            switch (battle.enemyAttack)
            {
                case "Slice":
                    battle.playerDamage = 3;
                    battle.enemyDamage = 5;
                    break;
                case "Stab":
                    battle.playerDamage = 3;
                    battle.enemyDamage = 3;
                    break;
                case "Heal":
                    battle.playerDamage = 10;
                    battle.enemyDamage = 0;
                    break;
            }
            battle.playerStabCount--;
        }

        if (battle.playerAttack == "Heal")
        {
            
            switch (battle.enemyAttack)
            {
                case "Slice":
                    battle.playerHeal = 5;
                    break;
                case "Stab":
                    battle.playerDamage = 0;
                    battle.enemyDamage = 10;
                    break;
                case "Heal":
                    battle.playerHeal = 5;
                    battle.enemyHeal = 5;
                    break;
            }
            battle.playerHealCount--;
        }
        #endregion

        #region Deal Damages and Health
        //player attack
        battle.enemyHealth -= battle.playerDamage;
        //enemy attack
        battle.playerHealth -= battle.enemyDamage;
        //player heal
        battle.playerHealth += battle.playerHeal;
        //enemy heal
        battle.enemyHealth += battle.enemyHeal;
        #endregion

        #region CheckDeath
        if (battle.enemyHealth <= 0)
        {
            battle.TransitionToState(battle.wonState);
        }
        if(battle.playerHealth <= 0)
        {
            battle.TransitionToState(battle.lostState);
        }
        #endregion

        //Update UI
        battle.playerManager.CmdUpdateUI(battle.playerHealth, battle.enemyHealth, battle.playerDamage, battle.enemyDamage,
            battle.playerSliceCount, battle.playerStabCount, battle.playerHealCount, battle.enemySliceCount, 
            battle.enemyStabCount, battle.enemyHealCount);

        battle.TransitionToState(battle.enemyState);
    }

    public override void CmdOnClickStab(BattleController_FSM battle)
    {

    }

    public override void OnClickHeal(BattleController_FSM battle)
    {
       
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {
        
    }

    public override void RpcMyUpdate(BattleController_FSM battle)
    {
        
    }
}
