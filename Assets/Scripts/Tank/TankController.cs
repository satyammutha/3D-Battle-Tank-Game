using UnityEngine;
using Bullet;
using BulletSObj;
using System;

namespace Tank
{
    public class TankController
    {
        public TankModel tankModel { get; set; }
        public TankView tankView { get; private set; }

        public TankController(TankModel _tankModel, TankView _tankView, FixedJoystick joystick)
        {
            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            tankView.InitializeView(this,joystick);
            ChangeColor(tankModel.material);
            CameraController.GetInstance().SetTarget(tankView.transform);
        }
        public void ShootBullet()
        {
            BulletService.GetInstance().CreateBullet(tankView.BulletShootPoint.position, tankView.transform.rotation, tankModel.bulletType);
        }
        public void Move()
        {
            tankView.Movement = tankView.transform.forward * tankView.InputMovement * tankModel.movementSpeed * Time.deltaTime;
            tankView.TankRigidbody.MovePosition(tankView.TankRigidbody.position + tankView.Movement);
        }
        public void Turn()
        {
            float turn = tankView.InputTurn * tankModel.rotationSpeed * Time.deltaTime;
            Quaternion TurnRotation = Quaternion.Euler(0f, turn, 0f);
            tankView.TankRigidbody.MoveRotation(tankView.TankRigidbody.rotation * TurnRotation);
        }
        public void ChangeColor(Material material)
        {
            for (int i = 0; i < tankView.childs.Length; i++)
            {
                tankView.childs[i].material = material;
            }
        }
        public void ApplyDamage(float damage)
        {
            tankModel.health = tankModel.health - damage;
            if (tankModel.health < 1)
            {
                Dead();
            }
        }

        private void Dead()
        {
            TankService.GetInstance().enabled = false;
        }
    }
}