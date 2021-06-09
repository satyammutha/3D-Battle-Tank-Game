using UnityEngine;
namespace Enemy
{
    public class EnemyModel : MonoBehaviour
    {
        public EnemyTypes enemyTypes { get; private set; }
        public string enemyName { get; private set; }
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float health { get; private set; }
        public float damage { get; private set; }
        public Material material { get; private set; }

        public EnemyScriptableObject enemyScriptableObject;
        public EnemyModel(EnemyScriptableObject enemyScriptableObject, EnemyScriptableObjectList enemyList)
        {
            enemyTypes = enemyScriptableObject.enemyTypes;
            enemyName = enemyScriptableObject.enemyName;
            movementSpeed = enemyScriptableObject.movementSpeed;
            rotationSpeed = enemyScriptableObject.rotationSpeed;
            health = enemyScriptableObject.health;
            damage = enemyScriptableObject.damage;
            material = enemyScriptableObject.material;
        }
    }
}