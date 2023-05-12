using UnityEngine;

public abstract class BattleBaseState
{
    public abstract void CmdEnterState(BattleController_FSM battle);
    public abstract void RpcMyUpdate(BattleController_FSM battle);
    public abstract void CmdOnClickStab(BattleController_FSM battle);
    public abstract void OnClickSlice(BattleController_FSM battle);
    public abstract void OnClickHeal(BattleController_FSM battle);
}
