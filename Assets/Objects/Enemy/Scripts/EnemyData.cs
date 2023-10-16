using UnityEngine;

public struct EnemyData
{
    public int hp;
    public string name;

    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public int money;

    public Vector2 target;

    public int number;

    public Transform[] targets;

    public float timerForShoot;
}
