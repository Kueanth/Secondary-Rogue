using UnityEngine;
using UnityEngine.Rendering.Universal;

public struct Player
{
    public int hp;

    public GameObject playerObject;
    public Vector3 positionForPit;

    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public Animator vignetteEffect;
    public SpriteRenderer spriteRenderer;

    public Transform gun;
    public Light2D light;
    public Transform bulletSpawn;
    public SpriteRenderer flipGun;

    public bool pit;
    public bool running;
    public bool flipping;
    public bool flip;
    public bool nearChest;
    public bool nearHatch;

    public Transform chest;
    public Transform hatch;
}
