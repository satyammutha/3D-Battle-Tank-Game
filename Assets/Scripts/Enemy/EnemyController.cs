using Bullet;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyController
    {
        public EnemyModel enemyModel { get; private set; }
        public EnemyView enemyView { get; private set; }
        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView)
        {
            enemyModel = _enemyModel;
            enemyView = GameObject.Instantiate<EnemyView>(_enemyView, enemyModel.locationToDeploy,Quaternion.identity);
            enemyView.ChangeColor(enemyModel.material);
            enemyModel.SetEnemyController(this);
            enemyView.initializeView(this);
        }
        public void CheckSightNAttack()
        {
            enemyView.playerInSightRange = Physics.CheckSphere(enemyView.transform.position, enemyView.sightRange, enemyView.whatIsPlayer);
            enemyView.playerInAttackRange = Physics.CheckSphere(enemyView.transform.position, enemyView.attackRange, enemyView.whatIsPlayer);

            if (!enemyView.playerInSightRange && !enemyView.playerInAttackRange) Patroling();
            if (enemyView.playerInSightRange && !enemyView.playerInAttackRange) ChasePlayer();
            if (enemyView.playerInSightRange && enemyView.playerInAttackRange) AttackPlayer();
        }
        private void Patroling()
        {
            if (!enemyView.walkPointSet) SearchWalkPoint();
            if (enemyView.walkPointSet)
            {
                enemyView.agent.SetDestination(enemyView.walkPoint);
            }
            Vector3 distanceToWalkPoint = enemyView.transform.position - enemyView.walkPoint;

            //WalkPoint reached
            if (distanceToWalkPoint.magnitude < 1f)
            {
                enemyView.walkPointSet = false;
            }
        }

        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(-enemyView.walkPointRange, enemyView.walkPointRange);
            float randomX = Random.Range(-enemyView.walkPointRange, enemyView.walkPointRange);
            enemyView.walkPoint = new Vector3(enemyView.transform.position.x + randomX, enemyView.transform.position.y, enemyView.transform.position.z + randomZ);

            if (Physics.Raycast(enemyView.walkPoint, -enemyView.transform.up, 2f, enemyView.whatIsGround))
            {
                enemyView.walkPointSet = true;
            }
        }
        private void ChasePlayer()
        {
            enemyView.agent.SetDestination(enemyView.player.position);
        }
        private void AttackPlayer()
        {
            //make sure enemy doesnt move
            enemyView.agent.SetDestination(enemyView.player.position);
            enemyView.transform.LookAt(enemyView.player);
            if (!enemyView.alreadyAttacked)
            {
                //Attack Code
                ShootBullet();
                enemyView.alreadyAttacked = true;
                enemyView.callInvokeInView();
            }
        }
        public void ResetAttack()
        {
            enemyView.alreadyAttacked = false;
        }
        public void ShootBullet()
        {
            BulletService.GetInstance().CreateBullet(enemyView.shootingPoint.position, enemyView.transform.rotation, enemyModel.bulletType);
        }
        public void ApplyDamage()
        {
            if (enemyModel.health <= 0) return;

            if (enemyModel.health - enemyModel.damage <= 0)
            {
                Dead();
            }
            else
                enemyModel.health -= enemyModel.damage;
        }
        private void Dead()
        {
            EnemyService.GetInstance().DestroyEnemy(this);
        }
        public void DestroyController()
        {
            enemyModel.DestroyModel();
            enemyView.DestroyView();
        }
    }
}