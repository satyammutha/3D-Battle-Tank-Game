using System;
using UnityEngine;

public class TankController : MonoSingletonGeneric1<TankController>
{
    [SerializeField] private float Speed;
    [SerializeField] private float TurnSpeed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody TankRigidbody;
    private float InputMovement;
    private float InputTurn;
    private Vector3 Movement;

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
        Movement = transform.forward * InputMovement * Speed * Time.deltaTime;
        TankRigidbody.MovePosition(TankRigidbody.position + Movement);
    }
    private void Turn()
    {
        float turn = InputTurn * TurnSpeed * Time.deltaTime;
        Quaternion TurnRotation = Quaternion.Euler(0f, turn, 0f);
        TankRigidbody.MoveRotation(TankRigidbody.rotation * TurnRotation);
    }
}