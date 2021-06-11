using BulletSObj;

namespace Bullet
{
    public class BulletModel
    {
        public float speed { get; private set; }
        public float damage { get; private set; }
        public BulletTypes type;
        private BulletController bulletController;
        public BulletScriptableObject bullet;
        public BulletModel(BulletScriptableObject bullet)
        {
            speed = bullet.speed;
            damage = bullet.damage;
            type = bullet.bulletType;
        }
    }
}