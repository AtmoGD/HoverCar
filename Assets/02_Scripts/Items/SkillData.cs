using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillData", menuName = "Data/SkillData")]
public class SkillData : ScriptableObject
{
    public new string name = "Attack";
    public string description = "A new Attack";
    public GameObject attackPrefab = null;
    public Sprite sprite = null;
    public float cooldown = 3f;
    public float spawnDistance = 0.5f;
}
