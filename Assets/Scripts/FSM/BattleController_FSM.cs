using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class BattleController_FSM : NetworkBehaviour
{
    #region Variables
    public PlayerManager playerManager;
    [SyncVar]
    public string playerAttack;
    [SyncVar]
    public string enemyAttack;
    [SyncVar]
    public int playerHealth;
    [SyncVar]
    public int enemyHealth;
    [SyncVar]
    public int playerDamage;
    [SyncVar]
    public int enemyDamage;
    [SyncVar]
    public int playerHeal;
    [SyncVar]
    public int enemyHeal;
    [SyncVar]
    public bool playerIsDone = false;
    [SyncVar]
    public int playerSliceCount = 15;
    [SyncVar]
    public int playerStabCount = 5;
    [SyncVar]
    public int playerHealCount = 3;
    [SyncVar]
    public int enemySliceCount = 15;
    [SyncVar]
    public int enemyStabCount = 5;
    [SyncVar]
    public int enemyHealCount = 3;


    public List<AttackBase> thePlayerAttacks = new List<AttackBase>();
    #endregion

    private BattleBaseState currentState;
    public BattleBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly BattleStartState startState = new BattleStartState();
    public readonly BattlePlayerState playerState = new BattlePlayerState();
    public readonly BattleEnemyState enemyState = new BattleEnemyState();
    public readonly BattleAssessmentState assessmentState = new BattleAssessmentState();
    public readonly BattleWonState wonState = new BattleWonState();
    public readonly BattleLostState lostState = new  BattleLostState();

    void Start()
    {
        TransitionToState(startState);
    }
    void Update()
    {
        currentState.RpcMyUpdate(this);
    }
    public void TransitionToState(BattleBaseState state)
    {
        currentState = state;
        currentState.CmdEnterState(this);
    }
    public void OnClickStab()
    {
        currentState.CmdOnClickStab(this);
    }
    public void OnClickSlice()
    {
        currentState.OnClickSlice(this);
    }
    public void OnClickHeal()
    {
        currentState.OnClickHeal(this);
    }
}
