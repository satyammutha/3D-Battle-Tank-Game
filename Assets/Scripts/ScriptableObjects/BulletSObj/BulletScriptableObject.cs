using UnityEngine;
using Bullet;

namespace BulletSObj
{
    [CreateAssetMenu(fileName = "BulletScriptableObjects", menuName = "ScriptableObjects/Bullet/NewBulletScriptableObject")]
    public class BulletScriptableObject : ScriptableObject
    {
        public BulletView bulletView;
        public float speed;
        public float damage;
        public BulletTypes bulletType;
    }
}