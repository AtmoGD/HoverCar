using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public Rigidbody RB { get; private set; }
    public PlayerController LastHit { get; private set; }
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerController hitedPlayer = collision.gameObject.GetComponent<PlayerController>();

        LastHit = hitedPlayer ? hitedPlayer : LastHit;
    }

    public void ResetBall()
    {
        RB.MovePosition(Vector3.zero + Vector3.up * 3f);
        RB.velocity = Vector3.zero;
        RB.angularVelocity = Vector3.zero;
        RB.AddForce(Vector3.up * 100f);
        LastHit = null;
    }
}
