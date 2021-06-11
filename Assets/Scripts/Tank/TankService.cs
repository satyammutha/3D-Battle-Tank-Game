using UnityEngine;
using Cinemachine;
namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private TankScriptableObjectList tankScriptableObjectList;
        private TankScriptableObject tankScriptableObject;
        private TankModel TankModel;
        public int tankSpawnDelay = 3;
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
            int random = Random.Range(0, tankScriptableObjectList.tankList.Length);
            tankScriptableObject = tankScriptableObjectList.tankList[random];
            TankModel model = new TankModel(tankScriptableObject, tankScriptableObjectList);
            TankModel = model;
            TankController tank = new TankController(model, tankScriptableObject.tankView, joystick);
            return tank;
        }
    }
}