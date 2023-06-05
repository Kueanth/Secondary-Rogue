using UnityEngine;

public struct Player
{
    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Transform gun;
    public SpriteRenderer flipGun;

    public bool running;
    public bool flipping;
    public bool waitingFlip;
}
