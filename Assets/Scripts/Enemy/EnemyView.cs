using UnityEngine;
namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;
        [SerializeField] private Rigidbody enemyRigidbody;
        public MeshRenderer mesh;
        
        public void initializeView(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
        public void ChangeColor(Material material)
        {
            mesh.material = material;
        }
    }
}