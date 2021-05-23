using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float moveForce = 1500f;
    public float chargeSpeed = 2f;
    public float recoverTime = 1f;
}
