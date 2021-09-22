using System.Collections;
using System.Collections.Generic;
using Tank;
using UnityEngine;

namespace Enemy.States
{
    public class EnemyStates : MonoBehaviour
    {
        protected EnemyView enemyView;
        private void Awake()
        {
            enemyView = GetComponent<EnemyView>();
        }
        public virtual void OnEnterState() {
            this.enabled = true;
        }
        public virtual void OnExitState() {
            this.enabled = false;
        }

        public void ChangeState(EnemyStates newState)
        {
            if (enemyView.currentState != null)
            {
                enemyView.currentState.OnExitState();
            }
            enemyView.currentState = newState;
            enemyView.currentState.OnEnterState();
        }
    }
}