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
        
        public NavMeshAgent agent;
        public Transform player;
        public LayerMask whatIsGround, whatIsPlayer;
        public Vector3 walkPoint;
        public bool walkPointSet;
        public float walkPointRange;
        //public float timeBetweenAttacks;
        public bool alreadyAttacked;
        public float sightRange, attackRange;
        public bool playerInSightRange, playerInAttackRange;

        private void Update()
        {
            enemyController.CheckSightNAttack();
        }        
        public void initializeView(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
        public void ChangeColor(Material material)
        {
            mesh.material = material;
        }
        public void DestroyView()
        {
            enemyController = null;
            Destroy(this.gameObject);
        }

        internal void callInvokeInView()
        {
            Invoke(nameof(callingResetAttack),  enemyController.enemyModel.rateFire); //timeBetweenAttacks
        }
        public void callingResetAttack()
        {
            enemyController.ResetAttack();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                enemyController.ApplyDamage();
            }
        }
    }
}