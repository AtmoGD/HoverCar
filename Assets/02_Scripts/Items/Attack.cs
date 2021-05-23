using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Skill
{
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player)
            player.Hit(Owner);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        

        // Die();
    }
}
