using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum PlayerColor
{
    YELLOW,
    GREEN,
    BLUE,
    PINK
}


public enum AttackPosition
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttackController))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public MovementController MovementController { get; private set; }
    public AttackController AttackController { get; private set; }
    public Rigidbody RB { get; private set; }
    public SkillData AttackUp { get; private set; }
    public SkillData AttackDown { get; private set; }
    public SkillData AttackRight { get; private set; }
    public SkillData AttackLeft { get; private set; }

    [SerializeField] private PlayerColor playerColor = PlayerColor.PINK;
    [SerializeField] public PlayerData data = null;
    [SerializeField] private Camera cam = null;
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

    void Awake()
    {
        MovementController = GetComponent<MovementController>();
        AttackController = GetComponent<AttackController>();
        RB = GetComponent<Rigidbody>();
    }

    void ChangeColor(PlayerColor _color)
    {
        playerColor = _color;
    }

    public void Hit(PlayerController _owner)
    {
        Debug.Log(playerColor + " got hit by: " + _owner.playerColor);
    }

    public void ChangeAttack(SkillData _newAttack, AttackPosition _position)
    {
        switch (_position)
        {
            case AttackPosition.UP:
                AttackUp = _newAttack;
                break;
            case AttackPosition.DOWN:
                AttackDown = _newAttack;
                break;
            case AttackPosition.LEFT:
                AttackLeft = _newAttack;
                break;
            case AttackPosition.RIGHT:
                AttackRight = _newAttack;
                break;
        }

        AttackController.ActiveAttack = AttackUp;
    }
}
