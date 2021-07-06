using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;
        [SerializeField] private Rigidbody enemyRigidbody;
        public MeshRenderer mesh;
        public Transform shootingPoint;
        public NavMeshAgent navMeshAgent { get; private set; }

        public void initializeView(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
        public void ChangeColor(Material material)
        {
            mesh.material = material;
        }
        public void TakeDamage(float damage)
        {
            enemyController.ApplyDamage(damage);
        }
        public void DestroyView()
        {
            enemyController = null;
            Destroy(this.gameObject);
        }
    }
}