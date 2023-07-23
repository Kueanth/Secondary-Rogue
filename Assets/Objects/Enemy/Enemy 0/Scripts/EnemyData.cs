using UnityEngine;

public struct EnemyData
{
    public Transform transform;
    public Rigidbody2D rigidbody2D;

    public Vector2 target;

    public int number;

    public Transform[] targets;
}
