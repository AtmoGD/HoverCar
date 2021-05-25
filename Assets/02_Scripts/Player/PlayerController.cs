using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] public PlayerColor playerColor = PlayerColor.PINK;
    [SerializeField] public PlayerData data = null;
    [SerializeField] public Camera cam = null;

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
}
