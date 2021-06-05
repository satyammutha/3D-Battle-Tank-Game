using UnityEngine;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField] private FixedJoystick joystick;
        public TankScriptableObject tankScriptableObject;
        private TankModel TankModel;

        private void Start()
        {
            StartGame();
        }
        private void StartGame()
        {
            for (int i = 0; i < 1; i++)
            {
                CreateNewTank();
            }
        }
        private TankController CreateNewTank()
        {
            TankModel model = new TankModel(tankScriptableObject);
            TankModel = model;
            TankController tank = new TankController(model, tankScriptableObject.tankView,joystick);
            return tank;
        }
    }
}