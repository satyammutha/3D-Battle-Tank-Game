using EnemySObj;
using BulletSObj;
using UnityEngine;
namespace Enemy
{
    public class EnemyModel
    {
        private EnemyController enemyController;
        public EnemyTypes enemyTypes { get; private set; }
        public string enemyName { get; private set; }
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float health { get; set; }
        public float damage { get; private set; }
        public Material material { get; private set; }
        public BulletScriptableObject bullet { get; private set; }
        public float patrollingRadius { get; private set; }
        public float patrolTime { get; private set; }
        public float rateFire { get; private set; }
        public EnemyScriptableObject EnemyScriptableObject { get; }
        public EnemyScriptableObjectList EnemyScriptableObjectList { get; }

        public EnemyScriptableObject enemyScriptableObject;
        public EnemyModel(EnemyScriptableObject enemyScriptableObject)
        {
            enemyTypes = enemyScriptableObject.enemyTypes;
            enemyName = enemyScriptableObject.enemyName;
            movementSpeed = enemyScriptableObject.movementSpeed;
            rotationSpeed = enemyScriptableObject.rotationSpeed;
            health = enemyScriptableObject.health;
            damage = enemyScriptableObject.damage;
            material = enemyScriptableObject.material;
            bullet = enemyScriptableObject.bulletType;
            patrollingRadius = enemyScriptableObject.patrollingRadius;
            patrolTime = enemyScriptableObject.patrolTime;
            rateFire = enemyScriptableObject.rateFire;
        }
        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
        public void DestroyModel()
        {
            bullet = null;
            enemyController = null;
            material = null;
        }
    }
}