using UnityEngine;

public struct EnemyData
{
    public int hp;

    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public Animator animator;

    public Vector2 target;

    public int number;

    public Transform[] targets;

    public float timerForShoot;
}
