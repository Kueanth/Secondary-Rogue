using UnityEngine;

public struct Player
{
    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public bool running;
    public bool flipping;
}
