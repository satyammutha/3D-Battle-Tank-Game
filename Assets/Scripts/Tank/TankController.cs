using UnityEngine;
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
            CameraController.GetInstance();
            CameraController.Instance.SetTarget(tankView.transform);
            tankView.ChangeColor(tankModel.material);
        }
    }
}