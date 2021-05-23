using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class MovementController : MonoBehaviour
{
    public PlayerController Player { get; private set; }
    public bool IsCharging { get; private set; }
    public Vector3 Direction { get; private set; }
    public float ChargeAmount { get; private set; }
    public float ActualRecover { get; private set; }

    void Awake()
    {
        Player = GetComponent<PlayerController>();
        Direction = Vector3.zero;
    }

    void Update()
    {
        if (IsCharging)
        {
            Rotate();
            Charge();
        }

        ActualRecover -= Time.deltaTime;
    }

    public void ChargePerformed(InputAction.CallbackContext _context)
    {
        IsCharging = true;

        if (_context.phase == InputActionPhase.Canceled)
        {
            IsCharging = false;
            ChargeAmount = 0f;
        }
        Vector2 inputDir = _context.ReadValue<Vector2>();
        
        if (Player)
            Direction = Util.GetDirection(inputDir, Player.cam);
    }

    public void MovePerformed(InputAction.CallbackContext _context)
    {
        if (ActualRecover > 0f) return;

        if (_context.phase == InputActionPhase.Performed)
            Move();
    }

    private void Rotate()
    {
        transform.LookAt(transform.position + Direction, Vector3.up);
    }

    private void Charge()
    {
        if (ActualRecover > 0f) return;

        ChargeAmount += Player.data.chargeSpeed * Time.deltaTime;
        ChargeAmount = Mathf.Clamp01(ChargeAmount);
    }

    private void Move()
    {
        Player?.RB.AddForce(Direction * Player.data.moveForce * ChargeAmount);

        ChargeAmount = 0f;
        if (Player)
            ActualRecover = Player.data.recoverTime;
    }
}
