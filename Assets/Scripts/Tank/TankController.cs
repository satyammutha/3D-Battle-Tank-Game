using UnityEngine;
using Bullet;
using BulletSObj;
namespace Tank
{
    public class TankController
    {
        public TankModel tankModel { get; private set; }
        public TankView tankView { get; private set; }

        public TankController(TankModel _tankModel, TankView _tankView, FixedJoystick joystick)
        {
            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            tankView.initializeView(this,joystick);
            CameraController.GetInstance().SetTarget(tankView.transform);
            tankView.ChangeColor(tankModel.material);
        }
        public void ShootBullet()
        {
            BulletService.GetInstance().CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }
        public Vector3 GetFiringPosition()
        {
            return tankView.BulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return tankView.transform.rotation;
        }
        public BulletScriptableObject GetBullet()
        {
            return tankModel.bulletType;
        }
    }
}