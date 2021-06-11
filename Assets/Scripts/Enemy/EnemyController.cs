using Bullet;
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
            enemyView = GameObject.Instantiate<EnemyView>(_enemyView);
            enemyView.initializeView(this);
            enemyView.ChangeColor(enemyModel.material);
        }

        public void OnCollisionWithBullet(BulletView bullet)
        {
            EnemyService.GetInstance().DestroyEnemy(this);
            BulletService.GetInstance().DestroyBullet(bullet.bulletController);
        }
    }
}