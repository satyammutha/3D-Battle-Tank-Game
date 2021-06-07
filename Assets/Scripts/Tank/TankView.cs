using System;
using UnityEngine;
namespace Tank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private FixedJoystick joystick;
        [SerializeField] private Rigidbody TankRigidbody;
        private float InputMovement;
        private float InputTurn;
        private Vector3 Movement;
        public MeshRenderer[] childs;
        private void Update()
        {
            InputMovement = joystick.Vertical;
            InputTurn = joystick.Horizontal;
        }
        private void FixedUpdate()
        {
            Move();
            Turn();
        }
        private void Move()
        {
            Movement = transform.forward * InputMovement * tankController.tankModel.movementSpeed * Time.deltaTime;
            TankRigidbody.MovePosition(TankRigidbody.position + Movement);
        }
        private void Turn()
        {
            float turn = InputTurn * tankController.tankModel.rotationSpeed * Time.deltaTime;
            Quaternion TurnRotation = Quaternion.Euler(0f, turn, 0f);
            TankRigidbody.MoveRotation(TankRigidbody.rotation * TurnRotation);
        }
        public void initializeView(TankController _tankController, FixedJoystick _fixedJoystick) {
            tankController = _tankController;
            joystick = _fixedJoystick;
        }
        public void ChangeColor(Material material)
        {
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].material = material;
            }
        }
    }
}