using UnityEngine;
using UnityEngine.Rendering.Universal;

public struct Player
{
    public int hp;

    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Transform gun;
    public Light2D light;
    public Transform bulletSpawn;
    public SpriteRenderer flipGun;

    public bool running;
    public bool flipping;
    public bool flip;
}
