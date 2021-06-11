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
    [CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/Bullet/NewBulletScriptableObjectList")]
    public class BulletSOList : ScriptableObject
    {
        public BulletScriptableObject[] bulletsTypes;

    }
}