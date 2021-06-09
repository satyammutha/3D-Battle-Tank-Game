using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class EnemyServices : MonoSingletonGeneric<EnemyServices>
    {
        [SerializeField] private EnemyScriptableObjectList enemyScriptableObjectList;
        private EnemyScriptableObject enemyScriptableObject;
        private EnemyModel EnemyModel;
        private void Start()
        {
            BeginEnemyCreation();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                CreateNewEnemy();
            }
        }

        private void BeginEnemyCreation()
        {
            for (int i = 0; i < 3; i++)
            {
                CreateNewEnemy();
            }
        }

        private EnemyController CreateNewEnemy()
        {
            int random = Random.Range(0, enemyScriptableObjectList.enemyList.Length);
            enemyScriptableObject = enemyScriptableObjectList.enemyList[random];
            EnemyModel model = new EnemyModel(enemyScriptableObject, enemyScriptableObjectList);
            EnemyModel = model;
            EnemyController enemy = new EnemyController(model, enemyScriptableObject.enemyView);
            return enemy;
        }
    }
}