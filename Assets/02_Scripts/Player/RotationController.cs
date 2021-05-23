using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class RotationController : MonoBehaviour
{
    public PlayerController Player { get; private set; }
    void Awake()
    {
        Player = GetComponent<PlayerController>();
    }

    public void Look(InputAction.CallbackContext _context)
    {
        Vector2 inputDir = _context.ReadValue<Vector2>();
        Player.cmCam.m_XAxis.m_InputAxisValue = inputDir.x;
        Player.cmCam.m_YAxis.m_InputAxisValue = inputDir.y;
        // Player.
    }
}
