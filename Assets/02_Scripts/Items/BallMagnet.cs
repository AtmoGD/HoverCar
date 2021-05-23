using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMagnet : MonoBehaviour
{
    [SerializeField] private float magnetRadius = 3f;
    [SerializeField] public float magnetPower = 100f;
    void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, magnetRadius, Vector2.zero);

        foreach(RaycastHit2D hit in hits) {
            if(hit.collider.CompareTag("Ball")) {
                Vector2 direction = transform.position - hit.transform.position;
                hit.collider.GetComponent<Rigidbody2D>().AddForce(direction * magnetPower);
            }
        }
    }
}
