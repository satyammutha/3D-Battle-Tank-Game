using UnityEngine;
using Enemy;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy/NewEnemyScriptableObjects")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyTypes enemyTypes;
    public string enemyName;
    public float movementSpeed;
    public float rotationSpeed;
    public float health;
    public float damage;
    public Material material;
    public EnemyView enemyView;
}
[CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObjects/Enemy/NewEnemyScriptableObjectsList")]
public class EnemyScriptableObjectList : ScriptableObject
{
    public EnemyScriptableObject[] enemyList;
}