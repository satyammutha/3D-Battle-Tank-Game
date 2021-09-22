using Enemy.States;

public class EnemyChasing : EnemyStates
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyView.activeState = StateTypes.Chasing;
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }
    private void Update()
    {
        enemyView.enemyController.ChasePlayer();
    }
}