using UnityEngine;
using UnityEngine.Rendering.Universal;

public struct Player
{
    public int hp;

    public bool dead;

    public bool particleRun;

    public GameObject playerObject;

    public Vector3 positionForPit;

    public Rigidbody2D rigidbody2D;

    public Animator animator;
    public Animator vignetteEffect;

    public SpriteRenderer spriteRenderer;

    public Light2D light;

    public ParticleSystem particleSystem;

    public bool pit;
    public bool running;
    public bool flipping;
    public bool flip;
    public bool nearChest;
    public bool nearHatch;
    public bool nearGun;
    public bool nearHp;

    public bool deadforpit;

    public Transform transform;
    public Transform chest;
    public Transform hatch;
    public Transform hpTransform;
    public Transform gunInChest;
}
