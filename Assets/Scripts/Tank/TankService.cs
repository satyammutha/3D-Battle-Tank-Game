using UnityEngine;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {

        [SerializeField] private float speed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private Joystick joystick;
        [SerializeField] private Rigidbody tankRigidbody;
        private float inputMovement;
        private float inputTurn;
        private Vector3 movement;
        [SerializeField] private TankScriptableObjectList tankList;
        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            for (int i = 0; i < 3; i++)
            {
                CreateNewTank(i);
            }
        }

        private TankController CreateNewTank(int index)
        {
            TankScriptableObject tankScriptableObject = tankList.tanks[index];
            TankModel model = new TankModel(tankScriptableObject);
            TankController tankController = new TankController(model, tankScriptableObject.tankView);
            return tankController;
        }
        private void Update()
        {
            inputMovement = joystick.Vertical;
            inputTurn = joystick.Horizontal;
        }
        private void FixedUpdate()
        {
            Move();
            Turn();
        }
        private void Move()
        {
            movement = transform.forward * inputMovement * speed * Time.deltaTime;
            tankRigidbody.MovePosition(tankRigidbody.position + movement);
        }
        private void Turn()
        {
            float turn = inputTurn * turnSpeed * Time.deltaTime;
            Quaternion TurnRotation = Quaternion.Euler(0f, turn, 0f);
            tankRigidbody.MoveRotation(tankRigidbody.rotation * TurnRotation);
        }
    }
}