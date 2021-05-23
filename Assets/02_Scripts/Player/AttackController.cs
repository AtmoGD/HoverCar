using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AttackController : MonoBehaviour
{
    public PlayerController Player { get; private set; }
    public SkillData ActiveAttack { get; set; }
    public float ActiveCooldown { get; private set; }
    public bool CanAttack { get; private set; }
    public bool IsAiming { get; private set; }
    public Vector3 Direction { get; private set; }

    void Awake()
    {
        Player = GetComponent<PlayerController>();
        ActiveAttack = Player.AttackUp;
        Direction = Vector3.zero;
    }

    void Update()
    {
        ActiveCooldown -= Time.deltaTime;
    }

    public void AimPerformed(InputAction.CallbackContext _context)
    {
        IsAiming = true;

        if (_context.phase == InputActionPhase.Canceled)
            IsAiming = false;

        Vector2 inputDir = _context.ReadValue<Vector2>();
        Direction = new Vector3(inputDir.x, 0f, inputDir.y);
    }

    public void AttackPerformed(InputAction.CallbackContext _context)
    {
        if (ActiveCooldown > 0f) return;

        if (_context.phase == InputActionPhase.Performed)
            Attack();
    }

    public void ChangeActiveAttackUp(InputAction.CallbackContext _context)
    {
        if (_context.phase == InputActionPhase.Performed)
            ActiveAttack = Player.AttackUp;
    }

    public void ChangeActiveAttackDown(InputAction.CallbackContext _context)
    {
        if (_context.phase == InputActionPhase.Performed)
            ActiveAttack = Player.AttackDown;
    }

    public void ChangeActiveAttackLeft(InputAction.CallbackContext _context)
    {
        if (_context.phase == InputActionPhase.Performed)
            ActiveAttack = Player.AttackLeft;
    }

    public void ChangeActiveAttackRight(InputAction.CallbackContext _context)
    {
        if (_context.phase == InputActionPhase.Performed)
            ActiveAttack = Player.AttackRight;
    }

    private void Attack()
    {
        if (!IsAiming) return;

        Vector3 spawnPosition = transform.position + ((Vector3)Direction * ActiveAttack.spawnDistance);
        GameObject attack = Instantiate(ActiveAttack.attackPrefab, spawnPosition, transform.rotation);
        attack.GetComponent<Skill>()?.TakeData(ActiveAttack, Player, Direction);

        ActiveCooldown = ActiveAttack.cooldown;
    }
}
