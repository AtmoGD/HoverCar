using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : Attack
{
    public new DistanceAttackData Data { get; private set; }
    public override void TakeData(SkillData _data, PlayerController _owner, Vector2 _direction)
    {
        Data = (DistanceAttackData)_data;
        Owner = _owner;
        Direction = _direction;

        rb.AddForce(Direction * Data.startForce);
    }
    // void Update()
    // {
    //     if (!Owner) return;

    //     Vector2 newPosition = (Vector2)transform.position + (Direction * Data.speed * Time.deltaTime);
    //     rb.MovePosition(newPosition);
    // }
}
