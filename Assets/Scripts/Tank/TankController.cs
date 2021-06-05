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
            Debug.Log("Tank View Created", tankView);
        }
    }
}