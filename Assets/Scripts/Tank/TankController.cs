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
            tankView.ChangeColor(tankModel.material);
            CameraController.GetInstance().SetTarget(tankView.transform);
        }
        public void ShootBullet()
        {
            BulletService.GetInstance().CreateBullet(tankView.BulletShootPoint.position, tankView.transform.rotation, tankModel.bulletType);
        }
    }
}