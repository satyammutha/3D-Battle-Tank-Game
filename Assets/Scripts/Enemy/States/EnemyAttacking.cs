using Enemy.States;

public class EnemyAttacking : EnemyStates
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyView.activeState = StateTypes.Attacking;
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void Update()
    {
        enemyView.enemyController.AttackPlayer();
    }
}