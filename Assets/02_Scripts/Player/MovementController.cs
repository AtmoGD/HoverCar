using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class MovementController : MonoBehaviour
{
    public PlayerController player { get; private set; }
    public bool IsCharging { get; private set; }
    public Vector2 Direction { get; private set; }
    public float ChargeAmount { get; private set; }
    public float ActualRecover { get; private set; }

    void Awake()
    {
        player = GetComponent<PlayerController>();
        Direction = Vector2.zero;
    }

    void Update()
    {
        if (IsCharging) Charge();

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

        Direction = _context.ReadValue<Vector2>();
    }

    public void MovePerformed(InputAction.CallbackContext _context)
    {
        if (ActualRecover > 0f) return;

        if (_context.phase == InputActionPhase.Performed)
            Move();
    }

    private void Charge()
    {
        if (ActualRecover > 0f) return;

        ChargeAmount += player.data.chargeSpeed * Time.deltaTime;
        ChargeAmount = Mathf.Clamp01(ChargeAmount);
    }

    private void Move()
    {
        player.RB.AddForce(Direction * player.data.moveForce * ChargeAmount);

        ChargeAmount = 0f;
        ActualRecover = player.data.recoverTime;
    }
}
