using BulletSObj;

namespace Bullet
{
    public class BulletModel
    {
        public float speed { get; private set; }
        public float damage { get; private set; }
        public BulletTypes type;
        public BulletScriptableObject bullet;
        public BulletModel(BulletScriptableObject bullet)
        {
            speed = bullet.speed;
            type = bullet.bulletType;
        }
    }
}