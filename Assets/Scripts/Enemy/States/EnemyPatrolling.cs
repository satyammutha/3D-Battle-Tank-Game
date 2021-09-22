using Enemy.States;
using UnityEngine;

public class EnemyPatrolling : EnemyStates
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyView.activeState = StateTypes.Patrolling;
        Debug.Log("In Enemy Patrolling State..");
    }
    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("Exiting Enemy Patrolling State");
    }
    private void Update()
    {
        enemyView.enemyController.Patrolling();
    }
}