using UnityEngine;
namespace Tank
{
    public class TankController
    {   
        public TankModel TankModel { get; }
        public TankView TankView { get; }
        public TankController(TankModel tankModel, TankView tankView)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankView);
            Debug.Log("Tank View Created", TankView);
        }
        
    }
}