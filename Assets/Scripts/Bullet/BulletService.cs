using UnityEngine;
using BulletSObj;
using System.Collections.Generic;

namespace Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        private List<BulletController> bullets = new List<BulletController>();
        public void CreateBullet(Vector3 position, Quaternion rotation, BulletScriptableObject type)
        {
            BulletScriptableObject bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, position, rotation);
            bullets.Add(bulletController);
        }
        public void DestroyBullet(BulletController bullet)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] == bullet)
                {
                    bullets[i] = null;
                    bullets.Remove(bullets[i]);
                }
            }
        }
    }
}