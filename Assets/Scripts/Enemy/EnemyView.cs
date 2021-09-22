using UnityEngine;
using UnityEngine.AI;
using IDamagableNS;
using Enemy.States;
using System;

namespace Enemy
{
    public class EnemyView : MonoBehaviour, IDamagable
    {
        [HideInInspector]public EnemyController enemyController;
        [SerializeField] private Rigidbody enemyRigidbody;
        public MeshRenderer mesh;
        public Transform shootingPoint;
        
        public NavMeshAgent agent;
        public Transform player;
        public LayerMask whatIsGround, whatIsPlayer;
        public Vector3 walkPoint;
        public bool walkPointSet;
        public float walkPointRange;
        public bool alreadyAttacked;
        public float sightRange, attackRange;
        public bool playerInSightRange, playerInAttackRange;

        [HideInInspector] public EnemyPatrolling patrollingState;
        [HideInInspector] public EnemyChasing chasingState;
        [HideInInspector] public EnemyAttacking attackingState;
        private StateTypes initState;
        [HideInInspector] public StateTypes activeState;
        [HideInInspector] public EnemyStates currentState;

        private void Start()
        {
            InitStates();
        }

        private void InitStates()
        {
            switch (initState)
            {
                case StateTypes.Patrolling:
                    currentState = patrollingState;
                    break;
                case StateTypes.Chasing:
                    currentState = chasingState;
                    break;
                case StateTypes.Attacking:
                    currentState = attackingState;
                    break;
                default:
                    currentState = null;
                    break;
            }
            currentState.OnEnterState();
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

        public void TakeDamage(float damage)
        {
            Debug.Log("IN EnemyView Takedamage Func Damage:" + damage);
            enemyController.ApplyDamage(damage);
        }
    }
}