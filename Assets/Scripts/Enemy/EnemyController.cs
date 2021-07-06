using Bullet;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyController
    {
        public EnemyModel enemyModel { get; private set; }
        public EnemyView enemyView { get; private set; }
        private float timer;
        private float fireReady = 0f;
        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView)
        {
            enemyModel = _enemyModel;
            enemyView = GameObject.Instantiate<EnemyView>(_enemyView, GetRandomPos(),Quaternion.identity);
            enemyView.ChangeColor(enemyModel.material);
            enemyModel.SetEnemyController(this);
            enemyView.initializeView(this);
        }
        private Vector3 GetRandomPos()
        {
            Vector3 randDir = Random.insideUnitSphere * enemyModel.patrollingRadius;
            randDir += EnemyService.GetInstance().enemyScriptableObject.enemyView.transform.position;
            NavMesh.SamplePosition(randDir, out NavMeshHit navHit, enemyModel.patrollingRadius, NavMesh.AllAreas);
            return navHit.position;
        }
        public void Attack()
        {
            if (fireReady < Time.time)
            {
                fireReady = enemyModel.rateFire + Time.time;
                BulletService.GetInstance().CreateBullet(enemyView.shootingPoint.position, GetFiringAngle(), enemyModel.bullet);
            }
        }

        private Quaternion GetFiringAngle()
        {
            return enemyView.transform.rotation;
        }

        public void Patrol()
        {
            timer += Time.deltaTime;
            if (timer > enemyModel.patrolTime)
            {
                SetPatrolingDestination();
                timer = 0;
            }
        }

        private void SetPatrolingDestination()
        {
            Vector3 newDestination = GetRandomPos();
            enemyView.navMeshAgent.SetDestination(newDestination);
        }
        public void OnCollisionWithBullet(BulletView bullet)
        {
            EnemyService.GetInstance().DestroyEnemy(this);
            BulletService.GetInstance().DestroyBullet(bullet.bulletController);
        }
        public void ApplyDamage(float damage)
        {
            if (enemyModel.health <= 0) return;

            if (enemyModel.health - damage <= 0)
            {
                Dead();
            }
            else
                enemyModel.health -= damage;
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