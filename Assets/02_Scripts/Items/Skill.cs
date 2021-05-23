using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float lifeTime = 3f;
    [SerializeField] protected GameObject diePrefab = null;

    public Rigidbody2D rb { get; protected set; }
    public SkillData Data { get; private set; }
    public PlayerController Owner { get; protected set; }
    public Vector2 Direction { get; protected set; }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Direction = Vector2.zero;
    }
    public virtual void TakeData(SkillData _data, PlayerController _owner, Vector2 _direction)
    {
        Data = _data;
        Owner = _owner;
        Direction = _direction;
    }

    void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0f)
            Die();
    }

    public void Die()
    {

        if (diePrefab)
            Instantiate(diePrefab, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}
