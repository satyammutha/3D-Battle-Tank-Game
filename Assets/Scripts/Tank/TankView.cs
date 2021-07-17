using System;
using UnityEngine;
namespace Tank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private FixedJoystick joystick;
        public Rigidbody TankRigidbody;
        public float InputMovement;
        public float InputTurn;
        public Vector3 Movement;
        public MeshRenderer[] childs;
        public Transform BulletShootPoint;
        private float canFire = 0f;
        private void Update()
        {
            InputMovement = joystick.Vertical;
            InputTurn = joystick.Horizontal;
        }
        private void FixedUpdate()
        {
            tankController.Move();
            tankController.Turn();
            ShootBullet();
        }
        private void ShootBullet()
        {
            if (Input.GetKeyUp(KeyCode.F) && canFire < Time.time)
            {
                canFire = tankController.tankModel.fireRate + Time.time;
                tankController.ShootBullet();
            }
        }
        public void InitializeView(TankController _tankController, FixedJoystick _fixedJoystick) {
            tankController = _tankController;
            joystick = _fixedJoystick;
        }
    }
}