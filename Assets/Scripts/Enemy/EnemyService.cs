using EnemySObj;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        [SerializeField] private EnemyScriptableObjectList enemyScriptableObjectList;
        public EnemyScriptableObject enemyScriptableObject;
        private EnemyModel EnemyModel;
        private List<EnemyController> enemies = new List<EnemyController>();
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
        public void DestroyEnemy(EnemyController enemyController)
        {
            enemyController.DestroyController();
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemyController == enemies[i])
                {
                    enemies[i] = null;
                    enemies.Remove(enemies[i]);
                }
            }
        }
        private void BeginEnemyCreation()
        {
            for (int i = 0; i < 3; i++)
            {
                CreateNewEnemy();
            }
        }
        private void CreateNewEnemy()
        {
            int random = Random.Range(0, enemyScriptableObjectList.enemyList.Length);
            enemyScriptableObject = enemyScriptableObjectList.enemyList[random];
            EnemyModel model = new EnemyModel(enemyScriptableObject);
            EnemyModel = model;
            EnemyController enemy = new EnemyController(model, enemyScriptableObject.enemyView);
            enemies.Add(enemy);
        }
    }
}